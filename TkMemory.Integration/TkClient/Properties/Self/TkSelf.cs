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

namespace TkMemory.Integration.TkClient.Properties.Self
{
    /// <summary>
    /// A collection of properties for getting information about the player being operated by
    /// the local game client.
    /// </summary>
    public class TkSelf
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes data specific to the player.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkSelf(ClassMemory classMemory)
        {
            _classMemory = classMemory;
            Mana = new SelfMana(_classMemory);
            Name = _classMemory.ReadString(TkAddresses.Self.Name, Constants.DefaultEncoding);
            Path = _classMemory.ReadString(TkAddresses.Self.Path, Constants.DefaultEncoding);
            Uid = _classMemory.Read<uint>(TkAddresses.Self.Uid);
            Vita = new SelfVita(_classMemory);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the base path (i.e. Mage, Poet, Rogue, or Warrior) of the player.
        /// </summary>
        public TkClient.BasePath BasePath { get; internal set; }

        /// <summary>
        /// Gets the amount of experience currently held by the player.
        /// </summary>
        public uint Exp => _classMemory.Read<uint>(TkAddresses.Self.Exp);

        /// <summary>
        /// Gets the amount of gold currently held by the player.
        /// </summary>
        public uint Gold => _classMemory.Read<uint>(TkAddresses.Self.Gold);

        /// <summary>
        /// Get the current level of the player.
        /// </summary>
        public byte Level => _classMemory.Read<byte>(TkAddresses.Self.Level);

        /// <summary>
        /// Gets information about a player's mana.
        /// </summary>
        public SelfMana Mana { get; }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the current path of the player. This may reflect a subpath and/or mark rank.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the UID of the player.
        /// </summary>
        public uint Uid { get; }

        /// <summary>
        /// Gets information about a player's vita.
        /// </summary>
        public SelfVita Vita { get; }

        #endregion Properties
    }
}
