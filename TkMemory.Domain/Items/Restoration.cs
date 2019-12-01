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
    /// An item that can be consumed to restore vitality or mana.
    /// </summary>
    public class Restoration : Item
    {
        #region Constructors

        /// <summary>
        /// Initializes a restoration item with its key properties.
        /// </summary>
        /// <param name="name">The name of the amount.</param>
        /// <param name="restoreAmount">The amount of vitality/mana that the item restores with each usage.</param>
        /// <param name="index">The numeric index of the position of the item within a player's inventory.</param>
        /// <param name="quantity">The current quantity of the item.</param>
        public Restoration(string name, int restoreAmount, int index = 0, int quantity = 0) : base(index, name, quantity)
        {
            RestoreAmount = restoreAmount;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The amount of vitality/mana that the item restores with each usage.
        /// </summary>
        public int RestoreAmount { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all item properties in a more consistent approximation of the format used in-game.
        /// Also outputs the restoration potency of the item.
        /// </summary>
        /// <returns>A string representation of all key properties of the item.</returns>
        public override string ToString()
        {
            return $"{base.ToString()} (Restores: {RestoreAmount:N0})";
        }

        #endregion Public Methods
    }
}
