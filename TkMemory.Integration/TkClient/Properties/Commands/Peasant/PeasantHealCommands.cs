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
using TkMemory.Integration.TkClient.Properties.Group;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Peasant
{
    /// <summary>
    /// Commands for vita restoration spells common to all paths.
    /// </summary>
    public class PeasantHealCommands
    {
        #region Fields

        private readonly HealKeySpell _healSpell;
        private readonly HealKeySpell _healSelfSpell;
        private readonly TkClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns heal spells from the Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        public PeasantHealCommands(MageClient self)
        {
            _self = self;
            _healSpell = self.Spells.KeySpells.Heal;
            _healSelfSpell = self.Spells.KeySpells.HealSelf;
        }

        /// <summary>
        /// Assigns heal spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public PeasantHealCommands(PoetClient self)
        {
            _self = self;
            _healSpell = self.Spells.KeySpells.Heal;
            _healSelfSpell = self.Spells.KeySpells.HealSelf;
        }
        
        /// <summary>
        /// Assigns heal spells from the Rogue's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Rogue.</param>
        public PeasantHealCommands(RogueClient self)
        {
            _self = self;
            _healSpell = self.Spells.KeySpells.Heal;
            _healSelfSpell = self.Spells.KeySpells.HealSelf;
        }

        /// <summary>
        /// Assigns heal spells from the Warrior's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Warrior.</param>
        public PeasantHealCommands(WarriorClient self)
        {
            _self = self;
            _healSpell = self.Spells.KeySpells.Heal;
            _healSelfSpell = self.Spells.KeySpells.HealSelf;
        }

        #endregion Constructors

        #region Public Methods

        #region Heal

        /// <summary>
        /// Casts a vita restoration spell on a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Heal(TkClient target)
        {
            return await Heal(target.Self.Uid, target.Self.Name);
        }

        /// <summary>
        /// Casts a vita restoration spell on a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Heal(GroupMember target)
        {
            return await Heal(target.Uid, target.Name);
        }

        #endregion Heal

        #region HealIfBelowPercent

        /// <summary>
        /// Casts a vita restoration spell on a target if the target has a vita percentage below
        /// than the specified threshold.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <param name="minimumVitaPercent">The vita percentage threshold below which a target
        /// becomes eligible for the spell.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealIfBelowVitaPercent(TkClient target, double minimumVitaPercent)
        {
            await _self.Activity.WaitForCommandCooldown();
            var targetVitaPercent = target.Self.Vita.Percent;

            return await HealIfBelowVitaPercent(target.Self.Uid, target.Self.Name, targetVitaPercent, minimumVitaPercent);
        }

        /// <summary>
        /// Casts a vita restoration spell on a target if the target has a vita percentage below
        /// than the specified threshold.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <param name="minimumVitaPercent">The vita percentage threshold below which a target
        /// becomes eligible for the spell.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealIfBelowVitaPercent(GroupMember target, double minimumVitaPercent)
        {
            await _self.Activity.WaitForCommandCooldown();
            var targetVitaPercent = _self.Group.Vita.GetPercent(target.Position);

            return await HealIfBelowVitaPercent(target.Uid, target.Name, targetVitaPercent, minimumVitaPercent);
        }

        /// <summary>
        /// Iterates through the caster's group and casts a vita restoration spell on the first
        /// group member found to be below the vita percentage threshold. The method will exit
        /// and return true as soon as the spell is cast on one group member. If no group members
        /// are eligible for the spell, the method will return false. The priority order is the
        /// caster, multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealGroupIfBelowVitaPercent(double minimumVitaPercent)
        {
            if (await HealIfBelowVitaPercent(_self, minimumVitaPercent))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await HealIfBelowVitaPercent(multiboxMember, minimumVitaPercent))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await HealIfBelowVitaPercent(externalMember, minimumVitaPercent))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion HealIfBelowPercent

        #region HealIfEligible

        /// <summary>
        /// Casts a vita restoration spell on a target if the target has a vita deficit greater
        /// than the restoration amount of the spell.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealIfEligible(TkClient target)
        {
            await _self.Activity.WaitForCommandCooldown();
            var targetVitaDeficit = target.Self.Vita.Deficit;

            return await HealIfEligible(target.Self.Uid, target.Self.Name, targetVitaDeficit);
        }

        /// <summary>
        /// Casts a vita restoration spell on a target if the target has a vita deficit greater
        /// than the restoration amount of the spell.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealIfEligible(GroupMember target)
        {
            await _self.Activity.WaitForCommandCooldown();
            var targetVitaDeficit = _self.Group.Vita.GetDeficit(target.Position);

            return await HealIfEligible(target.Uid, target.Name, targetVitaDeficit);
        }

        /// <summary>
        /// Iterates through the caster's group and casts a vita restoration spell on the first
        /// group member found to have a vita deficit greater than the restoration amount of the
        /// spell. The method will exit and return true as soon as the spell is cast on one group
        /// member. If no group members are eligible for the spell, the method will return false.
        /// The priority order is the caster, multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealGroupIfEligible()
        {
            if (await HealIfEligible(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await HealIfEligible(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await HealIfEligible(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion HealIfEligible

        #region HealSelf

        /// <summary>
        /// Casts a non-targetable, self-heal spell.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealSelf()
        {
            return await SpellCommands.CastSpell(_self, _healSelfSpell);
        }

        /// <summary>
        /// Casts a non-targetable, self-heal spell if the caster has a vita percentage below the
        /// specified threshold.
        /// </summary>
        /// <param name="minimumVitaPercent">The vita percentage threshold below which the caster
        /// becomes eligible for the spell.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealSelfIfBelowVitaPercent(double minimumVitaPercent)
        {
            await _self.Activity.WaitForCommandCooldown();
            var currentVitaPercent = _self.Self.Vita.Percent;

            return currentVitaPercent < minimumVitaPercent.EvaluateAsPercentage() && await HealSelf();
        }

        /// <summary>
        /// Casts a non-targetable, self-heal spell if the caster has a vita deficit greater
        /// than the restoration amount of the spell.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HealSelfIfEligible()
        {
            await _self.Activity.WaitForCommandCooldown();
            var currentVitaDeficit = _self.Self.Vita.Deficit;

            return currentVitaDeficit >= _healSelfSpell.Vita && await HealSelf();
        }

        #endregion HealSelf

        #endregion Public Methods

        #region Private Methods

        private async Task<bool> Heal(uint targetUid, string targetName)
        {
            return await SpellCommands.CastTargetableSpell(_self, _healSpell, targetUid, targetName);
        }

        private async Task<bool> HealIfBelowVitaPercent(uint targetUid, string targetName, double targetVitaPercent, double minimumVitaPercent)
        {
            return targetVitaPercent < minimumVitaPercent.EvaluateAsPercentage() &&
                   await Heal(targetUid, targetName);
        }

        private async Task<bool> HealIfEligible(uint targetUid, string targetName, double targetVitaDeficit)
        {
            if (_healSpell == null)
            {
                return false;
            }

            return targetVitaDeficit >= _healSpell.Vita &&
                   await Heal(targetUid, targetName);
        }

        #endregion
    }
}
