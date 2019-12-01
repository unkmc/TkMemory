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

using System.Collections.Generic;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Activity;

namespace TkMemory.Integration.TkClient.Properties.Status.KeySpells
{
    /// <summary>
    /// Tracks the properties of a buff key spell used to determine when it is actively affecting
    /// the player and when it can be recast. "Buffs" in this case also includes aethered spells
    /// that probably do not intuitively seem like buffs (e.g. Invoke, Restore, Berserk, etc.).
    /// These are considered buffs because the aethers feature creates a status effect with a
    /// duration just like more traditional buffs.
    /// </summary>
    public class BuffStatus : KeySpellStatus
    {
        #region Fields

        private int _inactiveCount;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes the key spell properties used to track the status of the buff.
        /// </summary>
        /// <param name="activity">The activity data of the player.</param>
        /// <param name="aliases">A list of all unaligned and aligned names of the buff.</param>
        public BuffStatus(TkActivity activity, IEnumerable<KeySpell> aliases) : base(activity, aliases)
        {
            _inactiveCount = RequiredInactiveCount;
        }

        #endregion Constructors

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
            var isActive = IsCoolingDown() || IsListedInActiveEffects();

            if (isActive)
            {
                _inactiveCount = 0;
                return true;
            }

            _inactiveCount++;
            return _inactiveCount < RequiredInactiveCount;
        }

        #endregion Protected Methods
    }
}
