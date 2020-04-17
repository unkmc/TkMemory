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

// ReSharper disable StringLiteralTypo

namespace TkMemory.Domain.Spells.KeySpells.Priorities
{
    /// <summary>
    /// Key spell selection priorities for spells known to Poets.
    /// </summary>
    public class Poet
    {
        /// <summary>
        /// Casts ASV on a target.
        /// </summary>
        public static readonly BuffKeySpell[] Asv =
        {
            // Durations may not be accurate, but it works better when they all have the same duration as traditional ASV spells.
            new BuffKeySpell("Sonnet of ReShor", "Sonnet of ReShor", 20000, 300),
            new BuffKeySpell("Sonnet of ReShor", "Tragedy of Johaih", 20000, 300),
            new BuffKeySpell("Sonnet of ReShor", "Blason of SeaNymph", 20000, 300),
            new BuffKeySpell("Sonnet of ReShor", "Haiku of Qantao", 20000, 300),
            new BuffKeySpell("Diancecht's Follain", "Diancecht's Follain", 0, 300) // True duration is 930
        };

        /// <summary>
        /// Cast ASV on entire group.
        /// </summary>
        public static readonly BuffKeySpell[] AsvGroup =
        {
            new BuffKeySpell("Rhyme of Walsuk", "Rhyme of Walsuk", 50000, 300, 383),
            new BuffKeySpell("Rhyme of Walsuk", "Epigram of Sute", 50000, 300, 383),
            new BuffKeySpell("Rhyme of Walsuk", "Fable of Claw", 50000, 300, 383),
            new BuffKeySpell("Rhyme of Walsuk", "Nonet of Ugh", 50000, 300, 383)
        };

        /// <summary>
        /// Removes scourge and similar spells from target.
        /// </summary>
        public static readonly KeySpell[] Atone =
        {
            new KeySpell("Atone", "Atone", 60),
            new KeySpell("Atone", "Restore Will", 60),
            new KeySpell("Atone", "Raise Guard", 60),
            new KeySpell("Atone", "Align Armor", 60)
        };

        /// <summary>
        /// 4-way invisible blockade surrounds the caster disabling any animals from walking next to them.
        /// If an animal is in one of those spaces, they are paralyzed until the barrier wears off.
        /// </summary>
        public static readonly BuffKeySpell[] Barrier =
        {
            new BuffKeySpell("Barrier", "Barrier", 300, 22),
            new BuffKeySpell("Barrier", "Spirit Barrier", 300, 22),
            new BuffKeySpell("Barrier", "Life Barrier", 300, 22),
            new BuffKeySpell("Barrier", "Balance Barrier", 300, 22)
        };

        /// <summary>
        /// 4-way invisible blockade surrounds the caster, disabling any players from walking next to them.
        /// If a player is in one of those spaces, they are unable to move from the spot until the barrier
        /// wears off either naturally or via Dispel, and the person is still able to cast spells while trapped.
        /// </summary>
        public static readonly BuffKeySpell[] BlockadeHuman =
        {
            new BuffKeySpell("Blockade Human", "Blockade Human", 300, 56, 22),
            new BuffKeySpell("Blockade Human", "Block Entry", 300, 56, 22),
            new BuffKeySpell("Blockade Human", "Distance Self", 300, 56, 22),
            new BuffKeySpell("Blockade Human", "Protect Sides", 300, 56, 22)
        };

        /// <summary>
        /// Improves defense. Can be cast while Harden armor is in effect. Cannot be cast while Dishearten is in effect.
        /// </summary>
        public static readonly BuffKeySpell[] Bolster =
        {
            new BuffKeySpell("Bolster", "Dansa of Armor", 2500, 37),
            new BuffKeySpell("Bolster", "Sonnet of Souls", 2500, 37),
            new BuffKeySpell("Bolster", "Couplets of Heroism", 2500, 37),
            new BuffKeySpell("Bolster", "Eclogue of Elements", 2500, 37),
            new BuffKeySpell("Bolster", "Ensure", 1500, 37),
            new BuffKeySpell("Bolster", "Spirit Shield", 1500, 37),
            new BuffKeySpell("Bolster", "Soul Guard", 1500, 37),
            new BuffKeySpell("Bolster", "Rock Blessing", 1500, 37),
            new BuffKeySpell("Bolster", "Bolster", 1000, 37),
            new BuffKeySpell("Bolster", "Dark Armor", 1000, 37),
            new BuffKeySpell("Bolster", "Life Armor", 1000, 37),
            new BuffKeySpell("Bolster", "Armor of Elements", 1000, 37)
        };

