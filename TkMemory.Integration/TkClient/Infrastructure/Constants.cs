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

namespace TkMemory.Integration.TkClient.Infrastructure
{
    internal class Constants
    {
        public const string DefaultEncoding = "UTF-16";

        public static class SubPaths
        {
            public static readonly string[] Mage =
            {
                "Mage",
                "Ju Jak",
                "Diviner",
                "Geomancer",
                "Shaman"
            };

            public static readonly string[] Poet =
            {
                "Poet",
                "Hyun Moo",
                "Druid",
                "Monk",
                "Muse"
            };

            public static readonly string[] Rogue =
            {
                "Rogue",
                "Baekho",
                "Merchant",
                "Spy",
                "Ranger"
            };

            public static readonly string[] Warrior =
            {
                "Warrior",
                "Chung Ryong",
                "Barbarian",
                "Chongun",
                "Do"
            };
        }
    }
}
