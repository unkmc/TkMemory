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
    /// Key spell selection priorities for spells known to Rogues.
    /// </summary>
    public class Rogue
    {
        /// <summary>
        /// When cast the caster will jump behind the target it faces. Useful in combat to attack the back of animals
        /// which is more vulnerable and takes more damage.
        /// </summary>
        public static readonly KeySpell[] Ambush =
        {
            new KeySpell("Ambush", "Ambush", 0),
            new KeySpell("Ambush", "Displacement", 0),
            new KeySpell("Ambush", "Waylay", 0),
            new KeySpell("Ambush", "Reflect", 0)
        };

        /// <summary>
        /// Only works on NPCs. Will stop the engaging enemy from attacking you and turn their sights to another target.
        /// If there is no other target, they will walk around as if no one was there. If you attack a target you cast
        /// amnesia on, they will once again.
        /// </summary>
        public static readonly KeySpell[] Amnesia =
        {
            new KeySpell("Amnesia", "Amnesia", 30),
            new KeySpell("Amnesia", "Forgetfulness", 30),
            new KeySpell("Amnesia", "Free Spirit", 30),
            new KeySpell("Amnesia", "Mislead", 30)
        };

        /// <summary>
        /// When Chance has been cast, 200 mana will drain each second for 10 seconds. During this time you must drop a
        /// total of 170 coins. Casts Invoke when successful and Dishearten when it fails. Must have 30 mana remaining to
        /// cast invoke.
        /// </summary>
        public static readonly BuffKeySpell[] Chance =
        {
            new BuffKeySpell("Chance", "Chance", 1000, 19, 60),
            new BuffKeySpell("Chance", "Randomness", 1000, 19, 60),
            new BuffKeySpell("Chance", "Nature's Choice", 1000, 19, 60),
            new BuffKeySpell("Chance", "Trial by Fire", 1000, 19, 60)
        };

        /// <summary>
        /// Incremental fury. Every 150 seconds the spell can be cast again. It will require more mana, provide more protection,
        /// and boost damage for each consecutive casting. Mana values listed are the lowest possible mana required to cast the
        /// next level of the spell, but if you have more mana it will often take it from you.
        /// </summary>
        public static readonly BuffKeySpell[] Cunning =
        {
            new BuffKeySpell("Baekho's Cunning 1", "Baekho's Cunning", 3000, 938, 150),
            new BuffKeySpell("Baekho's Cunning 2", "Baekho's Cunning", 4200, 938, 150),
            new BuffKeySpell("Baekho's Cunning 3", "Baekho's Cunning", 15634, 938, 150),
            new BuffKeySpell("Baekho's Cunning 4", "Baekho's Cunning", 46658, 938, 150),
            new BuffKeySpell("Baekho's Cunning 5", "Baekho's Cunning", 117667, 938, 150)
        };

        /// <summary>
        /// +40 AC to 4 adjacent creatures.
        /// </summary>
        public static readonly AetheredKeySpell[] Curse =
        {
            // Consumes 2% vita
            new AetheredKeySpell("Curse", "Storm of Misery", 10000, 8),
            new AetheredKeySpell("Curse", "Aura of Wrath", 10000, 8),
            new AetheredKeySpell("Curse", "Aura of Balance", 10000, 8),
            new AetheredKeySpell("Curse", "Karmic Backlash", 10000, 8)
        };

        /// <summary>
        /// Uses 50% of current vita in a strong attack. Brings total current mana to 0. Does current vita + current mana in damage to a target at 0 AC.
        /// </summary>
        public static readonly AetheredKeySpell[] DesperateAttack =
        {
            // Consumes all mana and 50% vita
            new AetheredKeySpell("Desperate Attack", "Desperate Attack", 60, 11),
            new AetheredKeySpell("Desperate Attack", "The Void's Measure", 60, 11),
            new AetheredKeySpell("Desperate Attack", "Beastly Frenzy", 60, 11),
            new AetheredKeySpell("Desperate Attack", "Tilting the Balance", 60, 11)
        };

        /// <summary>
        /// Drain will drain all animals/summons less than 1000 vitality and give you their remaining life. This cannot be cast on other players.
        /// Additional life can accumulate up to double your base vitality.
        /// </summary>
        public static readonly KeySpell[] Drain =
        {
            new KeySpell("Drain", "Drain", 60),
            new KeySpell("Drain", "Drink of Souls", 60),
            new KeySpell("Drain", "Parasite", 60),
            new KeySpell("Drain", "Absorb", 60)
        };

        /// <summary>
        /// Increases the damage and attack of a weapon. It lasts until you take a weapon off or log off the game.
        /// </summary>
        public static readonly KeySpell[] Enchant =
        {
            // TODO: Verify costs
            new KeySpell("Enchant", "Baekho's Subterfuge", 0),
            new KeySpell("Enchant", "Blade's Charm", 0),
            new KeySpell("Enchant", "Specters Blade", 0),
            new KeySpell("Enchant", "Darken", 0),
            new KeySpell("Enchant", "Final Weapon", 0),
            new KeySpell("Enchant", "Baekho's Blade", 6000),
            new KeySpell("Enchant", "Tiger's Fortitude", 0)
        };

        /// <summary>
        /// Takes 2/3 of current vita in a strong attack. The attack does 2x current vitality in damage at 0 AC.
        /// </summary>
        public static readonly AetheredKeySpell[] FocusedBlade =
        {
            // Consumes 2/3 vita
            new AetheredKeySpell("Focused Blade", "Focused Blade", 3000, 38),
            new AetheredKeySpell("Focused Blade", "Burial Dance", 3000, 38),
            new AetheredKeySpell("Focused Blade", "Flowing Energy", 3000, 38),
            new AetheredKeySpell("Focused Blade", "Freeform", 3000, 38)
        };

        /// <summary>
        /// Multiplies attack damage.
        /// </summary>
        public static readonly BuffKeySpell[] Fury =
        {
            new BuffKeySpell("Baekho's Rage", "Baekho's Rage", 2000, 188),
            new BuffKeySpell("Serpent's Fury", "Serpent's Fury", 800, 375, 25),
            new BuffKeySpell("Tiger's Fury", "Tiger's Fury", 90, 625),
            new BuffKeySpell("Tiger's Fury", "Filling the Soul", 90, 625),
            new BuffKeySpell("Tiger's Fury", "Spirit of the Wild", 90, 625),
            new BuffKeySpell("Tiger's Fury", "Ohaeng's Grace", 90, 625),
            new BuffKeySpell("Wolf's Fury", "Wolf's Fury", 30, 625),
            new BuffKeySpell("Wolf's Fury", "Soul's Rage", 30, 625),
            new BuffKeySpell("Wolf's Fury", "Spirit of the Forest", 30, 625),
            new BuffKeySpell("Wolf's Fury", "Augmentation", 30, 625)
        };

        /// <summary>
        /// Targetable spell to restore all vitality.
        /// </summary>
        public static readonly HealKeySpell[] Heal =
        {
            new HealKeySpell("Marasmus' Hand", "Marasmus' Hand", 1500, 2200),
            new HealKeySpell("Marasmus' Hand", "Malady's Kiss", 1500, 2200),
            new HealKeySpell("Marasmus' Hand", "CheeLee's Wink", 1500, 2200),
            new HealKeySpell("Marasmus' Hand", "Bluestone's Smile", 1500, 2200),
            new HealKeySpell("Power Stream", "Power Stream", 1000, 1500),
            new HealKeySpell("Power Stream", "Phantom's Kiss", 1000, 1500),
            new HealKeySpell("Power Stream", "Life Herbs", 1000, 1500),
            new HealKeySpell("Power Stream", "Meditation", 1000, 1500),
            new HealKeySpell("Swift Recovery", "Swift Recovery", 700, 900),
            new HealKeySpell("Swift Recovery", "Renew Energy", 700, 900),
            new HealKeySpell("Swift Recovery", "Loving Dew", 700, 900),
            new HealKeySpell("Swift Recovery", "Invigorate", 700, 900),
            new HealKeySpell("Refresh", "Refresh", 400, 600),
            new HealKeySpell("Refresh", "Soul's Awakening", 400, 600),
            new HealKeySpell("Refresh", "Healing Waters", 400, 600),
            new HealKeySpell("Refresh", "Fire Dance", 400, 600),
            new HealKeySpell("Seal Wounds", "Seal Wounds", 220, 280),
            new HealKeySpell("Seal Wounds", "Spirit Caress", 220, 280),
            new HealKeySpell("Seal Wounds", "Heal Injury", 220, 280),
            new HealKeySpell("Seal Wounds", "Bandage", 220, 280),
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
            new HealKeySpell("Marasmus' Remedy", "Marasmus' Remedy", 5300, 8000),
            new HealKeySpell("Marasmus' Remedy", "Malady's Remedy", 5300, 8000),
            new HealKeySpell("Marasmus' Remedy", "Cheelee's Remedy", 5300, 8000),
            new HealKeySpell("Marasmus' Remedy", "Bluestone's Remedy", 5300, 8000),
            new HealKeySpell("Pioneer's Remedy", "Pioneer's Remedy", 5000, 7500),
            new HealKeySpell("Pioneer's Remedy", "Kwi-Sin Pioneer's Remedy", 5000, 7500),
            new HealKeySpell("Pioneer's Remedy", "Ming Ken Pioneer's Remedy", 5000, 7500),
            new HealKeySpell("Pioneer's Remedy", "Ohaeng Pioneer's Remedy", 5000, 7500),
            new HealKeySpell("Explorer's Remedy", "Explorer's Remedy", 4000, 6000),
            new HealKeySpell("Explorer's Remedy", "Kwi-Sin Explorer's Remedy", 4000, 6000),
            new HealKeySpell("Explorer's Remedy", "Ming Ken Explorer's Remedy", 4000, 6000),
            new HealKeySpell("Explorer's Remedy", "Ohaeng Explorer's Remedy", 4000, 6000),
            new HealKeySpell("Dagger's Remedy", "Dagger's Remedy", 3000, 4500),
            new HealKeySpell("Dagger's Remedy", "Kwi-Sin Dagger's Remedy", 3000, 4500),
            new HealKeySpell("Dagger's Remedy", "Ming Ken Dagger's Remedy", 3000, 4500),
            new HealKeySpell("Dagger's Remedy", "Ohaeng Dagger's Remedy", 3000, 4500),
            new HealKeySpell("Maso's Remedy", "Maso's Remedy", 2000, 3000),
            new HealKeySpell("Maso's Remedy", "Kwi-Sin Maso's Remedy", 2000, 3000),
            new HealKeySpell("Maso's Remedy", "Ming Ken Maso's Remedy", 2000, 3000),
            new HealKeySpell("Maso's Remedy", "Ohaeng Maso's Remedy", 2000, 3000),
            new HealKeySpell("Maro's Remedy", "Maro's Remedy", 1000, 1500),
            new HealKeySpell("Maro's Remedy", "Kwi-Sin Maro's Remedy", 1000, 1500),
            new HealKeySpell("Maro's Remedy", "Ming Ken Maro's Remedy", 1000, 1500),
            new HealKeySpell("Maro's Remedy", "Ohaeng Maro's Remedy", 1000, 1500),
            new HealKeySpell("Soothe", "Soothe", 3, 50) 
        };

        /// <summary>
        /// Increases your weapon damage x9. Makes caster invisible to everyone except group members. In that case they appear
        /// slightly transparent. Can be removed by hitting something or pressing item pickup keys.
        /// </summary>
        public static readonly KeySpell[] Invisible =
        {
            new KeySpell("Invisible", "Invisible", 0),
            new KeySpell("Invisible", "Spirit's Form", 0),
            new KeySpell("Invisible", "Life's Cloak", 0),
            new KeySpell("Invisible", "Glass Form", 0)
        };

        /// <summary>
        /// Uses 50% of current vita in a strong attack. Does 1/2 current vitality plus 2.5x current mana in damage at 0 AC.
        /// </summary>
        public static readonly AetheredKeySpell[] LethalStrike =
        {
            // Consumes 50% vita
            new AetheredKeySpell("Lethal Strike", "Lethal Strike", 1000, 23),
            new AetheredKeySpell("Lethal Strike", "Afterlife's Embrace", 1000, 23),
            new AetheredKeySpell("Lethal Strike", "Ming Ken's Judgement", 1000, 23),
            new AetheredKeySpell("Lethal Strike", "Calculating Blow", 1000, 23)
        };

        /// <summary>
        /// Increases one's own Might by 3.
        /// </summary>
        public static readonly BuffKeySpell[] Might =
        {
            new BuffKeySpell("Might", "Might", 30, 162),
            new BuffKeySpell("Might", "Spiritstrength", 30, 162),
            new BuffKeySpell("Might", "Inner Blessing", 30, 162),
            new BuffKeySpell("Might", "Temper", 30, 162)
        };

        /// <summary>
        /// Attacks 5 aligned targets as long as the caster has room to ambush. 1.8 * Vita + 0.45 * Mana (varies on target) at 0 AC.
        /// </summary>
        public static readonly AetheredKeySpell[] PrecisionBlitz =
        {
            // Consumes all mana and 50% vita
            new AetheredKeySpell("Precision Blitz", "Precision Blitz", 45000, 180),
            new AetheredKeySpell("Precision Blitz", "Hellfire Storm", 45000, 180),
            new AetheredKeySpell("Precision Blitz", "Snake Fangs", 45000, 180),
            new AetheredKeySpell("Precision Blitz", "Shooting Stars", 45000, 180)
        };

        /// <summary>
        /// Slowly restores mana. 1% of your maximum mana each second for 50 seconds. The spell vanishes if you move, get attacked
        /// or have a spell cast on you or by you.
        /// </summary>
        public static readonly BuffKeySpell[] RegenerateMana =
        {
            new BuffKeySpell("Regenerate Mana", "Battle Channeling", 0, 50, 600),
            new BuffKeySpell("Regenerate Mana", "Ancestor's Channeling", 0, 50, 600),
            new BuffKeySpell("Regenerate Mana", "Life-Force Channeling", 0, 50, 600),
            new BuffKeySpell("Regenerate Mana", "Thoughtful channeling", 0, 50, 600)
        };

        /// <summary>
        /// Set traps on the ground that cause damage or status effects when an NPC steps on that tile. Players can only be hit
        /// by traps in PK areas.
        /// </summary>
        public static class SetTrap
        {
            /// <summary>
            /// 500 damage at 0 AC.
            /// </summary>
            public static readonly KeySpell Dart = new KeySpell("Dart Trap", "Dart Trap", 20);

            /// <summary>
            /// Causes temporary blindness.
            /// </summary>
            public static readonly KeySpell Flash = new KeySpell("Flash Trap", "Flash Trap", 120);

            /// <summary>
            /// 500 damage at 0 AC. Trap remains for a short period and can be triggered multiple times.
            /// </summary>
            public static readonly KeySpell RepeatingDart = new KeySpell("Repeating Dart", "Repeating Dart", 220);

            /// <summary>
            /// Increases AC (i.e. decreases defense) by 20 points.
            /// </summary>
            public static readonly BuffKeySpell Snare = new BuffKeySpell("Snare", "Snare", 320, 75);

            /// <summary>
            /// 3,500 damage at 0 AC.
            /// </summary>
            public static readonly KeySpell Spear = new KeySpell("Spear Trap", "Spear Trap", 520);

            /// <summary>
            /// Temporarily poisons the target for 1,000 vita in damage per second.
            /// </summary>
            public static readonly BuffKeySpell PoisonDart = new BuffKeySpell("Poison Dart", "Poison Dart", 620, 224);

            /// <summary>
            /// 11,650 damage at 0 AC.
            /// </summary>
            public static readonly KeySpell Death = new KeySpell("Death Trap", "Death Trap", 1520);
            
            /// <summary>
            /// Puts target to sleep for 1.3x damage on next attack.
            /// </summary>
            public static readonly BuffKeySpell Sleep = new BuffKeySpell("Sleep Trap", "Sleep Trap", 2500, 38);

            /// <summary>
            /// Drains 5,000 mana every second for its duration unless the rogue switches server. Trap remains for 20 seconds,
            /// even if the rogue's mana hits zero. The first person who walks on the trap will cast an Assault attack. Trap
            /// cannot be seen by spot traps. Player (PK) - Takes 50% of player's vita. Attacks secondary targets with that
            /// much vita at 0 AC. No effect outside of PK areas. Creature - Takes 75% of player's vita. Attacks secondary
            /// targets with that much vita at 0 AC. Will not harm players. After casting assault, the spell does an additional
            /// 35,000 damage at 0 AC.
            /// </summary>
            public static readonly BuffKeySpell Bladestorm = new BuffKeySpell("Bladestorm", "Bladestorm", 1000, 21, 120);
        }

        /// <summary>
        /// Increases attack evasion.
        /// </summary>
        public static readonly BuffKeySpell[] ShadowFigure =
        {
            new BuffKeySpell("Shadow Figure", "Shadow Figure", 60, 600),
            new BuffKeySpell("Shadow Figure", "Spirit Warrior", 60, 600),
            new BuffKeySpell("Shadow Figure", "Natural Defense", 60, 600),
            new BuffKeySpell("Shadow Figure", "Ohaeng's Armor", 60, 600)
        };

        /// <summary>
        /// Spots Traps on ground and marks them off as Steel daggers. Daggers will remain on screen for as long as you don't walk off it.
        /// This only spots traps set by Rogues, not NPC ambush traps in Mythic caves.
        /// </summary>
        public static readonly AetheredKeySpell SpotTraps = new AetheredKeySpell("Spot Traps", "Spot Traps", 100, 6);

        /// <summary>
        /// Targetable lightning attack.
        /// </summary>
        public static readonly KeySpell[] Zap =
        {
            new KeySpell("Ignite", "Ignite", 60),
            new KeySpell("Ignite", "Spirit Strike", 60),
            new KeySpell("Ignite", "Wrath of Nature", 60),
            new KeySpell("Ignite", "Thunderclap", 60),
            new KeySpell("Singe", "Singe", 20),
            new KeySpell("Singe", "Embrace of the Void", 20),
            new KeySpell("Singe", "Lightning", 20),
            new KeySpell("Singe", "Water of Nature", 20)
        };
    }
}
