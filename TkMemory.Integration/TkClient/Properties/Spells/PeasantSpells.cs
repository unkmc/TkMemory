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
    /// Provides information about the spells currently known by a Peasant.
    /// </summary>
    public class PeasantSpells : TkSpells
    {
        #region Constructors

        /// <summary>
        /// Initializes a Peasant's spell data.
        /// </summary>
        /// <param name="classMemory">The application memory for the Peasant's game client.</param>
        public PeasantSpells(ClassMemory classMemory) : base(classMemory)
        {
            KeySpells = new PeasantKeySpells(Spells);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the key spells known to the Peasant.
        /// </summary>

        public PeasantKeySpells KeySpells { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spells known to the Peasant using the format used in-game for the a player's spell inventory.
        /// Also lists all key spells known to the Peasant.
        /// </summary>
        /// <returns>A string representation of all spells and key spells known to the Peasant.</returns>

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
