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
    /// A collection of key spells known to a Mage.
    /// </summary>
    public class MageKeySpells : CasterKeySpells
    {
        #region Constructors

        /// <summary>
        /// Initializes key spell inventory by scanning the player's spell inventory by spell priority.
        /// </summary>
        /// <param name="spells">A list of all spells possessed by the player.</param>
        public MageKeySpells(List<Spell> spells) : base(spells)
        {
            Blind = GetBuffKeySpellByPriority(Priorities.Mage.Blind);
            Confuse = GetKeySpellByPriority(Priorities.Mage.Confuse);
            Curse = GetBuffKeySpellByPriority(Priorities.Mage.Vex);
            DoomsFire = GetAetheredKeySpellByPriority(Priorities.Mage.DoomsFire);
            Doze = GetBuffKeySpellByPriority(Priorities.Mage.Doze);
            Evocation = GetAetheredKeySpellByPriority(Priorities.Mage.Evocation);
            Heal = GetHealKeySpellByPriority(Priorities.Mage.Heal);
            HealSelf = GetHealKeySpellByPriority(Priorities.Mage.HealSelf);
            Hellfire = GetAetheredKeySpellByPriority(Priorities.Mage.Hellfire);
            Incineration = GetAetheredKeySpellByPriority(Priorities.Mage.Incineration);
            Inferno = GetAetheredKeySpellByPriority(Priorities.Mage.Inferno);
            MagisBane = GetBuffKeySpellByPriority(Priorities.Mage.MagisBane);
            Paralyze = GetBuffKeySpellByPriority(Priorities.Mage.Paralyze);
            MassParalyze = GetBuffKeySpellByPriority(Priorities.Mage.MassParalyze);
            Sleep = GetBuffKeySpellByPriority(Priorities.Mage.Sleep);
            Venom = GetBuffKeySpellByPriority(Priorities.Mage.Venom);
            Zap = GetKeySpellByPriority(Priorities.Mage.Zap);
            ZapSurrounding = GetKeySpellByPriority(Priorities.Mage.ZapSurrounding);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Blinds the target causing it to stop moving. It will still be able to attack adjacent players.
        /// </summary>
        public BuffKeySpell Blind { get; }

        /// <summary>
        /// Confuses the target causing it to attack other NPCs.
        /// </summary>
        public KeySpell Confuse { get; }

        /// <summary>
        /// Consumes all mana and does 2.5x mana damage to the target at 0 AC. Cannot be resisted.
        /// </summary>
        public AetheredKeySpell DoomsFire { get; }

        /// <summary>
        /// Disables a target from moving. The next attack upon the target will do 1.3x the normal damage.
        /// </summary>
        public BuffKeySpell Doze { get; }

        /// <summary>
        /// Restores all mana when cast. If it is cast with high mana, it will restore up
        /// to 1/3 of your maximum mana in vitality points. This can temporarily give you
        /// more than your maximum vita, but you will be returned to your max vita should
        /// you be healed.
        /// </summary>
        public AetheredKeySpell Evocation { get; }

        /// <summary>
        /// Takes 70% of Mana and takes an additional 1,000 mana and does 1.8x mana in
        /// damage to any target at 0 AC. Cannot be resisted. (ClassicTK has increased
        /// damage to at least 2.0x, possibly 2.15x.)
        /// </summary>
        public AetheredKeySpell Hellfire { get; }

        /// <summary>
        /// Cast Hellfire on 7 targets in a line in front of the mage.
        /// Takes 50% vita and 100% mana to cast.
        /// 0.5 * Vita + 2 * Mana in damage at 0 AC.
        /// </summary>
        public AetheredKeySpell Incineration { get; }

        /// <summary>
        /// 5-way Hellfire attack that takes all mana when cast and applies 1.5x mana in damage
        /// at 0 AC to the targets.
        /// </summary>
        public AetheredKeySpell Inferno { get; }

        /// <summary>
        /// Non-targetable scourge on a random NPC within range. (Exclusive to ClassicTK)
        /// </summary>
        public BuffKeySpell MagisBane { get; }

        /// <summary>
        /// Mass paralyze 3x3 grouping.
        /// </summary>
        public BuffKeySpell MassParalyze { get; }

        /// <summary>
        /// Disables a target from moving. Target also cannot attack. Cannot be cast on players.
        /// It has a fail rate dependent on Will.
        /// </summary>
        public BuffKeySpell Paralyze { get; }

        /// <summary>
        /// Disables a target from moving. The next attack upon the target will do 1.3x the
        /// normal damage. Sleep cannot be cast on players.
        /// </summary>
        public BuffKeySpell Sleep { get; }

        /// <summary>
        /// Poisons monster targets for a random amount of time. Does 1000 damage a second,
        /// disregarding armor class, on other players. Does more damage per second to animals.
        /// Poison will not kill a target but rather bring them to the lowest possible health.
        /// </summary>
        public BuffKeySpell Venom { get; }

        /// <summary>
        /// Non-targetable lightning attack against all targets adjacent to caster.
        /// </summary>
        public KeySpell ZapSurrounding { get; }

        #endregion Properties
    }
}
