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
using Serilog.Events;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Npcs;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Commands
{
    internal static class SpellCommands
    {
        #region Fields

        private const int SecondaryInputDelay = 80;

        #endregion Fields

        #region Public Methods

        public static async Task<bool> CastSpell(
            TkClient caster,
            KeySpell spell,
            bool isLowCostSpell = false,
            string targetName = null,
            string secondaryInput = null)
        {
            if (spell == null)
            {
                return false;
            }

            if (spell.Cost == 0)
            {
                // Do not bother checking to see if a mana restoration item is needed.
            }

            else if (isLowCostSpell)
            {
                await ItemCommands.RestoreMinorManaForSpell(caster, spell);
            }

            else
            {
                await ItemCommands.RestoreMajorManaForSpell(caster, spell);
            }

            caster.Send($"{Keys.Esc}Z");

            if (!string.IsNullOrWhiteSpace(secondaryInput))
            {
                await Task.Delay(SecondaryInputDelay);
                caster.Send(spell.Letter);
                await Task.Delay(SecondaryInputDelay);
                caster.Send(secondaryInput);
            }

            else
            {
                caster.Send(spell.Letter);
            }

            if (!string.IsNullOrWhiteSpace(targetName) || !string.IsNullOrWhiteSpace(secondaryInput))
            {
                caster.Send($"{Keys.Enter}");
            }

            caster.Activity.ResetCommandCooldown();

            // ReSharper disable once InvertIf
            if (Log.IsEnabled(LogEventLevel.Information))
            {
                var logMessage = $"{caster.Self.Name} cast {spell.DisplayName}.";

                if (!string.IsNullOrWhiteSpace(targetName))
                {
                    logMessage = logMessage.Replace(".", $" on {targetName}.");
                }

                if (!string.IsNullOrWhiteSpace(secondaryInput))
                {
                    logMessage = logMessage.Replace(".", $" using \"{secondaryInput}\".");
                }

                Log.Information(logMessage);
            }

            return true;
        }

        public static async Task<bool> CastAetheredSpell(
            TkClient caster,
            KeySpell spell,
            BuffStatus status,
            bool isLowCostSpell = false)
        {
            if (status.IsActive)
            {
                return false;
            }

            var didCastSpell = await CastSpell(caster, spell, isLowCostSpell);

            if (didCastSpell)
            {
                status.ResetStatusCooldown();
            }

            return didCastSpell;
        }

        public static async Task<bool> CastInvisibleSpell(
            TkClient caster,
            KeySpell spell,
            InvisibleStatus status)
        {
            var didCastSpell = await CastSpell(caster, spell, true);

            if (didCastSpell)
            {
                status.ResetStatusCooldown();
            }

            return didCastSpell;
        }

        public static async Task<bool> CastTargetableSpell(
            TkClient caster,
            KeySpell spell,
            uint targetUid,
            string targetName,
            bool isLowCostSpell = false)
        {
            if (spell == null || await caster.IsTargetOffScreen(targetUid, spell))
            {
                return false;
            }

            return await CastSpell(caster, spell, isLowCostSpell, targetName);
        }

        public static async Task<bool> CastTargetableSpell(
            TkClient caster,
            KeySpell spell,
            Npc target,
            bool isLowCostSpell = false)
        {
            if (await CastTargetableSpell(caster, spell, target.Uid, $"NPC {target.Uid}", isLowCostSpell))
            {
                return true;
            }

            if (spell != null) // Indicates that the target is off-screen without having to repeat the relatively inefficient IsTargetOffScreen() check
            {
                caster.Npcs.Remove(target);
            }

            return false;
        }

        public static async Task<bool> CastAetheredTargetableSpell(
            TkClient caster,
            KeySpell spell,
            BuffStatus status,
            uint targetUid,
            string targetName,
            bool isLowCostSpell = false)
        {
            if (status.IsActive)
            {
                return false;
            }

            var didCastSpell = await CastTargetableSpell(caster, spell, targetUid, targetName, isLowCostSpell);

            if (didCastSpell)
            {
                status.ResetStatusCooldown();
            }

            return didCastSpell;
        }

        public static async Task<bool> CastAetheredTargetableSpell(
            TkClient caster,
            KeySpell spell,
            BuffStatus status,
            Npc target,
            bool isLowCostSpell = false)
        {
            if (await CastAetheredTargetableSpell(caster, spell, status, target.Uid, $"NPC {target.Uid}", isLowCostSpell))
            {
                return true;
            }

            if (spell != null) // Indicates that the target is off-screen without having to repeat the relatively inefficient IsTargetOffScreen() check
            {
                caster.Npcs.Remove(target);
            }

            return false;
        }

        public static async Task<bool> CastRage(
            TkClient caster,
            KeySpell spell,
            RageStatus status)
        {
            if (status.IsActive)
            {
                return false;
            }

            var didCastSpell = await CastSpell(caster, spell);

            // ReSharper disable once InvertIf
            if (didCastSpell)
            {
                status.ResetStatusCooldown();
                status.CurrentRageLevel++;
            }

            return didCastSpell;
        }

        #endregion Public Methods
    }
}
