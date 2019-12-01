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
    /// Key spell selection priorities for spells known to Mages.
    /// </summary>
    public class Mage
    {
        /// <summary>
        /// Blinds the target causing it to stop moving. It will still be able to attack adjacent players.
        /// </summary>
        public static readonly BuffKeySpell[] Blind =
        {
            new BuffKeySpell("Blind", "Blind", 90, 50),
            new BuffKeySpell("Blind", "Dark Veil", 90, 50),
            new BuffKeySpell("Blind", "Winter's Shadow", 90, 50),
            new BuffKeySpell("Blind", "Ice Glare", 90, 50)
        };

        /// <summary>
        /// Confuses the target causing it to attack other NPCs.
        /// </summary>
        public static readonly KeySpell[] Confuse =
        {
            new KeySpell("Confuse", "Confuse", 90),
            new KeySpell("Confuse", "Curse of the Void", 90),
            new KeySpell("Confuse", "Dispise Friend", 90), // TODO: Dispise or Despise?
            new KeySpell("Confuse", "Despise Friend", 90),
            new KeySpell("Confuse", "Chaos Rain", 90)
        };

        /// <summary>
        /// Consumes all mana and does 2.5x mana damage to the target at 0 AC. Cannot be resisted.
        /// </summary>
        public static readonly AetheredKeySpell[] DoomsFire =
        {
            // Consumes all mana
            new AetheredKeySpell("Doom's Fire", "Doom's fire", 15275, 65),
            new AetheredKeySpell("Doom's Fire", "Death's Awakening", 15275, 65),
            new AetheredKeySpell("Doom's Fire", "Soul Rip", 15275, 65),
            new AetheredKeySpell("Doom's Fire", "Final Blow", 15275, 65)
        };

        /// <summary>
        /// Disables a target from moving. The next attack upon the target will do 1.3x the normal damage.
        /// </summary>
        public static readonly BuffKeySpell[] Doze =
        {
            new BuffKeySpell("Doze", "Doze", 30, 10, 36),
            new BuffKeySpell("Doze", "Void's Touch", 30, 10, 36),
            new BuffKeySpell("Doze", "Still Ethers", 30, 10, 36),
            new BuffKeySpell("Doze", "Still Waters", 30, 10, 36)
        };

        /// <summary>
        /// Restores all mana when cast. If it is cast with high mana, it will restore up
        /// to 1/3 of your maximum mana in vitality points. This can temporarily give you
        /// more than your maximum vita, but you will be returned to your max vita should
        /// you be healed.
        /// </summary>
        public static readonly AetheredKeySpell Evocation =
            new AetheredKeySpell("Ju Jak Evocation", "Ju Jak Evocation", 0, 500);

        /// <summary>
        /// Targetable spell to restore vitality.
        /// </summary>
        public static readonly HealKeySpell[] Heal =
        {
            new HealKeySpell("Solace of LinSkrae", "Solace of LinSkrae", 4800, 16000),
            new HealKeySpell("Solace of LinSkrae", "Laughter of Sagu", 4800, 16000),
            new HealKeySpell("Solace of LinSkrae", "Wisdom of Orb", 4800, 16000),
            new HealKeySpell("Solace of LinSkrae", "Blessing of Hroth", 4800, 16000),
            new HealKeySpell("Energy Flow", "Energy Flow", 2400, 8000),
            new HealKeySpell("Energy Flow", "Spirit Heal", 2400, 8000),
            new HealKeySpell("Energy Flow", "Nature's Milk", 2400, 8000),
            new HealKeySpell("Energy Flow", "Peaceful Bliss", 2400, 8000),
            new HealKeySpell("Bekyun's Heal", "Bekyun's Heal", 1200, 4000),
            new HealKeySpell("Bekyun's Heal", "Death Denied", 1200, 4000),
            new HealKeySpell("Bekyun's Heal", "One With Life", 1200, 4000),
            new HealKeySpell("Bekyun's Heal", "Balanced Touch", 1200, 4000),
            new HealKeySpell("Solace", "Solace", 600, 2000),
            new HealKeySpell("Solace", "Festival of Souls", 600, 2000),
            new HealKeySpell("Solace", "Nature's Bounty", 600, 2000),
            new HealKeySpell("Solace", "Ohaeng's Blessing", 600, 2000),
            new HealKeySpell("Rejuvenate", "Rejuvenate", 180, 800),
            new HealKeySpell("Rejuvenate", "Still Embrace", 180, 800),
            new HealKeySpell("Rejuvenate", "Infuse Life", 180, 800),
            new HealKeySpell("Rejuvenate", "Healing Rain", 180, 800),
            new HealKeySpell("Heal", "Heal", 120, 500),
            new HealKeySpell("Heal", "Ancestor's Touch", 120, 500),
            new HealKeySpell("Heal", "Life Flow", 120, 500),
            new HealKeySpell("Heal", "Infuse Life-Force", 120, 500),
            new HealKeySpell("Recover", "Recover", 100, 200),
            new HealKeySpell("Recover", "Spirit's Embrace", 100, 200),
            new HealKeySpell("Recover", "Infuse Energy", 100, 200),
            new HealKeySpell("Recover", "Life's River", 100, 200),
            new HealKeySpell("Mend Wounds", "Mend Wounds", 80, 100),
            new HealKeySpell("Mend Wounds", "Spiritual Cure", 80, 100),
            new HealKeySpell("Mend Wounds", "Nature's Kiss", 80, 100),
            new HealKeySpell("Mend Wounds", "Cooling Touch", 80, 100),
            new HealKeySpell("Fleshspeak", "Fleshspeak", 60, 50),
            new HealKeySpell("Fleshspeak", "Spiritsong", 60, 50),
            new HealKeySpell("Fleshspeak", "Helping Hand", 60, 50),
            new HealKeySpell("Fleshspeak", "Heal Others", 60, 50)
        };

        /// <summary>
        /// Non-targetable spell to restore vitality of oneself.
        /// </summary>
        public static readonly HealKeySpell[] HealSelf =
        {
            new HealKeySpell("Soothe", "Soothe", 3, 50)
        };

        /// <summary>
        /// Takes 70% of Mana and takes an additional 1,000 mana and does 1.8x mana in
        /// damage to any target at 0 AC. Cannot be resisted. (ClassicTK has increased
        /// damage to at least 2.0x, possibly 2.15x.)
        /// </summary>
        public static readonly AetheredKeySpell[] Hellfire =
        {
            // Consumes 70% of mana plus 1,000
            new AetheredKeySpell("Hellfire", "Hellfire", 1000, 19),
            new AetheredKeySpell("Hellfire", "Consume Soul", 1000, 19),
            new AetheredKeySpell("Hellfire", "Flesh Eaters", 1000, 19),
            new AetheredKeySpell("Hellfire", "Hurricane", 1000, 19)
        };

        /// <summary>
        /// Cast Hellfire on 7 targets in a line in front of the mage.
        /// Takes 50% vita and 100% mana to cast.
        /// 0.5 * Vita + 2 * Mana in damage at 0 AC.
        /// </summary>
        public static readonly AetheredKeySpell[] Incineration =
        {
            // Consumes all mana and 50% vita; exact cost is unknown
            new AetheredKeySpell("Incineration", "Incineration", 505000, 180),
            new AetheredKeySpell("Incineration", "Symphony of Destruction", 505000, 180),
            new AetheredKeySpell("Incineration", "Winter's Calamity", 505000, 180),
            new AetheredKeySpell("Incineration", "Meteor Storm", 505000, 180)
        };

        /// <summary>
        /// 5-way Hellfire attack that takes all mana when cast and applies 1.5x mana in damage
        /// at 0 AC to the targets.
        /// </summary>
        public static readonly AetheredKeySpell[] Inferno =
        {
            // Consumes all mana
            new AetheredKeySpell("Inferno", "Inferno", 600, 70),
            new AetheredKeySpell("Inferno", "Death's door", 600, 70),
            new AetheredKeySpell("Inferno", "Nature's denial", 600, 70),
            new AetheredKeySpell("Inferno", "Steel storm", 600, 70)
        };

        /// <summary>
        /// Non-targetable scourge on a random NPC within range. (Exclusive to ClassicTK)
        /// </summary>
        public static readonly BuffKeySpell[] MagisBane =
        {
            new BuffKeySpell("Magi's Bane", "Magi's Bane", 120, 187) // TODO: Verify cost and duration
        };

        /// <summary>
        /// Mass paralyze 3x3 grouping.
        /// </summary>
        public static readonly BuffKeySpell[] MassParalyze =
        {
            // Mass paralyze a 3x3 group
            new BuffKeySpell("Mass Paralyze", "Forced cage", 3200, 40),
            new BuffKeySpell("Mass Paralyze", "Soul Shackles", 3200, 40),
            new BuffKeySpell("Mass Paralyze", "Frozen Tundra", 3200, 40),
            new BuffKeySpell("Mass Paralyze", "Fog of Encumbrance", 3200, 40)
        };

        /// <summary>
        /// Disables a target from moving. Target also cannot attack. Cannot be cast on players.
        /// It has a fail rate dependent on Will.
        /// </summary>
        public static readonly BuffKeySpell[] Paralyze =
        {
            new BuffKeySpell("Paralyze", "Incantation of chains", 3200, 40),
            new BuffKeySpell("Paralyze", "Paralyze", 100, 20),
            new BuffKeySpell("Paralyze", "Spirit Leash", 100, 20),
            new BuffKeySpell("Paralyze", "Cold Binds", 100, 20),
            new BuffKeySpell("Paralyze", "Lockup", 100, 20),
            new BuffKeySpell("Paralyze", "Static", 5, 10)
        };

        /// <summary>
        /// Disables a target from moving. The next attack upon the target will do 1.3x the
        /// normal damage. Sleep cannot be cast on players.
        /// </summary>
        public static readonly BuffKeySpell[] Sleep =
        {
            // TODO: Verify duration
            new BuffKeySpell("Sleep", "Sleep", 300, 10, 18),
            new BuffKeySpell("Sleep", "Sweet Musings", 300, 10, 18),
            new BuffKeySpell("Sleep", "Essence of Poppies", 300, 10, 18),
            new BuffKeySpell("Sleep", "Stillness", 300, 10, 18)
        };

        /// <summary>
        /// Poisons monster targets for a random amount of time. Does 1000 damage a second,
        /// disregarding armor class, on other players. Does more damage per second to animals.
        /// Poison will not kill a target but rather bring them to the lowest possible health.
        /// </summary>
        public static readonly BuffKeySpell[] Venom =
        {
            // Duration is actually random; 24 seconds was arbitrarily chosen
            new BuffKeySpell("Venom", "Venom", 60, 24),
            new BuffKeySpell("Venom", "Spirit's Leech", 60, 24),
            new BuffKeySpell("Venom", "Snake Bite", 60, 24),
            new BuffKeySpell("Venom", "Corruption", 60, 24)
        };

        /// <summary>
        /// Gives +30 AC to the target. Each Positive AC point is 1% damage given to the
        /// attacker. Higher armor class is therefore worse.
        /// </summary>
        public static readonly BuffKeySpell[] Vex =
        {
            new BuffKeySpell("Vex", "Suppress", 120, 187),
            new BuffKeySpell("Vex", "Vex", 60, 425),
            new BuffKeySpell("Vex", "Death's Face", 60, 425),
            new BuffKeySpell("Vex", "Un-natural Selection", 60, 425),
            new BuffKeySpell("Vex", "Flaw", 60, 425),
            new BuffKeySpell("Vex", "Pestilence", 5, 15),
            new BuffKeySpell("Snared", "Snared", 0, 0)
        };

        /// <summary>
        /// Targetable lightning attack.
        /// </summary>
        public static readonly KeySpell[] Zap =
        {
            new KeySpell("Volcanic Blast", "Volcanic Blast", 550), // 5-way
            new KeySpell("Lava Surge", "Lava Surge", 210), // 5-way
            new KeySpell("Stormstrike", "Stormstrike", 150),
            new KeySpell("Stormstrike", "River of Blood", 150),
            new KeySpell("Stormstrike", "Natural Disaster", 150),
            new KeySpell("Stormstrike", "Winds of Disaster", 150),
            new KeySpell("Fissure", "Fissure", 120), // 5-way
            new KeySpell("Call Lightning", "Call Lightning", 120),
            new KeySpell("Call Lightning", "Death Scream", 120),
            new KeySpell("Call Lightning", "Nature's Wounding", 120),
            new KeySpell("Call Lightning", "Rain of Fire", 120),
            new KeySpell("Impact", "Impact", 120),
            new KeySpell("Impact", "Soul Spike", 120),
            new KeySpell("Impact", "Treefall", 120),
            new KeySpell("Impact", "Shatter", 120),
            new KeySpell("Ion", "Ion", 80),
            new KeySpell("Ion", "Soul Strike", 80),
            new KeySpell("Ion", "Tree Dart", 80),
            new KeySpell("Ion", "Sunstroke", 80),
            new KeySpell("Ignite", "Ignite", 80),
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
            new KeySpell("Spark", "Nature's Ire", 20),
            new KeySpell("Thunder Bolt", "Thunder Bolt", 5)
        };

        /// <summary>
        /// Non-targetable lightning attack against all targets adjacent to caster.
        /// </summary>
        public static readonly KeySpell[] ZapSurrounding =
        {
            new KeySpell("Volcanic Blast", "Volcanic Blast", 550), // Target-able
            new KeySpell("Lava Surge", "Lava Surge", 210), // Target-able
            new KeySpell("Tempest", "Tempest", 310),
            new KeySpell("Tempest", "Dance Macabre", 310),
            new KeySpell("Tempest", "Wilding", 310),
            new KeySpell("Tempest", "Chain Lightning", 310),
            new KeySpell("Fissure", "Fissure", 120), // Target-able
            new KeySpell("Electrocute", "Electrocute", 250),
            new KeySpell("Electrocute", "Eater of the Dead", 250),
            new KeySpell("Electrocute", "Forest's Discord", 250),
            new KeySpell("Electrocute", "Shatter Storm", 250),
            new KeySpell("Explode", "Explode", 180),
            new KeySpell("Explode", "Soul Chasm", 180),
            new KeySpell("Explode", "Winter's Vortex", 180),
            new KeySpell("Explode", "Volcano", 180),
            new KeySpell("Ion Charge", "Ion Charge", 120),
            new KeySpell("Ion Charge", "Crescendo", 120),
            new KeySpell("Ion Charge", "Flight of Arrows", 120),
            new KeySpell("Ion Charge", "Blazing Sands", 120),
            new KeySpell("Erupt", "Erupt", 80),
            new KeySpell("Erupt", "Soulstorm", 80),
            new KeySpell("Erupt", "Avalance", 80),
            new KeySpell("Erupt", "Deluge", 80)
        };
    }
}
