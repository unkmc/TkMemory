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
    /// A collection of key spells known to a Rogue.
    /// </summary>
    public class RogueKeySpells : FighterKeySpells
    {
        #region Constructors

        /// <summary>
        /// Initializes key spell inventory by scanning the player's spell inventory by spell priority.
        /// </summary>
        /// <param name="spells">A list of all spells possessed by the player.</param>
        public RogueKeySpells(List<Spell> spells) : base(spells)
        {
            Ambush = GetKeySpellByPriority(Priorities.Rogue.Ambush);
            Amnesia = GetKeySpellByPriority(Priorities.Rogue.Amnesia);
            Chance = GetBuffKeySpellByPriority(Priorities.Rogue.Chance);
            Curse = GetAetheredKeySpellByPriority(Priorities.Rogue.Curse);
            DesperateAttack = GetAetheredKeySpellByPriority(Priorities.Rogue.DesperateAttack);
            Drain = GetKeySpellByPriority(Priorities.Rogue.Drain);
            Enchant = GetKeySpellByPriority(Priorities.Rogue.Enchant);
            FocusedBlade = GetAetheredKeySpellByPriority(Priorities.Rogue.FocusedBlade);
            Fury = GetBuffKeySpellByPriority(Priorities.Rogue.Fury);
            Heal = GetHealKeySpellByPriority(Priorities.Rogue.Heal);
            HealSelf = GetHealKeySpellByPriority(Priorities.Rogue.HealSelf);
            Invisible = GetKeySpellByPriority(Priorities.Rogue.Invisible);
            LethalStrike = GetAetheredKeySpellByPriority(Priorities.Rogue.LethalStrike);
            Might = GetBuffKeySpellByPriority(Priorities.Rogue.Might);
            PrecisionBlitz = GetAetheredKeySpellByPriority(Priorities.Rogue.PrecisionBlitz);
            Rage = GetBuffKeySpellByPriority(Priorities.Rogue.Cunning);
            RegenerateMana = GetBuffKeySpellByPriority(Priorities.Rogue.RegenerateMana);
            SetTrap = new SetTrapKeySpells(Spells);
            ShadowFigure = GetBuffKeySpellByPriority(Priorities.Rogue.ShadowFigure);
            SpotTraps = GetAetheredKeySpellByPriority(Priorities.Rogue.SpotTraps);
            Zap = GetKeySpellByPriority(Priorities.Rogue.Zap);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// When cast the caster will jump behind the target it faces. Useful in combat to attack the back of animals
        /// which is more vulnerable and takes more damage.
        /// </summary>
        public KeySpell Ambush { get; }

        /// <summary>
        /// Only works on NPCs. Will stop the engaging enemy from attacking you and turn their sights to another target.
        /// If there is no other target, they will walk around as if no one was there. If you attack a target you cast
        /// amnesia on, they will once again.
        /// </summary>
        public KeySpell Amnesia { get; }

        /// <summary>
        /// When Chance has been cast, 200 mana will drain each second for 10 seconds. During this time you must drop a
        /// total of 170 coins. Casts Invoke when successful and Dishearten when it fails. Must have 30 mana remaining to
        /// cast invoke.
        /// </summary>
        public BuffKeySpell Chance { get; }

        /// <summary>
        /// +40 AC to 4 adjacent creatures.
        /// </summary>
        public AetheredKeySpell Curse { get; }

        /// <summary>
        /// Uses 50% of current vita in a strong attack. Brings total current mana to 0. Does current vita + current mana in damage to a target at 0 AC.
        /// </summary>
        public AetheredKeySpell DesperateAttack { get; }

        /// <summary>
        /// Drain will drain all animals/summons less than 1000 vitality and give you their remaining life. This cannot be cast on other players.
        /// Additional life can accumulate up to double your base vitality.
        /// </summary>
        public KeySpell Drain { get; }

        /// <summary>
        /// Takes 2/3 of current vita in a strong attack. The attack does 2x current vitality in damage at 0 AC.
        /// </summary>
        public AetheredKeySpell FocusedBlade { get; }

        /// <summary>
        /// Increases your weapon damage x9. Makes caster invisible to everyone except group members. In that case they appear
        /// slightly transparent. Can be removed by hitting something or pressing item pickup keys.
        /// </summary>
        public KeySpell Invisible { get; }

        /// <summary>
        /// Uses 50% of current vita in a strong attack. Does 1/2 current vitality plus 2.5x current mana in damage at 0 AC.
        /// </summary>
        public AetheredKeySpell LethalStrike { get; }

        /// <summary>
        /// Increases one's own Might by 3.
        /// </summary>
        public BuffKeySpell Might { get; }

        /// <summary>
        /// Attacks 5 aligned targets as long as the caster has room to ambush. 1.8 * Vita + 0.45 * Mana (varies on target) at 0 AC.
        /// </summary>
        public AetheredKeySpell PrecisionBlitz { get; }

        /// <summary>
        /// Set traps on the ground that cause damage or status effects when an NPC steps on that tile. Players can only be hit
        /// by traps in PK areas.
        /// </summary>
        public SetTrapKeySpells SetTrap { get; }

        /// <summary>
        /// Increases attack evasion.
        /// </summary>
        public BuffKeySpell ShadowFigure { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Generates a string representation of a Rogue's key spell and trap inventory.
        /// </summary>
        /// <returns>A list of key spells and traps known to the player.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine();
            sb.AppendLine(SetTrap.ToString());
            
            return sb.ToString();
        }

        #endregion Public Methods
    }
}
