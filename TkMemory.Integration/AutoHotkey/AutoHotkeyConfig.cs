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

namespace TkMemory.Integration.AutoHotkey
{
    /// <summary>
    /// Contains recommendations for configuration settings of AutoHotkey.
    /// </summary>
    public static class AutoHotkeyConfig
    {
        /// <summary>
        /// Default settings recommended for all instances of AutoHotkey.
        /// </summary>
        public const string DefaultConfig = @"
#NoEnv ; Recommended for performance and compatibility with future AutoHotkey releases.
#InstallMouseHook ; Enables mouse buttons as hotkey triggers.
#SingleInstance force ; Ensures only a single instance of the script is running at any given time.

ListLines Off ; Disables logging of executed lines in history.
SetBatchLines -1 ; Runs script at maximum speed.
SetKeyDelay, 0, 0 ; Sends keys at maximum speed.
SetWorkingDir %A_ScriptDir% ; Ensures a consistent starting directory.

; Sets coordinate modes for various commands to be relative to either the active window or the screen
CoordMode, Mouse, Client 
CoordMode, Pixel, Screen 
CoordMode, ToolTip, Screen
";
    }
}
