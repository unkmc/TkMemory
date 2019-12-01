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
    /// Tracks the properties of a Rogue's Invisible key spell used to determine when it is active.
    /// </summary>
    public class InvisibleStatus : KeySpellStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes the key spell properties used to track the status of the buff.
        /// </summary>
        /// <param name="activity">The activity data of the player.</param>
        /// <param name="aliases">A list of all unaligned and aligned names of the buff.</param>
        public InvisibleStatus(TkActivity activity, IEnumerable<KeySpell> aliases) : base(activity, aliases) { }

        #endregion Constructors

        #region Protected Methods

        /// <summary>
        /// Invisible should always be considered inactive because it needs to be cast so frequently that routine
        /// lag causes excessive delays between castings. This does cause redundant attempts to cast, but that
        /// is less detrimental than the alternative.
        /// </summary>
        protected override bool CheckIfActive()
        {
            return false;
        }

        #endregion Protected Methods
    }
}