        /// <summary>
        /// Summons a 100k vita creature to assist the caster. The summon does about 3,000 damage at 0 AC for each swing.
        /// </summary>
        public static readonly AetheredKeySpell[] CallAvatar =
        {
            new AetheredKeySpell("Call Avatar", "Wind Warrior", 0, 480),
            new AetheredKeySpell("Call Avatar", "Avatar of Kwi-Sin", 0, 480),
            new AetheredKeySpell("Call Avatar", "Ming-Ken Avatar", 0, 480),
            new AetheredKeySpell("Call Avatar", "Avatar of Ohaeng", 0, 480)
        };

        /// <summary>
        /// Summons a 75k vita creature to assist the caster. The summon does about 1,500 damage at 0 AC for each swing.
        /// </summary>
        public static readonly BuffKeySpell[] CallChampion =
        {
            new BuffKeySpell("Call Champion", "Wind Dancer", 0, 54, 480),
            new BuffKeySpell("Call Champion", "Kwi-Sin Champion", 0, 54, 480),
            new BuffKeySpell("Call Champion", "Ming-Ken Champion", 0, 54, 480),
            new BuffKeySpell("Call Champion", "Ohaeng Champion", 0, 54, 480)
        };

        /// <summary>
        /// Summons a creature to assist the caster.
        /// </summary>
        public static readonly AetheredKeySpell[] CallLegend =
        {
            new AetheredKeySpell("Call Legend", "Call Legend", 0, 600),
            new AetheredKeySpell("Call Legend", "Call Horror", 0, 600),
            new AetheredKeySpell("Call Legend", "Call Guardian", 0, 600),
            new AetheredKeySpell("Call Legend", "Call Centurion", 0, 600)
        };

        /// <summary>
        /// Summons a ??? vita creature to assist the caster. The summoned creature does about ??? damage at 0 AC for each swing.
        /// </summary>
        public static readonly AetheredKeySpell[] CallMaster =
        {
            new AetheredKeySpell("Call Master", "Wind Master", 0, 480),
            new AetheredKeySpell("Call Master", "Kwi-Sin Master", 0, 480),
            new AetheredKeySpell("Call Master", "Ming-Ken Master", 0, 480),
            new AetheredKeySpell("Call Master", "Ohaeng Master", 0, 480)
        };

        /// <summary>
        /// Summons a single creature to assist the caster. A maximum of 8 can be summoned. Call of the Wild gains more animals as
        /// it progresses in levels. You have to pay 100 Acorns and 1000 coins per new animal. In alignments, each new animal is a
        /// new spell altogether.
        /// </summary>
        public static readonly KeySpell[] CallOfTheWild =
        {
            new KeySpell("Call of the Wild", "Call of the Wild (Gorilla)", 10),
            new KeySpell("Call of the Wild", "Warrior of Kwi-sin", 10),
            new KeySpell("Call of the Wild", "Ming-ken Warrior", 10),
            new KeySpell("Call of the Wild", "Warrior of Ohaeng", 10),
            new KeySpell("Call of the Wild", "Call of the Wild (Wild Monkey)", 10),
            new KeySpell("Call of the Wild", "Fighter of Kwi-sin", 10),
            new KeySpell("Call of the Wild", "Fighter of Ming-ken", 10),
            new KeySpell("Call of the Wild", "Fighter of Ohaeng", 10),
            new KeySpell("Call of the Wild", "Call of the Wild (Panda Bear)", 10),
            new KeySpell("Call of the Wild", "Kwi-sin Protector", 10),
            new KeySpell("Call of the Wild", "Ming-ken Protector", 10),
            new KeySpell("Call of the Wild", "Ohaeng Protector", 10),
            new KeySpell("Call of the Wild", "Call of the Wild (Fluffy Dog)", 10),
            new KeySpell("Call of the Wild", "Kwi-sin Assistant", 10),
            new KeySpell("Call of the Wild", "Ming-ken Assistant", 10),
            new KeySpell("Call of the Wild", "Ohaeng Assistant", 10),
            new KeySpell("Call of the Wild", "Call of the Wild (Caterpiller)", 10), // TODO: Caterpiller or caterpillar?
            new KeySpell("Call of the Wild", "Call of the Wild (Caterpillar)", 10),
            new KeySpell("Call of the Wild", "Companion of Kwi-sin", 10),
            new KeySpell("Call of the Wild", "Companion of Ming-ken", 10),
            new KeySpell("Call of the Wild", "Companion of Ohaeng", 10)
        };

