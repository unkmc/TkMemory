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

using System.Collections.Generic;
using System.Text;
using AutoHotkey.Interop.ClassMemory;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties.Spells
{
    /// <summary>
    /// Provides information about the spells currently known by a player.
    /// </summary>
    public abstract class TkSpells
    {
        #region Fields

        private const int MaxNumberOfSpells = 52;
        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's spell data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        protected TkSpells(ClassMemory classMemory)
        {
            _classMemory = classMemory;

            Spells = new List<Spell>();

            for (var i = 0; i < MaxNumberOfSpells; i++)
            {
                var name = GetName(i);

                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                Spells.Add(new Spell(i, name));
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the current spell inventory of the player.
        /// </summary>
        public List<Spell> Spells { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Gets the name of the spell at the specified position within the player's spell inventory.
        /// </summary>
        /// <param name="spellPosition">The zero-indexed position of the spell within the player's spell inventory.</param>
        /// <returns>The name of the spell at the specified position.</returns>
        public string GetName(int spellPosition)
        {
            var address = TkAddresses.Self.Spells.DisplayName;
            var offsets = address.Offsets.AddPositionOffset(spellPosition, TkAddresses.Self.Spells.PositionOffset);
            return _classMemory.ReadString(address.BaseAddress, offsets, Constants.DefaultEncoding);
        }

        /// <summary>
        /// Outputs all spells known to the player using the format used in-game for a player's spell inventory.
        /// </summary>
        /// <returns>A string representation of all spells known to the player.</returns>
        public override string ToString()
        {
            if (Spells == null || Spells.Count == 0)
            {
                return "No spells found.";
            }

            var sb = new StringBuilder();

            foreach (var spell in Spells)
            {
                sb.AppendLine(spell.ToString());
            }

            return sb.ToString();
        }

        #endregion Public Methods
    }
}
