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

namespace TkMemory.Integration.TkClient.Properties.Self
{
    /// <summary>
    /// A collection of properties for getting information about a player's vita.
    /// </summary>
    public class SelfVita
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's vita data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public SelfVita(ClassMemory classMemory)
        {
            _classMemory = classMemory;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the current vita of the player.
        /// </summary>
        public uint Current => _classMemory.Read<uint>(TkAddresses.Self.Vita.Current);

        /// <summary>
        /// Gets the difference between the maximum vita and current vita of the player.
        /// </summary>
        public uint Deficit => Max - Current;

        /// <summary>
        /// Gets the maximum vita of the player.
        /// </summary>
        public uint Max => _classMemory.Read<uint>(TkAddresses.Self.Vita.Max);

        /// <summary>
        /// Gets the percentage of current vita to max vita of the player.
        /// </summary>
        public double Percent => (float) Current / Max;

        #endregion Properties
    }
}
