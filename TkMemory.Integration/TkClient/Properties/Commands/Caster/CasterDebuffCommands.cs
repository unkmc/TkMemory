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
using TkMemory.Integration.TkClient.Properties.Group;
using TkMemory.Integration.TkClient.Properties.Npcs;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Caster
{
    /// <summary>
    /// Commands that are used to cast debuffs and debuff cures that are common to both Mages and Poets.
    /// </summary>
    public abstract class CasterDebuffCommands
    {
        #region Fields

        private readonly KeySpell _cureParalysisSpell;
        private readonly KeySpell _curseSpell;
        private readonly KeySpell _purgeSpell;
        private readonly KeySpell _removeCurseSpell;
        private readonly TkClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns debuff and debuff cure spells from a Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        protected CasterDebuffCommands(MageClient self)
        {
            _self = self;

            _cureParalysisSpell = self.Spells.KeySpells.CureParalysis;
            _curseSpell = self.Spells.KeySpells.Curse;
            _purgeSpell = self.Spells.KeySpells.Purge;
            _removeCurseSpell = self.Spells.KeySpells.RemoveCurse;
        }

        /// <summary>
        /// Assigns debuff and debuff cure spells from a Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        protected CasterDebuffCommands(PoetClient self)
        {
            _self = self;

            _cureParalysisSpell = self.Spells.KeySpells.CureParalysis;
            _curseSpell = self.Spells.KeySpells.Curse;
            _purgeSpell = self.Spells.KeySpells.Purge;
            _removeCurseSpell = self.Spells.KeySpells.RemoveCurse;
        }

        #endregion Constructors

        #region Public Methods

        #region Cure Paralysis

        /// <summary>
        /// Removes the Paralysis debuff from a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> CureParalysis(TkClient target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Debuffs.Paralysis, _cureParalysisSpell);
        }

        /// <summary>
        /// Removes the Paralysis debuff from a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> CureParalysis(GroupMember target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Paralysis, _cureParalysisSpell);
        }

        /// <summary>
        /// Iterates through the caster's group and removes the Paralysis debuff from the first group member found to
        /// affected by it. The method will exit and return true as soon as the spell is cast on one group member. If no
        /// group members are eligible for the spell, the method will return false. The priority order is the caster,
        /// multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> CureParalysisGroup()
        {
            if (await CureParalysis(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await CureParalysis(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await CureParalysis(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Cure Paralysis

        #region Curse

        /// <summary>
        /// Casts a curse (i.e. Vex or Scourge) on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the debuff.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Curse(Npc target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Curse, _curseSpell);
        }

        /// <summary>
        /// Iterates through the NPCs in the caster's vicinity and curses the first NPC found to be eligible for it.
        /// The method will exit and return true as soon as the spell is cast once. If no eligible NPCs are found,
        /// the method will return false.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> CurseNpcs()
        {
            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = _self.Npcs.Count - 1; i >= 0; i--)
            {
                if (await Curse(_self.Npcs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Curse

        #region Purge

        /// <summary>
        /// Removes the Venom debuff from a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Purge(TkClient target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Debuffs.Venom, _purgeSpell);
        }

        /// <summary>
        /// Removes the Venom debuff from a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Purge(GroupMember target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Venom, _purgeSpell);
        }

        /// <summary>
        /// Iterates through the caster's group and removes the Venom debuff from the first group member found to
        /// affected by it. The method will exit and return true as soon as the spell is cast on one group member. If no
        /// group members are eligible for the spell, the method will return false. The priority order is the caster,
        /// multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> PurgeGroup()
        {
            if (await Purge(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await Purge(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await Purge(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Purge

        #region Remove Curse

        /// <summary>
        /// Removes the Vex curse from a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RemoveCurse(TkClient target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Debuffs.Vex, _removeCurseSpell);
        }

        /// <summary>
        /// Removes the Vex curse from a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RemoveCurse(GroupMember target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Vex, _removeCurseSpell);
        }

        /// <summary>
        /// Iterates through the caster's group and removes the Vex debuff from the first group member found to
        /// affected by it. The method will exit and return true as soon as the spell is cast on one group member. If no
        /// group members are eligible for the spell, the method will return false. The priority order is the caster,
        /// multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RemoveCurseGroup()
        {
            if (await RemoveCurse(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await RemoveCurse(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await RemoveCurse(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Remove Curse

        #endregion Public Methods
    }
}