        /// <summary>
        /// Decreases defense. Can be cast while Vex/Scourge/etc are in effect. Cannot be cast while Bolster is in effect.
        /// </summary>
        public static readonly BuffKeySpell[] Dishearten =
        {
            new BuffKeySpell("Dishearten", "Hymn of Rejection", 2500, 18),
            new BuffKeySpell("Dishearten", "Nocturne of Wilting", 2500, 18),
            new BuffKeySpell("Dishearten", "Barcarolle of Exhaustion", 2500, 18),
            new BuffKeySpell("Dishearten", "Capriccio of Denial", 2500, 18),
            new BuffKeySpell("Dishearten", "Deteriorate", 1500, 18),
            new BuffKeySpell("Dishearten", "Death Coil", 1500, 18),
            new BuffKeySpell("Dishearten", "Heart's Breaking", 1500, 18),
            new BuffKeySpell("Dishearten", "Quicksand", 1500, 18),
            new BuffKeySpell("Dishearten", "Dishearten", 1000, 18),
            new BuffKeySpell("Dishearten", "Dark Fear", 1000, 18),
            new BuffKeySpell("Dishearten", "Break Will", 1000, 18),
            new BuffKeySpell("Dishearten", "Harshen Attack", 1000, 18)
        };

        /// <summary>
        /// Removes all status effects from a target, with few exceptions.
        /// </summary>
        public static readonly KeySpell[] Dispel =
        {
            new KeySpell("Dispel", "Dispell", 200), // TODO: Dispell or dispel?
            new KeySpell("Dispel", "Dispel", 200),
            new KeySpell("Dispel", "Remove Magic", 200),
            new KeySpell("Dispel", "Return Natural", 200),
            new KeySpell("Dispel", "Restore Balance", 200)
        };

        /// <summary>
        /// Mind controls an enemy depending on the caster's mana and NPC's vita. Has a fail rate.
        /// </summary>
        public static readonly BuffKeySpell[] Endear =
        {
            new BuffKeySpell("Endear", "Fascinate", 210, 30, 3),
            new BuffKeySpell("Endear", "Endear", 300, 15, 6),
            new BuffKeySpell("Endear", "Possess Soul", 300, 15, 6),
            new BuffKeySpell("Endear", "Charm Life", 300, 15, 6),
            new BuffKeySpell("Endear", "Align Follower", 300, 15, 6)
        };

        /// <summary>
        /// Makes the caster temporarily invulnerable. Has a fail rate.
        /// </summary>
        public static readonly BuffKeySpell[] HardenBody =
        {
            new BuffKeySpell("Harden Body", "Harden Body", 300, 12),
            new BuffKeySpell("Harden Body", "Death's Guard", 300, 12),
            new BuffKeySpell("Harden Body", "Life's Protection", 300, 12),
            new BuffKeySpell("Harden Body", "Body of Alignment", 300, 12)
        };

