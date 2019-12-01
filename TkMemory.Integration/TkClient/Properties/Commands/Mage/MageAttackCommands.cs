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
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;
using TkMemory.Integration.TkClient.Properties.Npcs;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Mage
{
    /// <summary>
    /// Commands for physical attacks and casting attack spells specific to Mages.
    /// </summary>
    public class MageAttackCommands : PeasantAttackCommands
    {
        #region Fields

        private readonly KeySpell _hellfireSpell;
        private readonly BuffStatus _hellfireStatus;
        private readonly KeySpell _infernoSpell;
        private readonly BuffStatus _infernoStatus;
        private readonly MageClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns attack spells from the Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        public MageAttackCommands(MageClient self) : base(self)
        {
            _self = self;

            _hellfireSpell = self.Spells.KeySpells.Hellfire;
            _hellfireStatus = self.Status.Hellfire;
            _infernoSpell = self.Spells.KeySpells.Inferno;
            _infernoStatus = self.Status.Inferno;
        }

        #endregion Constructors

        #region Public Methods

        #region Hellfire

        /// <summary>
        /// Casts the Hellfire attack spell on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the attack.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Hellfire(Npc target)
        {
            if (_hellfireStatus.IsActive) // Potentially redundant but required to avoid unnecessary casting of Doze/Sleep.
            {
                return false;
            }

            if (!await _self.Commands.Debuffs.Doze(target))
            {
                await _self.Commands.Debuffs.Sleep(target);
            }

            return await SpellCommands.CastAetheredTargetableSpell(Self, _hellfireSpell, _hellfireStatus, target);
        }

        /// <summary>
        /// Cast the Hellfire attack spell on the first available target.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Hellfire()
        {
            if (_hellfireStatus.IsActive) // Definitely redundant but avoids checking once per NPC while aethered, so actually more efficient in most cases.
            {
                return false;
            }

            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = Self.Npcs.Count - 1; i >= 0; i--)
            {
                if (await Hellfire(Self.Npcs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Hellfire

        #region Inferno

        /// <summary>
        /// Casts the Inferno attack spell on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the attack.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Inferno(Npc target)
        {
            if (_infernoStatus.IsActive) // Potentially redundant but required to avoid unnecessary casting of Doze/Sleep.
            {
                return false;
            }

            if (!await _self.Commands.Debuffs.Doze(target))
            {
                await _self.Commands.Debuffs.Sleep(target);
            }

            return await SpellCommands.CastAetheredTargetableSpell(Self, _infernoSpell, _infernoStatus, target);
        }

        /// <summary>
        /// Cast the Inferno attack spell on the first available target.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Inferno()
        {
            if (_infernoStatus.IsActive) // Definitely redundant but avoids checking once per NPC while aethered, so actually more efficient in most cases.
            {
                return false;
            }

            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = Self.Npcs.Count - 1; i >= 0; i--)
            {
                if (await Inferno(Self.Npcs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Inferno

        #endregion Public Methods
    }
}
