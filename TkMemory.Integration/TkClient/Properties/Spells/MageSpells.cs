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
using AutoHotkey.Interop.ClassMemory;
using TkMemory.Domain.Spells.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Spells
{
    /// <summary>
    /// Provides information about the spells currently known by a Mage.
    /// </summary>
    public class MageSpells : TkSpells
    {
        #region Constructors

        /// <summary>
        /// Initializes a Mage's spell data.
        /// </summary>
        /// <param name="classMemory">The application memory for the Mage's game client.</param>
        public MageSpells(ClassMemory classMemory) : base(classMemory)
        {
            KeySpells = new MageKeySpells(Spells);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the key spells known to the Mage.
        /// </summary>
        public MageKeySpells KeySpells { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spells known to the Mage using the format used in-game for the a player's spell inventory.
        /// Also lists all key spells known to the Mage.
        /// </summary>
        /// <returns>A string representation of all spells and key spells known to the Mage.</returns>

        public override string ToString()
        {
            if (Spells == null || Spells.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(KeySpells.ToString());

            return sb.ToString();
        }

        #endregion Public Methods
    }
}
