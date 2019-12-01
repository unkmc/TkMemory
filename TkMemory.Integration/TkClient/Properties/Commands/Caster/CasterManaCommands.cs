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
using Serilog;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Infrastructure;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Caster
{
    /// <summary>
    /// Commands for spells common to Mages and Poets that are used restore the mana of oneself or a group member.
    /// </summary>
    public abstract class CasterManaCommands
    {
        #region Fields

        protected readonly KeySpell InvokeSpell;
        protected readonly BuffStatus InvokeStatus;
        protected readonly TkClient Self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns mana restoration spells from a Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        protected CasterManaCommands(MageClient self)
        {
            Self = self;

            InvokeSpell = self.Spells.KeySpells.Invoke;
            InvokeStatus = self.Status.Invoke;

            if (InvokeSpell == null)
            {
                Log.Warning($"{self.Self.Name} does not have an Invoke spell. Mana restoration item consumption will be very high.");
            }
        }

        /// <summary>
        /// Assigns mana restoration spells from a Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        protected CasterManaCommands(PoetClient self)
        {
            Self = self;

            InvokeSpell = self.Spells.KeySpells.Invoke;
            InvokeStatus = self.Status.Invoke;

            if (InvokeSpell == null)
            {
                Log.Warning($"{self.Self.Name} does not have an Invoke spell. Mana restoration item consumption will be very high.");
            }
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Casts the Invoke spell to restore mana at the cost of vita but only if current
        /// mana is less than the specified threshold. Set threshold to 100 to always Invoke
        /// as soon as possible.
        /// </summary>
        /// <param name="manaPercentFloor">The mana percent threshold below which the spell
        /// is eligible to be cast.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Invoke(double manaPercentFloor = 10)
        {
            if (Self.Self.Mana.Percent > manaPercentFloor.EvaluateAsPercentage())
            {
                return false;
            }

            return await SpellCommands.CastAetheredSpell(Self, InvokeSpell, InvokeStatus, true);
        }

        #endregion Public Methods
    }
}
