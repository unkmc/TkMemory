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

namespace TkMemory.Integration.TkClient.Properties.Environment
{
    /// <summary>
    /// A collection of properties to describe the current environment and the player's current position within it.
    /// </summary>
    public class TkEnvironment
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's environmental data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkEnvironment(ClassMemory classMemory)
        {
            _classMemory = classMemory;
            Map = new Map(_classMemory);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Data about the current map and the player's current position on it.
        /// </summary>
        public Map Map { get; }

        /// <summary>
        /// The current in-game time.
        /// </summary>
        public ushort Time => _classMemory.Read<ushort>(TkAddresses.Environment.Time);

        #endregion Properties
    }
}
