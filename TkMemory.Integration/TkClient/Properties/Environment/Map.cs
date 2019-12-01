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
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties.Environment
{
    /// <summary>
    /// A collection of properties to describe the current map and the player's current position on it.
    /// </summary>
    public class Map
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's map data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public Map(ClassMemory classMemory)
        {
            _classMemory = classMemory;
            Coordinates = new Coordinates(_classMemory);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The coordinates of the player's current position on the current map.
        /// </summary>
        public Coordinates Coordinates { get; }

        /// <summary>
        /// The name of the current map.
        /// </summary>
        public string Name => _classMemory.ReadString(TkAddresses.Environment.Map.Name, Constants.DefaultEncoding);

        #endregion Properties
    }
}
