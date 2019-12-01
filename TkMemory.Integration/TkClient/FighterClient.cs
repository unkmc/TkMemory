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

using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Rogue or Warrior by reading the memory of the application.
    /// </summary>
    public class FighterClient : TkClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Rogue or Warrior.
        /// </summary>
        /// <param name="classMemory">The application memory for the Rogue's or Warrior's game client.</param>
        public FighterClient(ClassMemory classMemory) : base(classMemory) { }

        #endregion Constructors
    }
}
