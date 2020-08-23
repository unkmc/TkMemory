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

using System;
using System.Threading.Tasks;
using AutoHotkey.Interop;
using Serilog;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;

// ReSharper disable once CyclomaticComplexity

namespace TkMemory.Application
{
    /// <summary>
    /// A sample bot to demonstrate and test the mechanics of using the TkMemory library.
    /// </summary>
    internal class DemoBot
    {
        #region Fields

        private readonly PoetClient _poet;
        private readonly ActiveClients _clients;

        private readonly AutoHotkeyToggle _isBotRunning;
        private readonly AutoHotkeyToggle _isBotPaused;
        private readonly AutoHotkeyToggle _shouldEsunaExternalGroupMembers;
        private readonly AutoHotkeyToggle _shouldRing;
        private readonly AutoHotkeyToggle _shouldGate;
        private readonly AutoHotkeyToggle _shouldReturn;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes settings and defines hotkeys.
        /// </summary>
        public DemoBot()
        {
            TkBotFactory.Initialize();

            _clients = new ActiveClients(TkBotFactory.ProcessName);
            //Log.Information("Got list of clients");

            _poet = _clients.GetPoet();
            _poet.Activity.DefaultCommandCooldown = TkBotFactory.CommandCooldown;

            _isBotRunning = new AutoHotkeyToggle("^F2", "isBotRunning", true);
            _isBotPaused = new AutoHotkeyToggle("F2", "isBotPaused", false);
            _shouldEsunaExternalGroupMembers = new AutoHotkeyToggle("F12", "shouldEsunaExternalGroupMembers", false);
            _shouldRing = new AutoHotkeyToggle("NumpadDiv", "shouldRing", false);
            _shouldGate = new AutoHotkeyToggle("^NumpadDiv", "shouldGate", false);
            _shouldReturn = new AutoHotkeyToggle("!NumpadDiv", "shouldReturn", false);

            var toggles = new[]
            {
                _isBotRunning,
                _isBotPaused,
                _shouldEsunaExternalGroupMembers,
                _shouldRing,
                _shouldGate,
                _shouldReturn
            };

            var ahk = AutoHotkeyEngine.Instance;
            ahk.LoadToggles(toggles);
            ahk.LoadScript("NumpadAdd::Send {Ctrl down},{Ctrl up}");
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Defines and executes the logic of the bot. Lines in the try statement can be
        /// rearranged to tweak the logic, or commands can be added/removed for significantly
        /// different bot behavior.
        /// </summary>
        public async Task AutoHunt()
        {
            Log.Information($"Starting Poet bot for {_poet.Self.Name}...");

            while (_isBotRunning.Value)
            {
                try
                {
                    if (_isBotPaused.Value) continue;
                    _poet.UpdateGroup(_clients);
                    if (await Return()) continue;
                    if (await Gate()) continue;
                    if (await Ring()) continue;
                    MarkExternalGroupMembersForEsuna();
                    if (await _poet.Commands.Mana.Invoke(20)) continue;
                    if (await _poet.Commands.Heal.RestoreGroupIfEligible()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfBelowVitaPercent(20)) continue;
                    if (await _poet.Commands.Asv.SanctuaryGroup()) continue;
                    if (await _poet.Commands.Debuffs.AtoneGroup()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfBelowVitaPercent(30)) continue;
                    if (await _poet.Commands.Debuffs.RemoveCurseGroup()) continue;
                    if (await _poet.Commands.Debuffs.CureParalysisGroup()) continue;
                    if (await _poet.Commands.Debuffs.PurgeGroup()) continue;
                    if (await _poet.Commands.Asv.HardenArmorGroup()) continue;
                    if (await _poet.Commands.Debuffs.CurseNpcs()) continue;
                    if (await _poet.UpdateNpcs(_poet.Spells.KeySpells.Heal)) continue;
                    if (await _poet.Commands.Debuffs.RemoveVeilGroup()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfEligible()) continue;
                    if (await _poet.Commands.Asv.ValorGroup()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfBelowVitaPercent(90)) continue;
                    if (await _poet.Commands.Mana.InspireGroup(75)) continue;
                    await _poet.Commands.HardenBody();
                }

                catch (Exception ex)
                {
                    TkBotFactory.LogException(ex);
                }
            }

            Log.Information($"Shutting down Poet bot for {_poet.Self.Name}...");
            TkBotFactory.Terminate(_poet);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<bool> Gate()
        {
            if (!_shouldGate.Value)
            {
                return false;
            }

            _shouldGate.Value = false;
            return await _poet.Commands.Gateway(PeasantCommands.Gate.South);
        }

        private void MarkExternalGroupMembersForEsuna()
        {
            if (!_shouldEsunaExternalGroupMembers.Value)
            {
                return;
            }

            _shouldEsunaExternalGroupMembers.Value = false;
            _poet.MarkExternalGroupMembersForEsuna();
        }

        private async Task<bool> Return()
        {
            if (!_shouldReturn.Value)
            {
                return false;
            }

            _shouldReturn.Value = false;
            return await _poet.Commands.Items.UseYellowScroll();
        }

        private async Task<bool> Ring()
        {
            if (!_shouldRing.Value)
            {
                return false;
            }

            _shouldRing.Value = false;
            return await _poet.Commands.Items.UseRing();
        }

        #endregion Private Methods
    }
}
