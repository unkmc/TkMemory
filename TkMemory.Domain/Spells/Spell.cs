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
    /// A spell known to the player.
    /// </summary>
    public class Spell
    {
        #region Constructors

        /// <summary>
        /// Initializes a spell with its key properties.
        /// </summary>
        /// <param name="index">The numeric index of the position of the item within a player's spell inventory.</param>
        /// <param name="alignedName">The name of the spell.</param>
        public Spell(int index, string alignedName)
        {
            Letter = Infrastructure.Letter.Parse(index);
            AlignedName = alignedName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The alphabetic character that corresponds to the position of the spell within a player's spell inventory.
        /// </summary>
        public string Letter { get; }
        
        /// <summary>
        /// The name of the spell.
        /// </summary>
        public string AlignedName { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spell properties using the format used in-game for a player's spell inventory.
        /// </summary>
        /// <returns>A string representation of all key properties of the spell.</returns>
        public override string ToString()
        {
            return $"{Letter}: {AlignedName}";
        }

        #endregion Public Methods
    }
}
