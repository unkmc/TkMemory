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
using System.Configuration;
using System.Diagnostics;
using AutoHotkey.Interop;
using Serilog;
using Serilog.Events;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;

namespace TkMemory.Application
{
    /// <summary>
    /// Used to initialize/terminate bots using recommended settings.
    /// </summary>
    internal static class TkBotFactory
    {
        #region Fields

        private const int DefaultCommandCooldown = 333;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Name of the executable for the game (without the extension).
        /// </summary>
        public static string ProcessName => ConfigurationManager.AppSettings["ProcessName"];

        /// <summary>
        /// Number of milliseconds to wait between commands. Good private servers can handle as low as 333 and run very
        /// efficiently without errors, but less responsive servers may require up to 1,000 to avoid missed commands.
        /// </summary>
        public static int CommandCooldown => int.TryParse(ConfigurationManager.AppSettings["DefaultCommandCooldown"], out var result)
            ? result
            : DefaultCommandCooldown;

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Initialize the bot and logging with recommended settings.
        /// </summary>
        public static void Initialize()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();

            var ahk = AutoHotkeyEngine.Instance;
            ahk.LoadScript(AutoHotkeyConfig.DefaultConfig);

            if (!Log.IsEnabled(LogEventLevel.Information))
            {
                return;
            }

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            var name = assembly.GetName().Name;
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fvi.FileVersion;
            Log.Information($"Starting {name} Version {version}...");
        }

        /// <summary>
        /// Logs any exception in a standardized format.
        /// </summary>
        /// <param name="ex">The exception that was thrown.</param>
        public static void LogException(Exception ex)
        {
            Log.Error($"{ex.GetType()}: {ex.Message}\n{ex.StackTrace}");
        }

        /// <summary>
        /// Terminates the bot in exceptional circumstances.
        /// </summary>
        /// <param name="ex">The exception that was thrown.</param>
        public static void Terminate(Exception ex)
        {
            LogException(ex);
            Terminate();
        }

        /// <summary>
        /// Terminates the bot with experience and mana restoration item usage reports.
        /// </summary>
        /// <param name="client">The TkClient controlled by the bot.</param>
        public static void Terminate(TkClient client)
        {
            Log.Information(client.GetExpReport());
            Log.Information(client.GetManaRestorationItemUsageReport());
            Terminate();
        }

        #endregion Public Methods

        #region Private Methods

        private static void Terminate()
        {
            Console.WriteLine();
            Console.WriteLine(@"Press ""Esc"" to exit...");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

            Environment.Exit(0);
        }

        #endregion Private Methods
    }
}
