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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Activity;

namespace TkMemory.Integration.TkClient.Properties.Status.KeySpells
{
    /// <summary>
    /// Tracks the properties of a key spell used to determine when it is actively affecting
    /// the player and, if applicable, when it can be recast.
    /// </summary>
    public abstract class KeySpellStatus
    {
        #region Fields

        protected const int RequiredInactiveCount = 3;
        private const int CooldownInMilliseconds = 1000;

        protected readonly string[] Aliases;
        protected readonly TkActivity Activity;
        private DateTime _timeOfPreviousCasting;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes the key spell properties used to track the status of the key spell.
        /// </summary>
        /// <param name="activity">The activity data of the player.</param>
        /// <param name="aliases">A list of all unaligned and aligned names of the key spell.</param>
        protected KeySpellStatus(TkActivity activity, IEnumerable<KeySpell> aliases)
        {
            Aliases = aliases.Select(buff => buff.AlignedName).ToArray();
            Activity = activity;
            _timeOfPreviousCasting = DateTime.Now.AddMilliseconds(-CooldownInMilliseconds);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets whether or not the status effect caused by the key spell is currently active.
        /// </summary>
        public bool IsActive => CheckIfActive();

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Resets the cooldown timer for the key spell. This must be done after casting a spell to
        /// avoid repeatedly casting the key spell and doing nothing else until the client acknowledges
        /// that the key spell has taken effect.
        /// </summary>
        public void ResetStatusCooldown()
        {
            _timeOfPreviousCasting = DateTime.Now;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// This is a way of dealing with lag. A status effect may not show as active for a
        /// brief period after sending the command to cast it. This prevents checking to see
        /// if a status effect should be recast until one second after it was cast to avoid
        /// redundant casting. If it is still inactive after one second, it is assumed to
        /// have failed and is recast.
        /// </summary>
        protected bool IsCoolingDown()
        {
            return (DateTime.Now - _timeOfPreviousCasting).TotalMilliseconds <= CooldownInMilliseconds;
        }

        /// <summary>
        /// Gets whether or not any alias of the key spell is listed in the client's list of active
        /// status effects.
        /// </summary>
        /// <returns>True if the key spell is active; false otherwise.</returns>
        protected bool IsListedInActiveEffects()
        {
            return Aliases.Any(alias =>
                CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                    Activity.ActiveStatusEffects.Replace("'", string.Empty),
                    alias.Replace("'", string.Empty),
                    CompareOptions.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>
        /// This is way of dealing with lag. A status effect can remain active for a brief
        /// period after the status box shows it as having expired. This method forces a
        /// status to show as inactive three times in a row to be considered truly inactive.
        /// Essentially, this enforces an artificial delay of three command cycles in between
        /// detecting an inactive status effect and recasting that status effect to avoid
        /// redundant casting.
        /// </summary>
        protected abstract bool CheckIfActive();

        #endregion Protected Methods
    }
}
