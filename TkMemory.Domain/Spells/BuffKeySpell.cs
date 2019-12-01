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

using System.Text;

namespace TkMemory.Domain.Spells
{
    /// <summary>
    /// A spell known to the player that causes an effect with a duration and is likely to be of relevance to a bot.
    /// This could be a buff or a debuff, and it may or may not have aethers.
    /// </summary>
    public class BuffKeySpell : AetheredKeySpell
    {
        #region Constructors

        /// <summary>
        /// Initialize a key spell with its key properties.
        /// </summary>
        /// <param name="unalignedName">The name of the spell before choosing an alignment.</param>
        /// <param name="alignedName">The name of the spell.</param>
        /// <param name="cost">The amount of mana required to cast the spell once.</param>
        /// <param name="duration">The number of seconds that the effect created by the spell will remain in effect.</param>
        /// <param name="aethers">The number of seconds after casting before the spell can be cast again.</param>
        /// <param name="index">The numeric index of the position of the item within a player's spell inventory.</param>
        public BuffKeySpell(string unalignedName, string alignedName, int cost, int duration, int aethers = 0, int index = 0) : base(unalignedName, alignedName, cost, aethers, index)
        {
            Duration = duration;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The number of seconds that the effect created by the spell will remain in effect.
        /// </summary>
        public int Duration { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spell properties using the format used in-game for a player's spell inventory.
        /// Also outputs the cost of the spell, its aethers, and its duration.
        /// </summary>
        /// <returns>A string representation of all key properties of the buff/debuff.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString().Replace(")", ", "));

            if (Duration > 0)
            {
                sb.Append($"Duration: {Duration:N0}, ");
            }

            sb.Append(")");

            return sb.ToString().Replace(", )", ")");
        }

        #endregion Public Methods
    }
}
