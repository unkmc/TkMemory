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

namespace TkMemory.Domain.Spells.KeySpells
{
    /// <summary>
    /// A collection of trap spells known to a Rogue.
    /// </summary>
    public class SetTrapKeySpells : PeasantKeySpells
    {
        #region Constructors

        /// <summary>
        /// Initializes trap spell inventory by scanning the player's spell inventory by trap spell priority.
        /// </summary>
        /// <param name="spells">A list of all trap spells possessed by the player.</param>
        public SetTrapKeySpells(List<Spell> spells) : base(spells)
        {
            Dart = GetKeySpellByPriority(Priorities.Rogue.SetTrap.Dart);
            Flash = GetKeySpellByPriority(Priorities.Rogue.SetTrap.Flash);
            RepeatingDart = GetKeySpellByPriority(Priorities.Rogue.SetTrap.RepeatingDart);
            Snare = GetBuffKeySpellByPriority(Priorities.Rogue.SetTrap.Snare);
            Spear = GetKeySpellByPriority(Priorities.Rogue.SetTrap.Spear);
            PoisonDart = GetBuffKeySpellByPriority(Priorities.Rogue.SetTrap.PoisonDart);
            Death = GetKeySpellByPriority(Priorities.Rogue.SetTrap.Death);
            Sleep = GetBuffKeySpellByPriority(Priorities.Rogue.SetTrap.Sleep);
            Bladestorm = GetBuffKeySpellByPriority(Priorities.Rogue.SetTrap.Bladestorm);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 500 damage at 0 AC.
        /// </summary>
        public KeySpell Dart { get; }

        /// <summary>
        /// Causes temporary blindness.
        /// </summary>
        public KeySpell Flash { get; }

        /// <summary>
        /// 500 damage at 0 AC. Trap remains for a short period and can be triggered multiple times.
        /// </summary>
        public KeySpell RepeatingDart { get; }

        /// <summary>
        /// Increases AC (i.e. decreases defense) by 20 points.
        /// </summary>
        public BuffKeySpell Snare { get; }

        /// <summary>
        /// 3,500 damage at 0 AC.
        /// </summary>
        public KeySpell Spear { get; }

        /// <summary>
        /// Temporarily poisons the target for 1,000 vita in damage per second.
        /// </summary>
        public BuffKeySpell PoisonDart { get; }

        /// <summary>
        /// 11,650 damage at 0 AC.
        /// </summary>
        public KeySpell Death { get; }

        /// <summary>
        /// Puts target to sleep for 1.3x damage on next attack.
        /// </summary>
        public BuffKeySpell Sleep { get; }

        /// <summary>
        /// Drains 5,000 mana every second for its duration unless the rogue switches server. Trap remains for 20 seconds,
        /// even if the rogue's mana hits zero. The first person who walks on the trap will cast an Assault attack. Trap
        /// cannot be seen by spot traps. Player (PK) - Takes 50% of player's vita. Attacks secondary targets with that
        /// much vita at 0 AC. No effect outside of PK areas. Creature - Takes 75% of player's vita. Attacks secondary
        /// targets with that much vita at 0 AC. Will not harm players. After casting assault, the spell does an additional
        /// 35,000 damage at 0 AC.
        /// </summary>
        public BuffKeySpell Bladestorm { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Generates a string representation of a player's trap spell inventory.
        /// </summary>
        /// <returns>A list of trap spells possessed by the player.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Set Traps:");
            sb.AppendLine($" Dart => {Dart?.ToString() ?? "Empty"}");
            sb.AppendLine($" Flash => {Flash?.ToString() ?? "Empty"}");
            sb.AppendLine($" Repeating Dart => {RepeatingDart?.ToString() ?? "Empty"}");
            sb.AppendLine($" Snare => {Snare?.ToString() ?? "Empty"}");
            sb.AppendLine($" Spear => {Spear?.ToString() ?? "Empty"}");
            sb.AppendLine($" Poison Dart => {PoisonDart?.ToString() ?? "Empty"}");
            sb.AppendLine($" Death => {Death?.ToString() ?? "Empty"}");
            sb.AppendLine($" Sleep => {Sleep?.ToString() ?? "Empty"}");
            sb.AppendLine($" Bladestorm => {Bladestorm?.ToString() ?? "Empty"}");

            return sb.ToString();
        }

        #endregion Public Methods
    }
}
