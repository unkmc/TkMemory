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

using System.Linq;
using System.Threading.Tasks;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Group;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Caster
{
    /// <summary>
    /// Commands that are used to cast the Harden Armor, Sanctuary, and Valor buffs.
    /// </summary>
    public class CasterAsvCommands
    {
        #region Fields

        private readonly KeySpell _hardenArmorSpell;
        private readonly KeySpell _sanctuarySpell;
        private readonly TkClient _self;
        private readonly KeySpell _valorSpell;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns Harden Armor, Sanctuary, and Valor spells from the Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        public CasterAsvCommands(MageClient self)
        {
            _self = self;
            _hardenArmorSpell = self.Spells.KeySpells.HardenArmor;
            _sanctuarySpell = self.Spells.KeySpells.Sanctuary;
            _valorSpell = self.Spells.KeySpells.Valor;
        }

        /// <summary>
        /// Assigns Harden Armor, Sanctuary, and Valor spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public CasterAsvCommands(PoetClient self)
        {
            _self = self;
            _hardenArmorSpell = self.Spells.KeySpells.HardenArmor;
            _sanctuarySpell = self.Spells.KeySpells.Sanctuary;
            _valorSpell = self.Spells.KeySpells.Valor;
        }

        #endregion Constructors

        #region Public Methods

        #region Harden Armor

        /// <summary>
        /// Casts the Harden Armor buff on a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HardenArmor(TkClient target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Asv.HardenArmor, _hardenArmorSpell);
        }

        /// <summary>
        /// Casts the Harden Armor buff on a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HardenArmor(GroupMember target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.HardenArmor, _hardenArmorSpell);
        }

        /// <summary>
        /// Iterates through the caster's group and casts Harden Armor on the first group member found to be eligible
        /// for the buff. The method will exit and return true as soon as the buff is cast on one group member. If no
        /// group members are eligible for the spell, the method will return false. The priority order is the caster,
        /// multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HardenArmorGroup()
        {
            if (await HardenArmor(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await HardenArmor(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await HardenArmor(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Harden Armor

        #region Sanctuary

        /// <summary>
        /// Casts the Sanctuary buff on a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Sanctuary(TkClient target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Asv.Sanctuary, _sanctuarySpell);
        }

        /// <summary>
        /// Casts the Sanctuary buff on a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Sanctuary(GroupMember target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Sanctuary, _sanctuarySpell);
        }

        /// <summary>
        /// Iterates through the caster's group and casts Sanctuary on the first group member found to be eligible
        /// for the buff. The method will exit and return true as soon as the buff is cast on one group member. If no
        /// group members are eligible for the spell, the method will return false. The priority order is the caster,
        /// multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> SanctuaryGroup()
        {
            if (await Sanctuary(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await Sanctuary(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await Sanctuary(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Sanctuary

        #region Valor

        /// <summary>
        /// Casts the Valor buff on a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Valor(TkClient target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Asv.Valor, _valorSpell);
        }

        /// <summary>
        /// Casts the Valor buff on a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Valor(GroupMember target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Valor, _valorSpell);
        }

        /// <summary>
        /// Iterates through the caster's group and casts Valor on the first group member found to be eligible
        /// for the buff. The method will exit and return true as soon as the buff is cast on one group member. If no
        /// group members are eligible for the spell, the method will return false. The priority order is the caster,
        /// multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> ValorGroup()
        {
            var fighters = _self.Group.MultiboxMembers.Where(multiboxMember =>
                multiboxMember.Self.BasePath == TkClient.BasePath.Warrior ||
                multiboxMember.Self.BasePath == TkClient.BasePath.Rogue);

            foreach (var fighter in fighters)
            {
                if (await Valor(fighter))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await Valor(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Valor

        #endregion Public Methods
    }
}
