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
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Fighter
{
    /// <summary>
    /// Commands that are used to cast buffs that are common to both Rogues and Warriors.
    /// </summary>
    public abstract class FighterBuffCommands
    {
        #region Fields

        protected readonly FighterClient Self;
        protected readonly KeySpell RageSpell;
        protected readonly RageStatus RageStatus;

        private readonly KeySpell _enchantSpell;
        private readonly KeySpell _furySpell;
        private readonly BuffStatus _furyStatus;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns buff spells from the Rogue's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Rogue.</param>
        protected FighterBuffCommands(RogueClient self)
        {
            Self = self;
            RageSpell = self.Spells.KeySpells.Rage;
            RageStatus = self.Status.Rage;

            _enchantSpell = self.Spells.KeySpells.Enchant;
            _furySpell = self.Spells.KeySpells.Fury;
            _furyStatus = self.Status.Fury;
        }

        /// <summary>
        /// Assigns buff spells from the Warrior's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Warrior.</param>
        protected FighterBuffCommands(WarriorClient self)
        {
            Self = self;
            RageSpell = self.Spells.KeySpells.Rage;
            RageStatus = self.Status.Rage;

            _enchantSpell = self.Spells.KeySpells.Enchant;
            _furySpell = self.Spells.KeySpells.Fury;
            _furyStatus = self.Status.Fury;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Casts an Enchantment buff.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task Enchant()
        {
            await SpellCommands.CastSpell(Self, _enchantSpell);
        }

        /// <summary>
        /// Casts a Fury buff. Does not include Rage/Cunning.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Fury()
        {
            if (RageSpell != null)
            {
                return false;
            }

            return await SpellCommands.CastAetheredSpell(Self, _furySpell, _furyStatus);
        }

        /// <summary>
        /// Casts a Rage/Cunning buff. Does not include Furies.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Rage()
        {
            return await SpellCommands.CastRage(Self, RageSpell, RageStatus);
        }

        #endregion Public Methods
    }
}
