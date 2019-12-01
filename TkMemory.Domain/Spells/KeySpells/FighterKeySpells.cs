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

namespace TkMemory.Domain.Spells.KeySpells
{
    /// <summary>
    /// A collection of key spells known to a player who is either a Rogue or Warrior.
    /// </summary>
    public abstract class FighterKeySpells : PeasantKeySpells
    {
        #region Constructors

        protected FighterKeySpells(List<Spell> spells) : base(spells) { }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Increases the damage and attack of a weapon. It lasts until you take a weapon off or log off the game.
        /// </summary>
        public KeySpell Enchant { get; protected set; }

        /// <summary>
        /// Multiplies attack damage.
        /// </summary>
        public BuffKeySpell Fury { get; protected set; }

        /// <summary>
        /// Incremental attack damage multiplier.
        /// </summary>
        public BuffKeySpell Rage { get; protected set; }

        /// <summary>
        /// Restores one's own mana over time.
        /// </summary>
        public BuffKeySpell RegenerateMana { get; protected set; }

        /// <summary>
        /// Identifies hidden traps with an onscreen icon.
        /// </summary>
        public AetheredKeySpell SpotTraps { get; protected set; }

        #endregion Properties
    }
}
