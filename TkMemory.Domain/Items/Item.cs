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

namespace TkMemory.Domain.Items
{
    /// <summary>
    /// An item held by a player.
    /// </summary>
    public class Item
    {
        #region Fields

        private const int UpperBound = 26;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes an item with its key properties.
        /// </summary>
        /// <param name="index">The numeric index of the position of the item within a player's item inventory.</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="quantity">The current quantity of the item.</param>
        public Item(int index, string name, int quantity)
        {
            Letter = Infrastructure.Letter.Parse(index, UpperBound);
            Name = name;
            Quantity = quantity;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The alphabetic character that corresponds to the position of the item within a player's inventory.
        /// </summary>
        public string Letter { get; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The current quantity of the item.
        /// </summary>
        public int Quantity { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all item properties in a more consistent approximation of the format used in-game.
        /// </summary>
        /// <returns>A string representation of all key properties of the item.</returns>
        public override string ToString()
        {
            return $"{Letter}: {Name} ({Quantity})";
        }

        #endregion Public Methods
    }
}
