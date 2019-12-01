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
    /// A collection of key spells known to a Warrior.
    /// </summary>
    public class WarriorKeySpells : FighterKeySpells
    {
        #region Constructors

        /// <summary>
        /// Initializes key spell inventory by scanning the player's spell inventory by spell priority.
        /// </summary>
        /// <param name="spells">A list of all spells possessed by the player.</param>
        public WarriorKeySpells(List<Spell> spells) : base(spells)
        {
            Assault = GetAetheredKeySpellByPriority(Priorities.Warrior.Assault);
            Backstab = GetBuffKeySpellByPriority(Priorities.Warrior.Backstab);
            Berserk = GetAetheredKeySpellByPriority(Priorities.Warrior.Berserk);
            Blessing = GetBuffKeySpellByPriority(Priorities.Warrior.Blessing);
            CurseProof = GetBuffKeySpellByPriority(Priorities.Warrior.CurseProof);
            Enchant = GetKeySpellByPriority(Priorities.Warrior.Enchant);
            Flank = GetBuffKeySpellByPriority(Priorities.Warrior.Flank);
            Fury = GetBuffKeySpellByPriority(Priorities.Warrior.Fury);
            Heal = GetHealKeySpellByPriority(Priorities.Warrior.Heal);
            HealSelf = GetHealKeySpellByPriority(Priorities.Warrior.HealSelf);
            Potence = GetBuffKeySpellByPriority(Priorities.Warrior.Potence);
            Rage = GetBuffKeySpellByPriority(Priorities.Warrior.Rage);
            Rampage = GetAetheredKeySpellByPriority(Priorities.Warrior.Rampage);
            RegenerateMana = GetBuffKeySpellByPriority(Priorities.Warrior.RegenerateMana);
            Siege = GetAetheredKeySpellByPriority(Priorities.Warrior.Siege);
            Slash = GetAetheredKeySpellByPriority(Priorities.Warrior.Slash);
            SpotTraps = GetAetheredKeySpellByPriority(Priorities.Warrior.SpotTraps);
            Stun = GetBuffKeySpellByPriority(Priorities.Warrior.Stun);
            Whirlwind = GetAetheredKeySpellByPriority(Priorities.Warrior.Whirlwind);
            Zap = GetKeySpellByPriority(Priorities.Warrior.Zap);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 4-target Whirlwind in the direction the caster is facing. Takes 50% of the warrior's vita and attacks with that much damage
        /// at 0 AC. Vita is lost even if no targets are in range.
        /// </summary>
        public AetheredKeySpell Assault { get; }

        /// <summary>
        /// Melee attacks can also hit the target standing behind the caster.
        /// </summary>
        public BuffKeySpell Backstab { get; }

        /// <summary>
        /// Uses 2/3 of current vita to critical strike a target for 75% current vitality in damage.
        /// </summary>
        public AetheredKeySpell Berserk { get; }

        /// <summary>
        /// Increase Hit statistic to reduce missed melee attacks.
        /// </summary>
        public BuffKeySpell Blessing { get; }

        /// <summary>
        /// Prevents curses such as Vex, Scourge, Forsake, etc. Can be dispelled.
        /// </summary>
        public BuffKeySpell CurseProof { get; }

        /// <summary>
        /// Melee attack can also hit a target standing to the side of the caster. Only one side target can be hit each time.
        /// </summary>
        public BuffKeySpell Flank { get; }

        /// <summary>
        /// Increases Damage statistic. Every 2 Damage adds 5 more damage (subsequently multiplied by fury/rage).
        /// </summary>
        public BuffKeySpell Potence { get; }

        /// <summary>
        /// Attack up to 12 surrounding targets (or 13 if person is standing on top of a creature). Requires 10% of current mana to cast.
        /// Does approximately 0.4875 vita + 0.1 mana at 0 AC. Consumes 95% of caster's vita.
        /// </summary>
        public AetheredKeySpell Rampage { get; }

        /// <summary>
        /// Siege does a critical strike and leaves the caster with 25% vita left. Damage to target is 1.875x current vitality
        /// plus 0.5x current mana at 0 AC.
        /// </summary>
        public AetheredKeySpell Siege { get; }

        /// <summary>
        /// Attack that does .0245x Vita + 11.435x Might in damage towards a target.
        /// </summary>
        public AetheredKeySpell Slash { get; }

        /// <summary>
        /// Stuns adjacent NPCs. Does not cause Mythic bosses to heal themselves. Takes 2% vita each time it is cast.
        /// </summary>
        public BuffKeySpell Stun { get; }

        /// <summary>
        /// Whirlwind does critical strike and leaves the caster with 10% vita left if they follow Ming Ken or Ohaeng or
        /// 10 vita left if they follow Kwi-Sin. Damage to target is 1.575 times current vitality. If player is Kwi sin,
        /// they do 1.75 times vitality in damage at 0 AC.
        /// </summary>
        public AetheredKeySpell Whirlwind { get; }

        #endregion Properties
    }
}
