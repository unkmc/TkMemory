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

namespace TkMemory.Domain.Spells.KeySpells.Priorities
{
    /// <summary>
    /// Key spell selection priorities for spells known to Mages and Poets.
    /// </summary>
    public class Caster
    {
        /// <summary>
        /// Removes paralysis debuffs from the target.
        /// </summary>
        public static readonly KeySpell[] CureParalysis =
        {
            new KeySpell("Cure Paralysis", "Cure Paralysis", 60),
            new KeySpell("Cure Paralysis", "Release Binds", 60),
            new KeySpell("Cure Paralysis", "Return Movement", 60),
            new KeySpell("Cure Paralysis", "Free Movement", 60)
        };

        /// <summary>
        /// Improves defense of the target by 10 (i.e. -10 AC).
        /// </summary>
        public static readonly BuffKeySpell[] HardenArmor =
        {
            new BuffKeySpell("Harden Armor", "Harden Armor", 30, 300),
            new BuffKeySpell("Harden Armor", "Thicken Skin", 30, 300),
            new BuffKeySpell("Harden Armor", "Shield of Life", 30, 300),
            new BuffKeySpell("Harden Armor", "Elemental Armor", 30, 300),
            new BuffKeySpell("Diancecht's Follain", "Diancecht's Follain", 0, 300) // Duration is intentionally inaccurate to the true value of 930 and must stay that way
        };

        /// <summary>
        /// Restores mana at the cost of vitality.
        /// </summary>
        public static readonly AetheredKeySpell[] Invoke =
        {
            new AetheredKeySpell("Invoke", "Invoke", 30, 22),
            new AetheredKeySpell("Invoke", "Spirit's Power", 30, 20),
            new AetheredKeySpell("Invoke", "Life Force", 30, 20),
            new AetheredKeySpell("Invoke", "Gather Magic", 30, 20)
        };

        /// <summary>
        /// Removes poison debuffs from the target.
        /// </summary>
        public static readonly KeySpell[] Purge =
        {
            new KeySpell("Purge", "Purge", 30),
            new KeySpell("Purge", "Cure Illness", 30),
            new KeySpell("Purge", "Restore Health", 30),
            new KeySpell("Purge", "Remove Poison", 30)
        };

        /// <summary>
        /// Removes Vex debuffs from the target.
        /// </summary>
        public static readonly KeySpell[] RemoveCurse =
        {
            new KeySpell("Remove Curse", "Remove Curse", 60),
            new KeySpell("Remove Curse", "Release Curse", 60),
            new KeySpell("Remove Curse", "Undo Evil", 60),
            new KeySpell("Remove Curse", "Restore Armor", 60)
        };

        /// <summary>
        /// Reduces damage taken by the target by half.
        /// </summary>
        public static readonly BuffKeySpell[] Sanctuary =
        {
            new BuffKeySpell("Sanctuary", "Sanctuary", 60, 300),
            new BuffKeySpell("Sanctuary", "Protect Soul", 60, 300),
            new BuffKeySpell("Sanctuary", "Guard Life", 60, 300),
            new BuffKeySpell("Sanctuary", "Magic Shield", 60, 300),
            new BuffKeySpell("Diancecht's Follain", "Diancecht's Follain", 0, 300) // Duration is intentionally inaccurate to the true value of 930
        };

        /// <summary>
        /// Increases the Might of the target by 3.
        /// </summary>
        public static readonly BuffKeySpell[] Valor =
        {
            new BuffKeySpell("Valor", "Valor", 30, 300),
            new BuffKeySpell("Valor", "Strengthen", 30, 300),
            new BuffKeySpell("Valor", "Bless Muscles", 30, 300),
            new BuffKeySpell("Valor", "Power Burst", 30, 300),
            new BuffKeySpell("Diancecht's Follain", "Diancecht's Follain", 0, 300) // Duration is intentionally inaccurate to the true value of 930
        };
    }
}
