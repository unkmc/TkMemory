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

using System.Threading.Tasks;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Fighter;
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Warrior
{
    /// <summary>
    /// Commands specific to Warriors.
    /// </summary>
    public class WarriorCommands : FighterCommands
    {
        #region Fields

        private readonly KeySpell _spotTrapsSpell;
        private readonly BuffStatus _spotTrapsStatus;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns spells from the Warrior's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Warrior.</param>
        public WarriorCommands(WarriorClient self) : base(self)
        {
            _spotTrapsSpell = self.Spells.KeySpells.SpotTraps;
            _spotTrapsStatus = self.Status.SpotTraps;

            Attacks = new WarriorAttackCommands(self);
            Buffs = new WarriorBuffCommands(self);
            Heal = new PeasantHealCommands(self);
        }

        #endregion Constructors

        #region Properties
        /// <summary>
        /// Commands for physical attacks and casting attack spells.
        /// </summary>
        public WarriorAttackCommands Attacks { get; }

        /// <summary>
        /// Commands for casting buff spells.
        /// </summary>
        public WarriorBuffCommands Buffs { get; }

        /// <summary>
        /// Commands for casting vita restoration spells.
        /// </summary>
        public PeasantHealCommands Heal { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Reveals any NPC ambushes hidden on the screen.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> SpotTraps()
        {
            return await SpellCommands.CastAetheredSpell(Self, _spotTrapsSpell, _spotTrapsStatus);
        }

        #endregion Public Methods
    }
}
