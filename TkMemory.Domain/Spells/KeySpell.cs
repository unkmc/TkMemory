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

namespace TkMemory.Domain.Spells
{
    /// <summary>
    /// A spell known to the player that is likely to be of relevance to a bot.
    /// </summary>
    public class KeySpell : Spell
    {
        #region Constructors

        /// <summary>
        /// Initialize a key spell with its key properties.
        /// </summary>
        /// <param name="unalignedName">The original name of the spell when no alignment has been chosen.</param>
        /// <param name="alignedName">The name of the spell.</param>
        /// <param name="cost">The amount of mana required to cast the spell once.</param>
        /// <param name="index">The numeric index of the position of the item within a player's spell inventory.</param>
        public KeySpell(string unalignedName, string alignedName, int cost, int index = 0) : base(index, alignedName)
        {
            UnalignedName = unalignedName;
            Cost = cost;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The amount of mana required to cast the spell once.
        /// </summary>
        public int Cost { get; }

        /// <summary>
        /// Gets the unaligned name of the spell with its aligned name following in parentheses.
        /// </summary>
        public string DisplayName => GetDisplayName();

        /// <summary>
        /// The original name of the spell when no alignment has been chosen.
        /// </summary>
        public string UnalignedName { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spell properties using the format used in-game for a player's spell inventory.
        /// Also outputs the cost of the spell.
        /// </summary>
        /// <returns>A string representation of all key properties of the key spell.</returns>
        public override string ToString()
        {
            return $"{base.ToString()} (Cost: {Cost:N0})";
        }

        #endregion Public Methods

        #region Private Methods

        private string GetDisplayName()
        {
            var alignedName = AlignedName
                .Replace("Dispell", "Dispel")
                .Replace("Baekho's Cunning", string.Empty)
                .Replace("Chung Ryong's Rage", string.Empty)
                .Replace("Call of the Wild (", string.Empty)
                .Replace(")", string.Empty);

            if (string.Equals(UnalignedName, alignedName, StringComparison.OrdinalIgnoreCase))
            {
                alignedName = string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(alignedName))
            {
                alignedName = $" ({alignedName})";
            }

            return UnalignedName + alignedName;
        }

        #endregion Private Methods
    }
}