        /// <summary>
        /// Targetable spell to restore vitality.
        /// </summary>
        public static readonly HealKeySpell[] Heal =
        {
            new HealKeySpell("Ballad of Min", "Ballad of Min", 6000, 100000),
            new HealKeySpell("Ballad of Min", "Requiem of Mupa", 6000, 100000),
            new HealKeySpell("Ballad of Min", "Fanfare of WinSong", 6000, 100000),
            new HealKeySpell("Ballad of Min", "Aria of Insu", 6000, 100000),
            new HealKeySpell("Charge of Life", "Charge of Life", 3000, 50000),
            new HealKeySpell("Charge of Life", "Vital Charge", 3000, 50000),
            new HealKeySpell("Charge of Life", "Blessing of Life", 3000, 50000),
            new HealKeySpell("Charge of Life", "Sacred Soil", 3000, 50000),
            new HealKeySpell("Essence of Life", "Essence of Life", 2000, 20000),
            new HealKeySpell("Essence of Life", "Kwi-Sin Essence of Life", 2000, 20000),
            new HealKeySpell("Essence of Life", "Life's Embrace", 2000, 20000),
            new HealKeySpell("Essence of Life", "Earth's Cradle", 2000, 20000),
            new HealKeySpell("Stream of Life", "Stream of Life", 1000, 10000),
            new HealKeySpell("Stream of Life", "Purity of Spirit", 1000, 10000),
            new HealKeySpell("Stream of Life", "Nature's Abundance", 1000, 10000),
            new HealKeySpell("Stream of Life", "Forge of Life", 1000, 10000),
            new HealKeySpell("Water of Life", "Water of Life", 390, 5000),
            new HealKeySpell("Water of Life", "Breath of Power", 390, 5000),
            new HealKeySpell("Water of Life", "Healing Breath", 390, 5000),
            new HealKeySpell("Water of Life", "Breath of Life", 390, 5000),
            new HealKeySpell("Revitalize", "Revitalize", 210, 1000),
            new HealKeySpell("Revitalize", "Ancestor's Embrace", 210, 1000),
            new HealKeySpell("Revitalize", "Life-Force", 210, 1000),
            new HealKeySpell("Revitalize", "Lifespring", 210, 1000),
            new HealKeySpell("Heal", "Heal", 120, 500),
            new HealKeySpell("Heal", "Ancestor's Touch", 120, 500),
            new HealKeySpell("Heal", "Life Flow", 120, 500),
            new HealKeySpell("Heal", "Infuse Life-Force", 120, 500),
            new HealKeySpell("Recover", "Recover", 100, 200),
            new HealKeySpell("Recover", "Spirit's Embrace", 100, 200),
            new HealKeySpell("Recover", "Infuse Energy", 100, 200),
            new HealKeySpell("Recover", "Life's River", 100, 200),
            new HealKeySpell("Lay Hands", "Lay Hands", 90, 100),
            new HealKeySpell("Lay Hands", "Spirit's Smile", 90, 100),
            new HealKeySpell("Lay Hands", "Life's Water", 90, 100),
            new HealKeySpell("Lay Hands", "Quicken", 90, 100)
        };

        /// <summary>
        /// Targetable spell to restore all vitality.
        /// </summary>
        public static readonly AetheredKeySpell[] HealFull =
        {
            new AetheredKeySpell("Full Heal", "Battle Chant", 640000, 450),
            new AetheredKeySpell("Full Heal", "Solemn Serenade", 640000, 450),
            new AetheredKeySpell("Full Heal", "Concerto of Victory", 640000, 450),
            new AetheredKeySpell("Full Heal", "Rhapsody of Wind", 640000, 450)
        };

        /// <summary>
        /// Non-targetable spell to restore vitality of oneself.
        /// </summary>
        public static readonly HealKeySpell[] HealSelf =
        {
            new HealKeySpell("Soothe", "Soothe", 3, 50)
        };

        /// <summary>
        /// The target must be a player in the group. Takes their mana and gives it to the caster.
        /// </summary>
        public static readonly KeySpell[] Inspiration =
        {
            new KeySpell("Inspiration", "Inspiration", 0),
            new KeySpell("Inspiration", "Draw Energy", 0),
            new KeySpell("Inspiration", "Harness Power", 0),
            new KeySpell("Inspiration", "Combine Focus", 0)
        };

        /// <summary>
        /// Use one's own mana to restore the mana of the target.
        /// </summary>
        public static readonly KeySpell[] Inspire =
        {
            new KeySpell("Inspire", "Inspire", 30),
            new KeySpell("Inspire", "Share Energy", 30),
            new KeySpell("Inspire", "Bestow Power", 30),
            new KeySpell("Inspire", "Release Focus", 30)
        };

        /// <summary>
        /// Removes all types of blindness from the target.
        /// </summary>
        public static readonly KeySpell[] RemoveVeil =
        {
            new KeySpell("Remove Veil", "Remove Veil", 60),
            new KeySpell("Remove Veil", "Clear Darkness", 60),
            new KeySpell("Remove Veil", "Restore Sight", 60),
            new KeySpell("Remove Veil", "Purge Darkness", 60)
        };

