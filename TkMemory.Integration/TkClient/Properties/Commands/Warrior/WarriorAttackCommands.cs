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
using TkMemory.Integration.TkClient.Infrastructure;
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Warrior
{
    /// <summary>
    /// Commands for physical attacks and casting attack spells specific to Warriors.
    /// </summary>
    public class WarriorAttackCommands : PeasantAttackCommands
    {
        #region Fields

        private readonly KeySpell _berserkSpell;
        private readonly BuffStatus _berserkStatus;
        private readonly KeySpell _whirlwindSpell;
        private readonly BuffStatus _whirlwindStatus;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns attack spells from the Warrior's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Warrior.</param>
        public WarriorAttackCommands(WarriorClient self) : base(self)
        {
            _berserkSpell = self.Spells.KeySpells.Berserk;
            _berserkStatus = self.Status.Berserk;
            _whirlwindSpell = self.Spells.KeySpells.Whirlwind;
            _whirlwindStatus = self.Status.Whirlwind;
        }

        #endregion Constructors

        #region Public Methods
        
        /// <summary>
        /// Casts the Berserk attack spell on the target in front of the caster.
        /// </summary>
        /// <param name="minimumVitaPercent">Vita percent threshold below which the spell
        /// will not be cast.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Berserk(double minimumVitaPercent = 80)
        {
            if (Self.Self.Vita.Percent < minimumVitaPercent.EvaluateAsPercentage())
            {
                return false;
            }

            return await SpellCommands.CastAetheredSpell(Self, _berserkSpell, _berserkStatus);
        }

        /// <summary>
        /// Casts the Whirlwind attack spell on the target in front of the caster.
        /// </summary>
        /// <param name="minimumVitaPercent">Vita percent threshold below which the spell
        /// will not be cast.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Whirlwind(double minimumVitaPercent = 80)
        {
            if (Self.Self.Vita.Percent < minimumVitaPercent.EvaluateAsPercentage())
            {
                return false;
            }

            return await SpellCommands.CastAetheredSpell(Self, _whirlwindSpell, _whirlwindStatus);
        }

        #endregion Public Methods
    }
}
