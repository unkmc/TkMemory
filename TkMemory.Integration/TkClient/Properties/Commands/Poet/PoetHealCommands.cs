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
using TkMemory.Integration.TkClient.Properties.Group;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Poet
{
    /// <summary>
    /// Commands for vita restoration spells specific to Poets.
    /// </summary>
    public class PoetHealCommands : PeasantHealCommands
    {
        #region Fields

        private readonly KeySpell _restoreSpell;
        private readonly PoetClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns heal spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public PoetHealCommands(PoetClient self) : base(self)
        {
            _self = self;
            _restoreSpell = _self.Spells.KeySpells.Restore;
        }

        #endregion Constructors

        #region Public Methods

        #region Restore

        /// <summary>
        /// Casts the Restore vita restoration spell on a target.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Restore(TkClient target)
        {
            return await Restore(target.Self.Uid, target.Self.Name);
        }

        /// <summary>
        /// Casts the Restore vita restoration spell on a target.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Restore(GroupMember target)
        {
            return await Restore(target.Uid, target.Name);
        }

        #endregion Restore

        #region RestoreIfBelowVitaPercent

        /// <summary>
        /// Casts the Restore vita restoration spell on a target if the target has a vita percentage below
        /// than the specified threshold.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <param name="minimumVitaPercent">The vita percentage threshold below which a target
        /// becomes eligible for the spell.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RestoreIfBelowVitaPercent(TkClient target, double minimumVitaPercent)
        {
            await _self.Activity.WaitForCommandCooldown();
            var targetVitaPercent = target.Self.Vita.Percent;

            return await RestoreIfBelowVitaPercent(target.Self.Uid, target.Self.Name, targetVitaPercent, minimumVitaPercent);
        }

        /// <summary>
        /// Casts the Restore vita restoration spell on a target if the target has a vita percentage below
        /// than the specified threshold.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <param name="minimumVitaPercent">The vita percentage threshold below which a target
        /// becomes eligible for the spell.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RestoreIfBelowVitaPercent(GroupMember target, double minimumVitaPercent)
        {
            await _self.Activity.WaitForCommandCooldown();
            var targetVitaPercent = _self.Group.Vita.GetPercent(target.Position);

            return await RestoreIfBelowVitaPercent(target.Uid, target.Name, targetVitaPercent, minimumVitaPercent);
        }

        /// <summary>
        /// Iterates through the caster's group and casts the Restore vita restoration spell on the first
        /// group member found to be below the vita percentage threshold. The method will exit
        /// and return true as soon as the spell is cast on one group member. If no group members
        /// are eligible for the spell, the method will return false. The priority order is the
        /// caster, multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RestoreGroupIfBelowVitaPercent(double minimumVitaPercent)
        {
            if (await RestoreIfBelowVitaPercent(_self, minimumVitaPercent))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await RestoreIfBelowVitaPercent(multiboxMember, minimumVitaPercent))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await RestoreIfBelowVitaPercent(externalMember, minimumVitaPercent))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion RestoreIfBelowVitaPercent

        #region RestoreIfEligible

        /// <summary>
        /// Casts the Restore vita restoration spell on a target if the target has a vita deficit greater
        /// than the restoration amount of the spell.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RestoreIfEligible(TkClient target)
        {
            await _self.Activity.WaitForCommandCooldown();
            var targetVitaDeficit = target.Self.Vita.Deficit;

            return await RestoreIfEligible(target.Self.Uid, target.Self.Name, targetVitaDeficit);
        }

        /// <summary>
        /// Casts the Restore vita restoration spell on a target if the target has a vita deficit greater
        /// than the restoration amount of the spell.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RestoreIfEligible(GroupMember target)
        {
            await _self.Activity.WaitForCommandCooldown();
            var targetVitaDeficit = _self.Group.Vita.GetDeficit(target.Position);

            return await RestoreIfEligible(target.Uid, target.Name, targetVitaDeficit);
        }

        /// <summary>
        /// Iterates through the caster's group and casts the Restore vita restoration spell on the first
        /// group member found to have a vita deficit greater than the restoration amount of the
        /// spell. The method will exit and return true as soon as the spell is cast on one group
        /// member. If no group members are eligible for the spell, the method will return false.
        /// The priority order is the caster, multibox group members, and then external group members.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> RestoreGroupIfEligible()
        {
            if (await RestoreIfEligible(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await RestoreIfEligible(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await RestoreIfEligible(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion RestoreIfEligible

        #endregion Public Methods

        #region Private Methods

        private async Task<bool> Restore(uint targetUid, string targetName)
        {
            return await SpellCommands.CastAetheredTargetableSpell(_self, _restoreSpell, _self.Status.Restore, targetUid, targetName);
        }

        private async Task<bool> RestoreIfBelowVitaPercent(uint targetUid, string targetName, double targetVitaPercent, double minimumVitaPercent)
        {
            return targetVitaPercent < minimumVitaPercent.EvaluateAsPercentage() &&
                   await Restore(targetUid, targetName);
        }

        private async Task<bool> RestoreIfEligible(uint targetUid, string targetName, double targetVitaDeficit)
        {
            var restoreAmount = _self.Self.Mana.Current * 1.5;

            return targetVitaDeficit >= restoreAmount &&
                   await Restore(targetUid, targetName);
        }

        #endregion Private Methods
    }
}
