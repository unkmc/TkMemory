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
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the Warrior
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Fury, Rage, etc.).
    /// </summary>
    public class WarriorStatus : FighterStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes a Warrior's status data.
        /// </summary>
        /// <param name="self">All game client data for the Warrior.</param>
        public WarriorStatus(TkClient self) : base(self.Activity)
        {
            Backstab = new BuffStatus(Activity, Warrior.Backstab);
            Berserk = new BuffStatus(Activity, Warrior.Berserk);
            Blessing = new BuffStatus(Activity, Warrior.Blessing);
            Flank = new BuffStatus(Activity, Warrior.Flank);
            Fury = new BuffStatus(Activity, Warrior.Fury);
            Potence = new BuffStatus(Activity, Warrior.Potence);
            Rage = new RageStatus(self, Warrior.Rage);
            SpotTraps = new BuffStatus(Activity, Warrior.SpotTraps);
            Whirlwind = new BuffStatus(Activity, Warrior.Whirlwind);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the status of the Backstab buff.
        /// </summary>
        public BuffStatus Backstab { get; }

        /// <summary>
        /// Gets the status of the Berserk key spell.
        /// </summary>
        public BuffStatus Berserk { get; }

        /// <summary>
        /// Gets the status of the Blessing buff.
        /// </summary>
        public BuffStatus Blessing { get; }

        /// <summary>
        /// Gets the status of the Flank buff.
        /// </summary>
        public BuffStatus Flank { get; }

        /// <summary>
        /// Gets the status of the Potence buff.
        /// </summary>
        public BuffStatus Potence { get; }

        /// <summary>
        /// Gets the status of the Spot Traps key spell.
        /// </summary>
        public BuffStatus SpotTraps { get; }

        /// <summary>
        /// Gets the status of the Whirlwind key spell.
        /// </summary>
        public BuffStatus Whirlwind { get; }

        #endregion Properties
    }
}
