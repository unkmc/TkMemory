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
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Warrior
{
    /// <summary>
    /// Commands specific to Warriors that are used to cast buffs.
    /// </summary>
    public class WarriorBuffCommands : FighterBuffCommands
    {
        #region Fields

        private readonly KeySpell _backstabSpell;
        private readonly BuffStatus _backstabStatus;
        private readonly KeySpell _blessingSpell;
        private readonly BuffStatus _blessingStatus;
        private readonly KeySpell _flankSpell;
        private readonly BuffStatus _flankStatus;
        private readonly KeySpell _potenceSpell;
        private readonly BuffStatus _potenceStatus;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns buff spells from the Warrior's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Warrior.</param>
        public WarriorBuffCommands(WarriorClient self) : base(self)
        {
            _backstabSpell = self.Spells.KeySpells.Backstab;
            _backstabStatus = self.Status.Backstab;
            _blessingSpell = self.Spells.KeySpells.Blessing;
            _blessingStatus = self.Status.Blessing;
            _flankSpell = self.Spells.KeySpells.Flank;
            _flankStatus = self.Status.Flank;
            _potenceSpell = self.Spells.KeySpells.Potence;
            _potenceStatus = self.Status.Potence;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Casts the Backstab buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Backstab()
        {
            return await SpellCommands.CastAetheredSpell(Self, _backstabSpell, _backstabStatus);
        }

        /// <summary>
        /// Casts the Blessing buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Blessing()
        {
            return await SpellCommands.CastAetheredSpell(Self, _blessingSpell, _blessingStatus);
        }

        /// <summary>
        /// Casts the Flank buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Flank()
        {
            return await SpellCommands.CastAetheredSpell(Self, _flankSpell, _flankStatus);
        }

        /// <summary>
        /// Casts the Potency buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Potence()
        {
            return await SpellCommands.CastAetheredSpell(Self, _potenceSpell, _potenceStatus);
        }

        #endregion Public Methods
    }
}
