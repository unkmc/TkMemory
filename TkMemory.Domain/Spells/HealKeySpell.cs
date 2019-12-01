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

namespace TkMemory.Domain.Spells
{
    /// <summary>
    /// A heal spell known to the player that is likely to be of relevance to a bot.
    /// </summary>
    public class HealKeySpell : KeySpell
    {
        #region Constructors

        /// <summary>
        /// Initialize a heal spell with its key properties.
        /// </summary>
        /// <param name="unalignedName">The name of the spell before choosing an alignment.</param>
        /// <param name="alignedName">The name of the spell.</param>
        /// <param name="cost">The amount of mana required to cast the spell once.</param>
        /// <param name="vita">The amount of vitality that is restored by a single casting of the spell.</param>
        /// <param name="index">The numeric index of the position of the item within a player's spell inventory.</param>
        public HealKeySpell(string unalignedName, string alignedName, int cost, int vita, int index = 0) : base(unalignedName, alignedName, cost, index)
        {
            Vita = vita;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The amount of vitality that is restored by a single casting of the spell.
        /// </summary>
        public int Vita { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spell properties using the format used in-game for a player's spell inventory.
        /// Also outputs the cost of the spell and the amount of vita the spell restores with each usage.
        /// </summary>
        /// <returns>A string representation of all key properties of the heal spell.</returns>
        public override string ToString()
        {
            return $"{base.ToString()}, Vita: {Vita:N0})".Replace("), ", ", ");
        }

        #endregion Public Methods
    }
}
