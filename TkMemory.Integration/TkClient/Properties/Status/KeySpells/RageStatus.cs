// This file is part of TkMemory.

// TkMemory is free software. You can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License or (at your
// option) any later version.

// TkMemory is distributed in the hope that it will be useful but WITHOUT
// ANY WARRANTY, without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
// for more details.

// You should have received a copy of the GNU General Public License
// along with TkMemory. If not, please refer to:
// https://www.gnu.org/licenses/gpl-3.0.en.html

using System;
using System.Linq;
using TkMemory.Domain.Spells;

namespace TkMemory.Integration.TkClient.Properties.Status.KeySpells
{
    /// <summary>
    /// Tracks the properties of a Rage/Cunning key spell used to determine when it is actively affecting
    /// the player and when it can be recast.
    /// </summary>
    public class RageStatus : BuffStatus
    {
        #region Fields

        private const int LagFactorInSeconds = 2;

        private readonly int _maxRageLevel;
        private readonly BuffKeySpell[] _rageLevels;
        private readonly TkClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes the key spell properties used to track the status of Rage/Cunning.
        /// </summary>
        /// <param name="self">All game client data for the Rogue or Warrior.</param>
        /// <param name="rageLevels">A list of each key spell for each level of Rage/Cunning.</param>
        public RageStatus(TkClient self, BuffKeySpell[] rageLevels) : base(self.Activity, rageLevels)
        {
            _self = self;
            _rageLevels = rageLevels;
            _maxRageLevel = GetMaxRageLevel();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the Rage/Cunning level that is currently active on the Rogue or Warrior.
        /// </summary>
        public int CurrentRageLevel { get; internal set; }

        #endregion Properties

        #region Protected Methods

        /// <summary>
        /// This is way of dealing with lag. A status effect can remain active for a brief
        /// period after the status box shows it as having expired. This method forces a
        /// status to show as inactive three times in a row to be considered truly inactive.
        /// Essentially, this enforces an artificial delay of three command cycles in between
        /// detecting an inactive status effect and recasting that status effect to avoid
        /// redundant casting.
        /// </summary>
        protected override bool CheckIfActive()
        {
            var isActive = base.CheckIfActive();

            if (!isActive)
            {
                CurrentRageLevel = 0;
                return false;
            }

            if (CurrentRageLevel == _maxRageLevel)
            {
                return true;
            }

            var nextRageLevel = _rageLevels[CurrentRageLevel]; // CurrentRageLevel is 1-indexed and therefore equivalent to the 0-indexed next level
            var remainingAethers = GetRemainingAethers();
            var aetherCeilingForNextCasting = nextRageLevel.Duration - nextRageLevel.Aethers - LagFactorInSeconds;

            return remainingAethers >= aetherCeilingForNextCasting;
        }

        #endregion Protected Methods

        #region Private Methods

        private int GetMaxRageLevel()
        {
            var maxRageLevel = _rageLevels.FirstOrDefault(x => x.Cost <= _self.Self.Mana.Max);
            return maxRageLevel == null
                ? -1
                : Convert.ToInt32(maxRageLevel.DisplayName[maxRageLevel.DisplayName.Length - 1]);
        }

        private int GetRemainingAethers()
        {
            var spellName = Aliases[0];

            var activeStatusEffects = Activity.ActiveStatusEffects
                .Split(new[] { System.Environment.NewLine, "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var rage = activeStatusEffects.FirstOrDefault(x => x.TrimStart().StartsWith(spellName));

            if (string.IsNullOrWhiteSpace(rage))
            {
                return 0;
            }

            var remainingAethers = rage
                .Replace(spellName, string.Empty)
                .Replace("s", string.Empty)
                .Trim();

            return Convert.ToInt32(remainingAethers);
        }

        #endregion Private Methods
    }
}
