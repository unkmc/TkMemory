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
    /// A spell known to the player that has aethers and is likely to be of relevance to a bot.
    /// </summary>
    public class AetheredKeySpell : KeySpell
    {
        #region Constructors

        /// <summary>
        /// Initialize a key spell with aethers with its key properties.
        /// </summary>
        /// <param name="unalignedName">The name of the spell before choosing an alignment.</param>
        /// <param name="alignedName">The name of the spell.</param>
        /// <param name="cost">The amount of mana required to cast the spell once.</param>
        /// <param name="aethers">The number of seconds after casting before the spell can be cast again.</param>
        /// <param name="index">The numeric index of the position of the item within a player's spell inventory.</param>
        public AetheredKeySpell(string unalignedName, string alignedName, int cost, int aethers, int index = 0) : base(unalignedName, alignedName, cost, index)
        {
            Aethers = aethers;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The number of seconds after casting before the spell can be cast again.
        /// </summary>
        public int Aethers { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spell properties using the format used in-game for a player's spell inventory.
        /// Also outputs the cost of the spell and its aethers.
        /// </summary>
        /// <returns>A string representation of all key properties of the aethered spell.</returns>
        public override string ToString()
        {
            return Aethers > 0
                ? base.ToString().Replace(")", $", Aethers: {Aethers:N0})")
                : base.ToString();
        }

        #endregion Public Methods
    }
}