        /// <summary>
        /// Brings a dead player back to life.
        /// </summary>
        public static readonly AetheredKeySpell[] Resurrect =
        {
            new AetheredKeySpell("Resurrect", "Resurrect", 3000, 8),
            new AetheredKeySpell("Resurrect", "Return Spirit", 3000, 8),
            new AetheredKeySpell("Resurrect", "Ming-Ken Blessing", 3000, 8), // 5-way
            new AetheredKeySpell("Resurrect", "Death Undone", 3000, 8)
        };

        /// <summary>
        /// Obtained during the Restore quest. Heals 150% of Caster's Current Mana on Target at a cost of 1/3 of their current mana.
        /// </summary>
        public static readonly AetheredKeySpell[] Restore =
        {
            new AetheredKeySpell("Restore", "Restore", 1000, 10)
        };

        /// <summary>
        /// Does 34% of current mana in damage on 0 AC.
        /// </summary>
        public static readonly AetheredKeySpell[] Retribution =
        {
            new AetheredKeySpell("Retribution", "Retribution", 500, 24),
            new AetheredKeySpell("Retribution", "Spirit Puppet", 500, 24),
            new AetheredKeySpell("Retribution", "Palm of Life", 500, 24),
            new AetheredKeySpell("Retribution", "Tornado", 500, 24)
        };

        /// <summary>
        /// Returns all vitality and all mana except for 10,000 mana. Will return poet's own life if dead.
        /// </summary>
        public static readonly AetheredKeySpell Revival = new AetheredKeySpell("Hyun Moo Revival", "Hyun Moo Revival", 10000, 1500);

        /// <summary>
        /// Gives +50 AC to the target. Each Positive AC point is 1% damage given to the attacker. Higher armor class is therefore worse.
        /// </summary>
        public static readonly BuffKeySpell[] Scourge =
        {
            new BuffKeySpell("Scourge", "Scourge", 90, 425),
            new BuffKeySpell("Scourge", "Damage Will", 90, 425),
            new BuffKeySpell("Scourge", "Drop Guard", 90, 425),
            new BuffKeySpell("Scourge", "Unalign Armor", 90, 425),
            new BuffKeySpell("Afflict", "Afflict", 0, 0)
        };

        /// <summary>
        /// Shows a text notification that says "Name is Hidden in the Area" when standing next to an invisible person.
        /// </summary>
        public static readonly BuffKeySpell[] SecondSight =
        {
            new BuffKeySpell("Second Sight", "Second Sight", 240, 325, 325),
            new BuffKeySpell("Second Sight", "Hear Spirits", 240, 325, 325),
            new BuffKeySpell("Second Sight", "Improve Sight", 240, 325, 325),
            new BuffKeySpell("Second Sight", "Show Hidden", 240, 325, 325)
        };

        /// <summary>
        /// Targetable lightning attack.
        /// </summary>
        public static readonly KeySpell[] Zap =
        {
            new KeySpell("Hyun Moo Spite", "Hyun Moo Spite", 600),
            new KeySpell("Healer's Revenge", "Healer's Revenge", 300),
            new KeySpell("Flare", "Flare", 80),
            new KeySpell("Flare", "Dance of Death", 80),
            new KeySpell("Flare", "Breaking of the World", 80),
            new KeySpell("Flare", "Storm Crow", 80),
            new KeySpell("Earthquake", "Earthquake", 90), // 5-way zap
            new KeySpell("Earthquake", "Tossing the Bones", 90), // 5-way zap
            new KeySpell("Earthquake", "Nature's Fury", 90), // 5-way zap
            new KeySpell("Earthquake", "Groundstrike", 90), // 5-way zap
            new KeySpell("Ignite", "Ignite", 60),
            new KeySpell("Ignite", "Spirit Strike", 60),
            new KeySpell("Ignite", "Wrath of Nature", 60),
            new KeySpell("Ignite", "Thunderclap", 60),
            new KeySpell("Singe", "Singe", 20),
            new KeySpell("Singe", "Embrace of the Void", 20),
            new KeySpell("Singe", "Lightning", 20),
            new KeySpell("Singe", "Water of Nature", 20),
            new KeySpell("Spark", "Spark", 20),
            new KeySpell("Spark", "Glimpse of the Void", 20),
            new KeySpell("Spark", "Bolt", 20),
            new KeySpell("Spark", "Nature's Ire", 20)
        };
    }
}
