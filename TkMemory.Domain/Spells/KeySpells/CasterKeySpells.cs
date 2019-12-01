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
    /// A collection of key spells known to a player who is either a Mage or Poet.
    /// </summary>
    public abstract class CasterKeySpells : PeasantKeySpells
    {
        #region Constructors

        protected CasterKeySpells(List<Spell> spells) : base(spells)
        {
            CureParalysis = GetKeySpellByPriority(Priorities.Caster.CureParalysis);
            HardenArmor = GetBuffKeySpellByPriority(Priorities.Caster.HardenArmor);
            Invoke = GetKeySpellByPriority(Priorities.Caster.Invoke);
            Purge = GetKeySpellByPriority(Priorities.Caster.Purge);
            RemoveCurse = GetKeySpellByPriority(Priorities.Caster.RemoveCurse);
            Sanctuary = GetBuffKeySpellByPriority(Priorities.Caster.Sanctuary);
            Valor = GetBuffKeySpellByPriority(Priorities.Caster.Valor);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Removes paralysis debuffs from the target.
        /// </summary>
        public KeySpell CureParalysis { get; }

        /// <summary>
        /// Lowers a target's defense.
        /// </summary>
        public BuffKeySpell Curse { get; protected set; }

        /// <summary>
        /// Increases a target's defense.
        /// </summary>
        public BuffKeySpell HardenArmor { get; }

        /// <summary>
        /// Restores mana at the cost of vitality.
        /// </summary>
        public KeySpell Invoke { get; }

        /// <summary>
        /// Removes poison debuffs from the target.
        /// </summary>
        public KeySpell Purge { get; }

        /// <summary>
        /// Removes Vex debuffs from the target.
        /// </summary>
        public KeySpell RemoveCurse { get; }

        /// <summary>
        /// Reduces damage taken by the target by half.
        /// </summary>
        public BuffKeySpell Sanctuary { get; }

        /// <summary>
        /// Increases the Might of the target by 3.
        /// </summary>
        public BuffKeySpell Valor { get; }

        #endregion Properties
    }
}
