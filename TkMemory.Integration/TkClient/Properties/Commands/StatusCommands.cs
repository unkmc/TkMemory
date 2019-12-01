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
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Commands
{
    internal static class StatusCommands
    {
        #region Public Methods

        public static async Task<bool> CastDebuffCure(TkClient caster, TkClient target, DebuffStatus status, KeySpell debuffCureSpell)
        {
            if (!status.IsActive)
            {
                return false;
            }

            if (!await CastStatus(caster, target.Self.Uid, target.Self.Name, debuffCureSpell)) // Do not combine with the IsActive condition
            {
                return false;
            }

            status.ResetStatusCooldown();
            return true;
        }

        public static async Task<bool> CastDebuffCure(TkClient caster, GroupMember target, GroupMemberDebuffActivity activity, KeySpell debuffCureSpell)
        {
            if (!activity.IsActive)
            {
                return false;
            }

            if (!await CastStatus(caster, target.Uid, target.Name, debuffCureSpell)) // Do not combine with the IsActive condition
            {
                return false;
            }

            activity.IsActive = false;
            return true;
        }

        public static async Task<bool> CastStatus(TkClient caster, TkClient target, BuffStatus status, KeySpell statusEffectSpell)
        {
            if (status.IsActive || !await CastStatus(caster, target.Self.Uid, target.Self.Name, statusEffectSpell))
            {
                return false;
            }

            status.ResetStatusCooldown();
            return true;
        }

        public static async Task<bool> CastStatus(TkClient caster, GroupMember target, GroupMemberBuffActivity activity, KeySpell statusEffectSpell)
        {
            if (activity.IsActive || !await CastStatus(caster, target.Uid, target.Name, statusEffectSpell))
            {
                return false;
            }

            activity.ResetTimer();
            return true;
        }

        public static async Task<bool> CastStatus(TkClient caster, Npc target, NpcDebuffActivity activity, KeySpell statusEffectSpell)
        {
            if (activity.IsActive)
            {
                return false;
            }

            if (!await CastStatus(caster, target.Uid, $"NPC {target.Uid}", statusEffectSpell))
            {
                if (statusEffectSpell != null) // Indicates that the target is off-screen without having to repeat the relatively inefficient IsTargetOffScreen() check
                {
                    caster.Npcs.Remove(target);
                }

                return false;
            }

            activity.ResetTimer();
            return true;
        }

        #endregion Public Methods

        #region Private Methods

        private static async Task<bool> CastStatus(TkClient caster, uint targetUid, string targetName, KeySpell statusEffectSpell)
        {
            return await SpellCommands.CastTargetableSpell(caster, statusEffectSpell, targetUid, targetName);
        }

        #endregion Private Methods
    }
}
