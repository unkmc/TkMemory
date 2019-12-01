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
using AutoHotkey.Interop.ClassMemory;
using TkMemory.Integration.TkClient.Infrastructure;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Entity
{
    /// <summary>
    /// This class reads memory space that contains data about entities that are on-screen.
    /// Entities include other players and NPCs. While this was initially thought to be a
    /// useful means of tracking NPCs solely via memory reads, this data is not updated
    /// consistently, and cached data will misrepresent the current state more often than not.
    /// The UpdateNpcs() method of the TkClient class is a far more effective method of
    /// tracking NPCs. It uses minimal simulated user input to derive the same data intended
    /// to be supplied by this class, and the efficiency cost of that simulated user input
    /// has proven to be far more acceptable than the difficulty of using this class.
    /// </summary>
    [Obsolete("This class is obsolete. Use TkClient method UpdateNpcs() instead.", false)]
    public class TkEntity
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes the entity data for an NPC or player. 
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkEntity(ClassMemory classMemory)
        {
            _classMemory = classMemory;
            Coordinates = new Coordinates(_classMemory);
            Pixels = new Pixels(_classMemory);
        }

        #endregion Constructors

        #region Enums

        /// <summary>
        /// Indicates the direction that an NPC or player is facing.
        /// </summary>
        public enum FacingDirection { Up = 0, Right = 1, Down = 2, Left = 3 }

        #endregion Enums

        #region Properties

        /// <summary>
        /// The position coordinates of the NPC or player on the current map.
        /// </summary>
        public Coordinates Coordinates { get; }

        /// <summary>
        /// The number of players currently on the screen. NPCs are not included.
        /// </summary>
        public int PlayerCount => _classMemory.Read<int>(TkAddresses.Entity.Count);

        /// <summary>
        /// The pixel position coordinates of the NPC or player on the screen.
        /// </summary>
        public Pixels Pixels { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Gets the direction in which an NPC or player is facing.
        /// </summary>
        /// <param name="entityIndex">The index of the NPC or player within the list of entities in the application's memory.</param>
        /// <returns>The direction in which an NPC or player is facing.</returns>
        public FacingDirection GetFacingDirection(int entityIndex)
        {
            var address = TkAddresses.Entity.Direction;
            var offsets = address.Offsets.AddPositionOffset(entityIndex, TkAddresses.Entity.PositionOffset);
            return (FacingDirection)_classMemory.Read<short>(address.BaseAddress, offsets);
        }

        /// <summary>
        /// Gets the name of the NPC or player. If the entity is an NPC, there will be no value for its name.
        /// </summary>
        /// <param name="entityIndex">The index of the NPC or player within the list of entities in the application's memory.</param>
        /// <returns>The name of the NPC or player.</returns>
        public string GetName(int entityIndex)
        {
            var address = TkAddresses.Entity.Name;
            var offsets = address.Offsets.AddPositionOffset(entityIndex, TkAddresses.Entity.PositionOffset);
            return _classMemory.ReadString(address.BaseAddress, offsets, Constants.DefaultEncoding);
        }

        /// <summary>
        /// Gets the UID of the NPC or player.
        /// </summary>
        /// <param name="entityIndex">The index of the NPC or player within the list of entities in the application's memory.</param>
        /// <returns>The UID of the NPC or player.</returns>
        public uint GetUid(int entityIndex)
        {
            var address = TkAddresses.Entity.Uid;
            var offsets = address.Offsets.AddPositionOffset(entityIndex, TkAddresses.Entity.PositionOffset);
            return _classMemory.Read<uint>(address.BaseAddress, offsets);
        }

        #endregion Public Methods
    }
}
