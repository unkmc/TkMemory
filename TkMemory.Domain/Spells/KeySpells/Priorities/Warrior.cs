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
    /// Key spell selection priorities for spells known to Warriors.
    /// </summary>
    public class Warrior
    {
        /// <summary>
        /// 4-target Whirlwind in the direction the caster is facing. Takes 50% of the warrior's vita and attacks with that much damage
        /// at 0 AC. Vita is lost even if no targets are in range.
        /// </summary>
        public static readonly AetheredKeySpell[] Assault =
        {
            // Consumes 50% vita
            new AetheredKeySpell("Assault", "Assault", 5000, 80),
            new AetheredKeySpell("Assault", "Death's Challenge", 5000, 80),
            new AetheredKeySpell("Assault", "Cold Snap", 5000, 80),
            new AetheredKeySpell("Assault", "Volley", 5000, 80)
        };

        /// <summary>
        /// Melee attacks can also hit the target standing behind the caster.
        /// </summary>
        public static readonly BuffKeySpell[] Backstab =
        {
            new BuffKeySpell("Backstab", "Backstab", 90, 625),
            new BuffKeySpell("Backstab", "Back Battle", 90, 625),
            new BuffKeySpell("Backstab", "Back Attack", 90, 625),
            new BuffKeySpell("Backstab", "Back Damage", 90, 625)
        };

        /// <summary>
        /// Uses 2/3 of current vita to critical strike a target for 75% current vitality in damage.
        /// </summary>
        public static readonly AetheredKeySpell[] Berserk =
        {
            // Consumes 2/3 vita
            new AetheredKeySpell("Berserk", "Berserk", 120, 12),
            new AetheredKeySpell("Berserk", "No Fear", 120, 12),
            new AetheredKeySpell("Berserk", "Tiger's Pounce", 120, 12),
            new AetheredKeySpell("Berserk", "Wind's Blast", 120, 12),
            new AetheredKeySpell("Berserk", "Feral Berserk", 120, 12)
        };

        /// <summary>
        /// Increase Hit statistic to reduce missed melee attacks.
        /// </summary>
        public static readonly BuffKeySpell[] Blessing =
        {
            new BuffKeySpell("Blessing", "Greater Blessing", 250, 625),
            new BuffKeySpell("Blessing", "Bless", 60, 625),
            new BuffKeySpell("Blessing", "Sanctification", 60, 625),
            new BuffKeySpell("Blessing", "Tribal Gathering", 60, 625),
            new BuffKeySpell("Blessing", "Strength of Purpose", 60, 625)
        };

        /// <summary>
        /// Prevents curses such as Vex, Scourge, Forsake, etc. Can be dispelled.
        /// </summary>
        public static readonly BuffKeySpell[] CurseProof =
        {
            new BuffKeySpell("Curse Proof", "Hoche", 5000, 60, 180),
            new BuffKeySpell("Curse Proof", "Immunity", 5000, 60, 180),
            new BuffKeySpell("Curse Proof", "Forrest Blessing", 5000, 60, 180), // TODO: Forrest or forest?
            new BuffKeySpell("Curse Proof", "Forest Blessing", 5000, 60, 180),
            new BuffKeySpell("Curse Proof", "Magic's Shield", 5000, 60, 180)
        };

        /// <summary>
        /// Increases the damage and attack of a weapon. It lasts until you take a weapon off or log off the game.
        /// </summary>
        public static readonly KeySpell[] Enchant =
        {
            new KeySpell("Enchant", "Chung Ryong's Wrath", 20000),
            new KeySpell("Enchant", "Dragon's Harness", 10000),
            new KeySpell("Enchant", "Dragon's Flame", 10000),
            new KeySpell("Enchant", "Viper's Venom", 5000),
            new KeySpell("Enchant", "Ingress", 90),
            new KeySpell("Enchant", "Hand of Darkness", 90),
            new KeySpell("Enchant", "Dragon's Claw", 90),
            new KeySpell("Enchant", "Razor's Edge", 90),
            new KeySpell("Enchant", "Infuse", 90),
            new KeySpell("Enchant", "Tincture of the Unknown", 90),
            new KeySpell("Enchant", "Tiger's Claw", 90),
            new KeySpell("Enchant", "Whetstone", 90),
            new KeySpell("Enchant", "Enchant", 60),
            new KeySpell("Enchant", "Spiritual Aid", 60),
            new KeySpell("Enchant", "Oneness", 60),
            new KeySpell("Enchant", "Strengthen weapon", 60)
        };

        /// <summary>
        /// Melee attack can also hit a target standing to the side of the caster. Only one side target can be hit each time.
        /// </summary>
        public static readonly BuffKeySpell[] Flank =
        {
            new BuffKeySpell("Flank", "Flank", 90, 625),
            new BuffKeySpell("Flank", "Flank Battle", 90, 625),
            new BuffKeySpell("Flank", "Flank Attack", 90, 625),
            new BuffKeySpell("Flank", "Flank Damage", 90, 625)
        };

        /// <summary>
        /// Multiplies attack damage.
        /// </summary>
        public static readonly BuffKeySpell[] Fury =
        {
            new BuffKeySpell("Spirit Fury", "Spirit Fury", 500, 625),
            new BuffKeySpell("Dragon's Fury", "Dragon's Fury", 150, 625),
            new BuffKeySpell("Dragon's Fury", "Strength of Ancestors", 150, 625),
            new BuffKeySpell("Dragon's Fury", "Spirit of the Dragon", 150, 625),
            new BuffKeySpell("Dragon's Fury", "Ohaeng's Anger", 150, 625),
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
            new HealKeySpell("KaKhan's Vigor", "KaKhan's Vigor", 1900, 2200),
            new HealKeySpell("KaKhan's Vigor", "Blight's Vigor", 1900, 2200),
            new HealKeySpell("KaKhan's Vigor", "Changsu's Vigor", 1900, 2200),
            new HealKeySpell("KaKhan's Vigor", "Bringer's Vigor", 1900, 2200),
            new HealKeySpell("Health's Return", "Health's Return", 1000, 1200),
            new HealKeySpell("Health's Return", "Mending of the Soul", 1000, 1200),
            new HealKeySpell("Health's Return", "Spirit's Salvation", 1000, 1200),
            new HealKeySpell("Health's Return", "Gift of Life", 1000, 1200),
            new HealKeySpell("Hunang's Relief", "Hunang's Relief", 800, 800),
            new HealKeySpell("Hunang's Relief", "From the Brink", 800, 800),
            new HealKeySpell("Hunang's Relief", "Nature's Slave", 800, 800),
            new HealKeySpell("Hunang's Relief", "Life's Essence", 800, 800),
            new HealKeySpell("Salvation", "Salvation", 400, 500),
            new HealKeySpell("Salvation", "Redemption", 400, 500),
            new HealKeySpell("Salvation", "Ointment of Light", 400, 500),
            new HealKeySpell("Salvation", "Return of Life", 400, 500),
            new HealKeySpell("Vigor", "Vigor", 180, 280),
            new HealKeySpell("Vigor", "Touch of Health", 180, 280),
            new HealKeySpell("Vigor", "Balm", 180, 280),
            new HealKeySpell("Vigor", "Restoration", 180, 280),
            new HealKeySpell("Relief", "Relief", 120, 200),
            new HealKeySpell("Relief", "Renew Essence", 120, 200),
            new HealKeySpell("Relief", "Lifesong", 120, 200),
            new HealKeySpell("Relief", "Sweet Waters", 120, 200),
            new HealKeySpell("Soothe", "Soothe", 3, 50)
        };

        /// <summary>
        /// Increases Damage statistic. Every 2 Damage adds 5 more damage (subsequently multiplied by fury/rage).
        /// </summary>
        public static readonly BuffKeySpell[] Potence =
        {
            new BuffKeySpell("Potence", "Potence", 30, 625),
            new BuffKeySpell("Potence", "Spirit Arm", 30, 625),
            new BuffKeySpell("Potence", "Touch of the Bear", 30, 625),
            new BuffKeySpell("Potence", "Sharpen", 30, 625)
        };

        /// <summary>
        /// Incremental fury. Every 120 seconds the spell can be cast again. It will require more mana, lower AC more, and boost damage
        /// for each consecutive casting. In addition, the spell will drain a certain amount of vitality after it wears out. Mana values
        /// listed are the lowest possible mana required to cast the next level of the spell, but if you have more mana it will often
        /// take it from you.
        /// </summary>
        public static readonly BuffKeySpell[] Rage =
        {
            new BuffKeySpell("Chung Ryong's Rage 1", "Chung Ryong's Rage", 2000, 120, 938),
            new BuffKeySpell("Chung Ryong's Rage 2", "Chung Ryong's Rage", 7200, 120, 938),
            new BuffKeySpell("Chung Ryong's Rage 3", "Chung Ryong's Rage", 18050, 120, 938),
            new BuffKeySpell("Chung Ryong's Rage 4", "Chung Ryong's Rage", 33800, 120, 938),
            new BuffKeySpell("Chung Ryong's Rage 5", "Chung Ryong's Rage", 72200, 120, 938),
            new BuffKeySpell("Chung Ryong's Rage 6", "Chung Ryong's Rage", 145800, 120, 938)
        };

        /// <summary>
        /// Attack up to 12 surrounding targets (or 13 if person is standing on top of a creature). Requires 10% of current mana to cast.
        /// Does approximately 0.4875 vita + 0.1 mana at 0 AC. Consumes 95% of caster's vita.
        /// </summary>
        public static readonly AetheredKeySpell[] Rampage =
        {
            // Consumes 10% of current mana and 95% vita
            new AetheredKeySpell("Rampage", "Rampage", 0, 180),
            new AetheredKeySpell("Rampage", "Destruction Wave", 0, 180),
            new AetheredKeySpell("Rampage", "Aura Explosion", 0, 180),
            new AetheredKeySpell("Rampage", "Thousand Blades", 0, 180)
        };

        /// <summary>
        /// Requires 50% of current mana to cast. Regenerates 1% total mana each second for 50 seconds as long as you do not move and
        /// are not attacked.
        /// </summary>
        public static readonly BuffKeySpell[] RegenerateMana =
        {
            // Consumes 50% of current mana
            new BuffKeySpell("Regenerate Mana", "Energize", 0, 50, 600),
            new BuffKeySpell("Regenerate Mana", "Exhilarate", 0, 50, 600),
            new BuffKeySpell("Regenerate Mana", "Renew", 0, 50, 600),
            new BuffKeySpell("Regenerate Mana", "Reflection", 0, 50, 600)
        };

        /// <summary>
        /// Siege does a critical strike and leaves the caster with 25% vita left. Damage to target is 1.875x current vitality
        /// plus 0.5x current mana at 0 AC.
        /// </summary>
        public static readonly AetheredKeySpell[] Siege =
        {
            // Consumes 75% vita
            new AetheredKeySpell("Siege", "Siege", 8000, 43),
            new AetheredKeySpell("Siege", "Soul's Freedom", 8000, 43),
            new AetheredKeySpell("Siege", "Life's End", 8000, 43),
            new AetheredKeySpell("Siege", "Winter Chill", 8000, 43)
        };

        /// <summary>
        /// Attack that does .0245x Vita + 11.435x Might in damage towards a target.
        /// </summary>
        public static readonly AetheredKeySpell Slash = new AetheredKeySpell("Slash", "Slash", 180, 1);

        /// <summary>
        /// Spots Ambushes on ground and marks them off as Steel daggers. Indicators will disappear if you move where they
        /// are off-screen or if you refresh the screen. Mythic fall zones are not detected, only NPC ambushes.
        /// </summary>
        public static readonly AetheredKeySpell[] SpotTraps =
        {
            new AetheredKeySpell("Spot Traps", "Watchful Eye", 90, 37),
            new AetheredKeySpell("Spot Traps", "Spirit's Whisper", 90, 37),
            new AetheredKeySpell("Spot Traps", "Creature's Guidance", 90, 37),
            new AetheredKeySpell("Spot Traps", "Spot Unbalance", 90, 37)
        };

        /// <summary>
        /// Stuns adjacent NPCs. Does not cause Mythic bosses to heal themselves. Takes 2% vita each time it is cast.
        /// </summary>
        public static readonly BuffKeySpell[] Stun =
        {
            new BuffKeySpell("Stun", "Scream", 10000, 5, 7),
            new BuffKeySpell("Stun", "Violent Voice", 10000, 5, 7),
            new BuffKeySpell("Stun", "Soul Shout", 10000, 5, 7),
            new BuffKeySpell("Stun", "Raging Roar", 10000, 5, 7)
        };

        /// <summary>
        /// Whirlwind does critical strike and leaves the caster with 10% vita left if they follow Ming Ken or Ohaeng or
        /// 10 vita left if they follow Kwi-Sin. Damage to target is 1.575 times current vitality. If player is Kwi sin,
        /// they do 1.75 times vitality in damage at 0 AC.
        /// </summary>
        public static readonly AetheredKeySpell[] Whirlwind =
        {
            // Consumes 90% vita
            new AetheredKeySpell("Whirlwind", "Whirlwind", 600, 30),
            new AetheredKeySpell("Whirlwind", "Death's Angel", 600, 30), // Consumes all but 10 vita
            new AetheredKeySpell("Whirlwind", "Nature's Own", 600, 30),
            new AetheredKeySpell("Whirlwind", "Bladedance", 600, 30)
        };

        /// <summary>
        /// Targetable attack that does 1 damage but draws the attention of the NPC.
        /// </summary>
        public static readonly KeySpell[] Zap =
        {
            new KeySpell("Taunt", "Taunt", 1),
            new KeySpell("Taunt", "Anger", 1),
            new KeySpell("Taunt", "Tease", 1),
            new KeySpell("Taunt", "Mock", 1)
        };
    }
}
