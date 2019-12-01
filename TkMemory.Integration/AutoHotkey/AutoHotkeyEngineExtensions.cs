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

using System.Collections.Generic;
using System.Text;
using AutoHotkey.Interop;

namespace TkMemory.Integration.AutoHotkey
{
    /// <summary>
    /// Extension methods for the AutoHotkeyEngine object of the AutoHotkey.Interop library.
    /// </summary>
    public static class AutoHotkeyEngineExtensions
    {
        /// <summary>
        /// A convenience method for loading a collection of AutoHotkeyToggle objects into an instance of AutoHotkey.
        /// </summary>
        /// <param name="ahk">The instance of AutoHotkey into which to load the toggles.</param>
        /// <param name="toggles">A collection of AutoHotkeyToggle objects to load into AutoHotkey.</param>
        public static void LoadToggles(this AutoHotkeyEngine ahk, IEnumerable<AutoHotkeyToggle> toggles)
        {
            var sb = new StringBuilder();

            foreach (var toggle in toggles)
            {
                sb.AppendLine(toggle.GetDeclaration());
            }

            ahk.LoadScript(sb.ToString());
        }
    }
}
