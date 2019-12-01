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
    /// A collection of key spells known to a Poet.
    /// </summary>
    public class PoetKeySpells : CasterKeySpells
    {
        #region Constructors

        /// <summary>
        /// Initializes key spell inventory by scanning the player's spell inventory by spell priority.
        /// </summary>
        /// <param name="spells">A list of all spells possessed by the player.</param>
        public PoetKeySpells(List<Spell> spells) : base(spells)
        {
            Asv = GetKeySpellByPriority(Priorities.Poet.Asv);
            AsvGroup = GetBuffKeySpellByPriority(Priorities.Poet.AsvGroup);
            Atone = GetKeySpellByPriority(Priorities.Poet.Atone);
            Barrier = GetBuffKeySpellByPriority(Priorities.Poet.Barrier);
            BlockadeHuman = GetBuffKeySpellByPriority(Priorities.Poet.BlockadeHuman);
            Bolster = GetBuffKeySpellByPriority(Priorities.Poet.Bolster);
            CallAvatar = GetAetheredKeySpellByPriority(Priorities.Poet.CallAvatar);
            CallChampion = GetBuffKeySpellByPriority(Priorities.Poet.CallChampion);
            CallLegend = GetAetheredKeySpellByPriority(Priorities.Poet.CallLegend);
            CallMaster = GetAetheredKeySpellByPriority(Priorities.Poet.CallMaster);
            CallOfTheWild = GetKeySpellByPriority(Priorities.Poet.CallOfTheWild);
            Curse = GetBuffKeySpellByPriority(Priorities.Poet.Scourge);
            Dishearten = GetBuffKeySpellByPriority(Priorities.Poet.Dishearten);
            Dispel = GetKeySpellByPriority(Priorities.Poet.Dispel);
            Endear = GetBuffKeySpellByPriority(Priorities.Poet.Endear);
            HardenBody = GetBuffKeySpellByPriority(Priorities.Poet.HardenBody);
            Heal = GetHealKeySpellByPriority(Priorities.Poet.Heal);
            HealFull = GetAetheredKeySpellByPriority(Priorities.Poet.HealFull);
            HealSelf = GetHealKeySpellByPriority(Priorities.Poet.HealSelf);
            Inspiration = GetKeySpellByPriority(Priorities.Poet.Inspiration);
            Inspire = GetKeySpellByPriority(Priorities.Poet.Inspire);
            RemoveVeil = GetKeySpellByPriority(Priorities.Poet.RemoveVeil);
            Resurrect = GetAetheredKeySpellByPriority(Priorities.Poet.Resurrect);
            Restore = GetAetheredKeySpellByPriority(Priorities.Poet.Restore);
            Retribution = GetAetheredKeySpellByPriority(Priorities.Poet.Retribution);
            Revival = GetAetheredKeySpellByPriority(Priorities.Poet.Revival);
            SecondSight = GetBuffKeySpellByPriority(Priorities.Poet.SecondSight);
            Zap = GetKeySpellByPriority(Priorities.Poet.Zap);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Casts ASV on a target.
        /// </summary>
        public KeySpell Asv { get; }

        /// <summary>
        /// Cast ASV on entire group.
        /// </summary>
        public BuffKeySpell AsvGroup { get; }

        /// <summary>
        /// Removes scourge and similar spells from target.
        /// </summary>
        public KeySpell Atone { get; }

        /// <summary>
        /// 4-way invisible blockade surrounds the caster disabling any animals from walking next to them.
        /// If an animal is in one of those spaces, they are paralyzed until the barrier wears off.
        /// </summary>
        public BuffKeySpell Barrier { get; }

        /// <summary>
        /// 4-way invisible blockade surrounds the caster, disabling any players from walking next to them.
        /// If a player is in one of those spaces, they are unable to move from the spot until the barrier
        /// wears off either naturally or via Dispel, and the person is still able to cast spells while trapped.
        /// </summary>
        public BuffKeySpell BlockadeHuman { get; }

        /// <summary>
        /// Improves defense. Can be cast while Harden armor is in effect. Cannot be cast while Dishearten is in effect.
        /// </summary>
        public BuffKeySpell Bolster { get; }

        /// <summary>
        /// Summons a 100k vita creature to assist the caster. The summon does about 3,000 damage at 0 AC for each swing.
        /// </summary>
        public AetheredKeySpell CallAvatar { get; }

        /// <summary>
        /// Summons a 75k vita creature to assist the caster. The summon does about 1,500 damage at 0 AC for each swing.
        /// </summary>
        public BuffKeySpell CallChampion { get; }

        /// <summary>
        /// Summons a creature to assist the caster.
        /// </summary>
        public AetheredKeySpell CallLegend { get; }

        /// <summary>
        /// Summons a ??? vita creature to assist the caster. The summoned creature does about ??? damage at 0 AC for each swing.
        /// </summary>
        public AetheredKeySpell CallMaster { get; }

        /// <summary>
        /// Summons a single creature to assist the caster. A maximum of 8 can be summoned. Call of the Wild gains more animals as
        /// it progresses in levels. You have to pay 100 Acorns and 1000 coins per new animal. In alignments, each new animal is a
        /// new spell altogether.
        /// </summary>
        public KeySpell CallOfTheWild { get; }

        /// <summary>
        /// Decreases defense. Can be cast while Vex/Scourge/etc are in effect. Cannot be cast while Bolster is in effect.
        /// </summary>
        public BuffKeySpell Dishearten { get; }

        /// <summary>
        /// Removes all status effects from a target, with few exceptions.
        /// </summary>
        public KeySpell Dispel { get; }

        /// <summary>
        /// Mind controls an enemy depending on the caster's mana and NPC's vita. Has a fail rate.
        /// </summary>
        public BuffKeySpell Endear { get; }

        /// <summary>
        /// Makes the caster temporarily invulnerable. Has a fail rate.
        /// </summary>
        public BuffKeySpell HardenBody { get; }

        /// <summary>
        /// Targetable spell to restore all vitality.
        /// </summary>
        public AetheredKeySpell HealFull { get; }

        /// <summary>
        /// The target must be a player in the group. Takes their mana and gives it to the caster.
        /// </summary>
        public KeySpell Inspiration { get; }

        /// <summary>
        /// Use one's own mana to restore the mana of the target.
        /// </summary>
        public KeySpell Inspire { get; }

        /// <summary>
        /// Removes all types of blindness from the target.
        /// </summary>
        public KeySpell RemoveVeil { get; }

        /// <summary>
        /// Brings a dead player back to life.
        /// </summary>
        public AetheredKeySpell Resurrect { get; }

        /// <summary>
        /// Obtained during the Restore quest. Heals 150% of Caster's Current Mana on Target at a cost of 1/3 of their current mana.
        /// </summary>
        public AetheredKeySpell Restore { get; }

        /// <summary>
        /// Does 34% of current mana in damage on 0 AC.
        /// </summary>
        public AetheredKeySpell Retribution { get; }

        /// <summary>
        /// Returns all vitality and all mana except for 10,000 mana. Will return poet's own life if dead.
        /// </summary>
        public AetheredKeySpell Revival { get; }

        /// <summary>
        /// Shows a text notification that says "Name is Hidden in the Area" when standing next to an invisible person.
        /// </summary>
        public BuffKeySpell SecondSight { get; }

        #endregion Properties
    }
}
