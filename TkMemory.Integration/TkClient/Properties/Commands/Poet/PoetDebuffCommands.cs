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
using TkMemory.Integration.TkClient.Properties.Commands.Caster;
using TkMemory.Integration.TkClient.Properties.Group;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Poet
{
    /// <summary>
    /// Commands that are used to cast debuffs and debuff cures that are specific to Poets.
    /// </summary>
    public class PoetDebuffCommands : CasterDebuffCommands
    {
        #region Fields

        private readonly KeySpell _atoneSpell;
        private readonly KeySpell _removeVeilSpell;
        private readonly PoetClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns debuff spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public PoetDebuffCommands(PoetClient self) : base(self)
        {
            _self = self;

            _atoneSpell = _self.Spells.KeySpells.Atone;
            _removeVeilSpell = _self.Spells.KeySpells.RemoveVeil;
        }

        #endregion Constructors

        #region Public Methods

        #region Atone

        /// <summary>
        /// Removes the Scourge debuff from a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Atone(TkClient target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Debuffs.Scourge, _atoneSpell);
        }

        /// <summary>
        /// Removes the Scourge debuff from a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Atone(GroupMember target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Scourge, _atoneSpell);
        }

        /// <summary>
        /// Iterates through the caster's group and removes the Scourge debuff from the first group member found to
        /// affected by it. The method will exit and return true as soon as the spell is cast on one group member. If no
        /// group members are eligible for the spell, the method will return false. The priority order is the caster,
        /// multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> AtoneGroup()
        {
            if (await Atone(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await Atone(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await Atone(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Atone

        #region Esuna

        /// <summary>
        /// Casts the Poet's full array of debuff cures on a target. Each debuff cure will only be cast if the target
        /// is found to be affected by the debuff. The method will exit and return true as soon as a spell is cast on
        /// on the target. If no spells are cast, the method will return false. The spell priority is Atone, Remove Curse,
        /// Cure Paralysis, Purge, and then Remove Veil.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if a spell was cast; false otherwise.</returns>
        public async Task<bool> Esuna(TkClient target)
        {
            return await Atone(target)
                || await RemoveCurse(target)
                || await CureParalysis(target)
                || await Purge(target)
                || await RemoveVeil(target);
        }

        /// <summary>
        /// Casts the Poet's full array of debuff cures on a target. Since there is no way to read the active status
        /// effects of an external group member, each debuff cure is cast on its turn but is skipped on the subsequent
        /// iteration of this method (assuming eligibility is not reset by some other process). The method will exit
        /// and return true as soon as a spell is cast on on the target. If no spells are cast, the method will return
        /// false. The spell priority is Atone, Remove Curse, Cure Paralysis, Purge, and then Remove Veil.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if a spell was cast; false otherwise.</returns>
        public async Task<bool> Esuna(GroupMember target)
        {
            return await Atone(target)
                || await RemoveCurse(target)
                || await CureParalysis(target)
                || await Purge(target)
                || await RemoveVeil(target);
        }

        /// <summary>
        /// Iterates through the Poet's group and casts the Poet's full array of debuff cures on each group member.
        /// The method will exit and return true as soon as a spell is cast on a group member. If no spells are cast,
        /// the method will return false. The group member priority order is the caster, multibox group members, and
        /// then external group members. The spell priority is Atone, Remove Curse, Cure Paralysis, Purge, and then
        /// Remove Veil.
        /// </summary>
        /// <returns>True if a spell was cast; false otherwise.</returns>
        public async Task<bool> EsunaGroup()
        {
            if (await Esuna(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await Esuna(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await Esuna(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Esuna

        #region RemoveVeil

        /// <summary>
        /// Removes the Blindness debuff from a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RemoveVeil(TkClient target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Debuffs.Blindness, _removeVeilSpell);
        }

        /// <summary>
        /// Removes the Blindness debuff from a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RemoveVeil(GroupMember target)
        {
            return await StatusCommands.CastDebuffCure(_self, target, target.Activity.Blindness, _removeVeilSpell);
        }

        /// <summary>
        /// Iterates through the caster's group and removes the Blindness debuff from the first group member found to
        /// affected by it. The method will exit and return true as soon as the spell is cast on one group member. If no
        /// group members are eligible for the spell, the method will return false. The priority order is the caster,
        /// multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RemoveVeilGroup()
        {
            if (await RemoveVeil(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await RemoveVeil(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await RemoveVeil(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion RemoveVeil

        #endregion Public Methods
    }
}
