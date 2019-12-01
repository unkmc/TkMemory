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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TkMemory.Domain.Infrastructure;

namespace TkMemory.Domain.Spells.KeySpells
{
    /// <summary>
    /// A collection of key spells known to a player of any path.
    /// </summary>
    public abstract class PeasantKeySpells
    {
        #region Fields

        protected readonly List<Spell> Spells;

        #endregion Fields

        #region Constructors

        protected PeasantKeySpells(List<Spell> spells)
        {
            Spells = spells;

            Approach = GetKeySpellByPriority(Priorities.Peasant.Approach);
            Gateway = GetKeySpellByPriority(Priorities.Peasant.Gateway);
            Summon = GetKeySpellByPriority(Priorities.Peasant.Summon);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Used to teleport to people. Person must be in an area that allows approaching, citizenship in the same kingdom,
        /// and be in your group to approach or else a "Fizzle" message is seen.
        /// </summary>
        public KeySpell Approach { get; }

        /// <summary>
        /// Teleport to North, South, East, or West Gate.
        /// </summary>
        public KeySpell Gateway { get; }

        /// <summary>
        /// Targetable spell to restore vitality.
        /// </summary>
        public HealKeySpell Heal { get; protected set; }

        /// <summary>
        /// Non-targetable spell to restore vitality of oneself.
        /// </summary>
        public HealKeySpell HealSelf { get; protected set; }

        /// <summary>
        /// Used to teleport people to you. Person must be in an area that allows approaching, citizenship in the same kingdom,
        /// and be in your group to approach or else a "Fizzle" message is seen.
        /// </summary>
        public KeySpell Summon { get; }

        /// <summary>
        /// Targetable lightning attack.
        /// </summary>
        public KeySpell Zap { get; protected set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Generates a string representation of a player's key spell inventory.
        /// </summary>
        /// <returns>A list of key spells known to the player.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var propertyInfo in GetType().GetProperties())
            {
                if (propertyInfo.Name == "SetTrap")
                {
                    continue;
                }

                sb.AppendLine($"{propertyInfo.Name.CamelCaseToString()} => {propertyInfo.GetValue(this)?.ToString() ?? "Empty"}");
            }

            return sb.ToString().Sort();
        }

        #endregion Public Methods

        #region Protected Methods

        protected AetheredKeySpell GetAetheredKeySpellByPriority(AetheredKeySpell aetheredKeySpell)
        {
            var priorityList = new[] { aetheredKeySpell };
            return GetAetheredKeySpellByPriority(priorityList);
        }

        protected AetheredKeySpell GetAetheredKeySpellByPriority(IEnumerable<AetheredKeySpell> priorityList)
        {
            return (from aethered in priorityList
                from spell in Spells
                where string.Equals(aethered.AlignedName.RemoveApostrohes(), spell.AlignedName.RemoveApostrohes(), StringComparison.OrdinalIgnoreCase)
                select new AetheredKeySpell(aethered.UnalignedName, aethered.AlignedName, aethered.Cost, aethered.Aethers, Index.Parse(spell.Letter))
            ).FirstOrDefault();
        }

        protected BuffKeySpell GetBuffKeySpellByPriority(BuffKeySpell buffKeySpell)
        {
            var priorityList = new[] { buffKeySpell };
            return GetBuffKeySpellByPriority(priorityList);
        }

        protected BuffKeySpell GetBuffKeySpellByPriority(IEnumerable<BuffKeySpell> priorityList)
        {
            return (from buff in priorityList
                from spell in Spells
                where string.Equals(buff.AlignedName.RemoveApostrohes(), spell.AlignedName.RemoveApostrohes(), StringComparison.OrdinalIgnoreCase)
                select new BuffKeySpell(buff.UnalignedName, buff.AlignedName, buff.Cost, buff.Duration, buff.Aethers, Index.Parse(spell.Letter))
            ).FirstOrDefault();
        }

        protected HealKeySpell GetHealKeySpellByPriority(IEnumerable<HealKeySpell> priorityList)
        {
            return (from heal in priorityList
                from spell in Spells
                where string.Equals(heal.AlignedName.RemoveApostrohes(), spell.AlignedName.RemoveApostrohes(), StringComparison.OrdinalIgnoreCase)
                select new HealKeySpell(heal.UnalignedName, heal.AlignedName, heal.Cost, heal.Vita, Index.Parse(spell.Letter))
            ).FirstOrDefault();
        }

        protected KeySpell GetKeySpellByPriority(KeySpell keySpell)
        {
            var priorityList = new[] { keySpell };
            return GetKeySpellByPriority(priorityList);
        }

        protected KeySpell GetKeySpellByPriority(IEnumerable<KeySpell> priorityList)
        {
            return (from keySpell in priorityList
                from spell in Spells
                where string.Equals(keySpell.AlignedName.RemoveApostrohes(), spell.AlignedName.RemoveApostrohes(), StringComparison.OrdinalIgnoreCase)
                select new KeySpell(keySpell.UnalignedName, keySpell.AlignedName, keySpell.Cost, Index.Parse(spell.Letter))
            ).FirstOrDefault();
        }

        #endregion Protected Methods
    }
}
