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

using TkMemory.Domain.Spells.KeySpells.Priorities;
using TkMemory.Integration.TkClient.Properties.Activity;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the Mage
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Invoke, etc.).
    /// </summary>
    public class MageStatus : CasterStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes a Mage's status data.
        /// </summary>
        /// <param name="activity">The activity data of the Mage.</param>
        public MageStatus(TkActivity activity) : base(activity)
        {
            Doze = new BuffStatus(activity, Mage.Doze);
            Hellfire = new BuffStatus(activity, Mage.Hellfire);
            Inferno = new BuffStatus(activity, Mage.Inferno);
            Sleep = new BuffStatus(activity, Mage.Sleep);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the status of the Doze key spell.
        /// </summary>
        public BuffStatus Doze { get; }

        /// <summary>
        /// Gets the status of the Hellfire key spell.
        /// </summary>
        public BuffStatus Hellfire { get; }

        /// <summary>
        /// Gets the status of the Inferno key spell.
        /// </summary>
        public BuffStatus Inferno { get; }

        /// <summary>
        /// Gets the status of the Sleep key spell.
        /// </summary>
        public BuffStatus Sleep { get; }

        #endregion Properties
    }
}
