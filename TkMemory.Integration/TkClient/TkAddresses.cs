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

using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient
{
    internal static class TkAddresses
    {
        public static class Chat
        {
            public static readonly Address ChatOrBlueSpell = new Address(0x6FE788, new[] { 0x12C });
            public static readonly Address SageOrWhisper = new Address(0x5C07D4, new[] { 0x174 });
        }

        public static class Environment
        {
            public static readonly Address Time = new Address(0x6FE168, new[] { 0xF8 });

            public static class Map
            {
                public static readonly Address Name = new Address(0x6FE204, new[] { 0xF8 });

                public static class Coordinates
                {
                    public static readonly Address X = new Address(0x6FE238, new[] { 0xFC });
                    public static readonly Address Y = new Address(0x6FE238, new[] { 0x100 });
                }
            }
        }

        public static class Group
        {
            public const int PositionOffset = 0x12C;

            public static readonly Address Name = new Address(0x6DD490, new[] { 0x21C });
            public static readonly Address Size = new Address(0x6DD490, new[] { 0x3CB0 });
            public static readonly Address Uid = new Address(0x6DD490, new[] { 0x218 });

            public static class Mana
            {
                public static readonly Address Current = new Address(0x6DD490, new[] { 0x340 });
                public static readonly Address Max = new Address(0x6DD490, new[] { 0x33C });
            }

            public static class Vita
            {
                public static readonly Address Current = new Address(0x6DD490, new[] { 0x338 });
                public static readonly Address Max = new Address(0x6DD490, new[] { 0x334 });
            }
        }

        public static class Entity
        {
            public const int PositionOffset = 0x20C;

            public static readonly Address Count = new Address(0x6DD4AC, new[] { 0x424, 0x38, 0xC });
            public static readonly Address Direction = new Address(0x6FE61C, new[] { 0x1C9 });
            public static readonly Address Name = new Address(0x6FE61C, new[] { 0x12E });
            public static readonly Address Uid = new Address(0x6FE61C, new[] { 0x100 });

            public static class Coordinates
            {
                public static readonly Address X = new Address(0x6FE61C, new[] { 0x104 });
                public static readonly Address Y = new Address(0x6FE61C, new[] { 0x108 });
            }

            public static class Pixels
            {
                public static readonly Address X = new Address(0x6FE61C, new[] { 0x10C });
                public static readonly Address Y = new Address(0x6FE61C, new[] { 0x110 });
            }
        }

        public static class Self
        {
            public static readonly Address Exp = new Address(0x6FE238, new[] { 0x114 });
            public static readonly Address Gold = new Address(0x6FE238, new[] { 0x11C });
            public static readonly Address Level = new Address(0x6FDB3C, new[] { 0x280 });
            public static readonly Address Path = new Address("NexusTK.exe", 0x0029ADFC, new[] { 0x1FC });
            public static readonly Address Name = new Address("NexusTK.exe", 0x001A2AD4);
            public static readonly Address Uid = new Address(0x6DD490, new[] { 0xFC });

            public static class Inventory
            {
                public const int PositionOffset = 0x1FC;

                public static readonly Address DisplayName = new Address(0x6DD490, new[] { 0x16410A });
                public static readonly Address ItemName = new Address(0x6DD490, new[] { 0x1641AA });
                public static readonly Address Quantity = new Address(0x6DD490, new[] { 0x1642EC });
            }

            public static class Mana
            {
                public static readonly Address Current = new Address(0x6FE238, new[] { 0x10C });
                public static readonly Address Max = new Address(0x6FE238, new[] { 0x110 });
            }

            public static class Spells
            {
                public static int PositionOffset = 0x148;
                
                public static readonly Address DisplayName = new Address(0x6DD490, new[] { 0x16A83C });
            }

            public static class Status
            {
                public static readonly Address ActiveEffects = new Address(0x4C1260, new[] { 0x4A4 });
                public static readonly Address LatestActivity = new Address(0x444724, new[] { 0x140 });
                public static readonly Address LatestChange = new Address(0x6FE8C8, new[] { 0xC });
            }

            public static class TargetUids
            {
                public static readonly Address Npc = new Address(0x6FEC64);
                public static readonly Address Player = new Address(0x6FEC60);
                public static readonly Address Spell = new Address(0x6FEC58);
            }

            public static class Vita
            {
                public static readonly Address Current = new Address(0x6FE238, new[] { 0x104 });
                public static readonly Address Max = new Address(0x6FE238, new[] { 0x108 });
            }
        }
    }
}
