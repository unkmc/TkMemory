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

namespace TkMemory.Domain.Items
{
    internal class Priorities
    {
        public const string Axe = "Axe";

        public const string MiningPick = "Mining Pick";

        public static readonly string[] Mount =
        {
            "Ninetails mount",
            "Pegasus mount",
            "Scorpion mount",
            "Zebra mount",
            "Ceratops mount",
            "Eagle mount",
            "Fennec mount",
            "Firetail mount",
            "Fox mount",
            "Headless horseman's horse",
            "Muddy boots mount",
            "Pomeranian mount",
            "Rhino mount",
            "Bull mount",
            "Chicken mount",
            "Deer horn",
            "Dragon dog",
            "Elephant mount",
            "Horse mount",
            "Lamb mount",
            "Lion mount",
            "Mountain goat pan flute",
            "Pig mount",
            "Warthog mount"
        };

        public static readonly Restoration[] RestoreManaMinor =
        {
            new Restoration("Rice Wine", 30),
            new Restoration("Root Liquor", 30),
            new Restoration("Memory Blossom", 30),
            new Restoration("Herb Pipe", 300),
            new Restoration("Rich Wine", 350),
            new Restoration("Sea Poems", 500),
            new Restoration("Moon Wine", 80),
            new Restoration("Thick Wine", 40),
            new Restoration("Sonhi Pipe", 450),
            new Restoration("Aged Wine", 100),
            new Restoration("Iron Statue", 250),
            new Restoration("Ogre Drought", 325),
            new Restoration("Wine", 25),
            new Restoration("Ogre Cider", 100),
            new Restoration("Onyx Shard", 1000)
        };

        public static readonly Restoration[] RestoreManaMajor =
        {
            new Restoration("Sea Poems", 500),
            new Restoration("Herb Pipe", 300),
            new Restoration("Rich Wine", 350),
            new Restoration("Sonhi Pipe", 450),
            new Restoration("Ogre Drought", 325),
            new Restoration("Iron Statue", 250), 
            new Restoration("Rice Wine", 30),
            new Restoration("Memory Blossom", 30),
            new Restoration("Root Liquor", 30),
            new Restoration("Onyx Shard", 1000),
            new Restoration("Aged Wine", 100),
            new Restoration("Moon Wine", 80),
            new Restoration("Ogre Cider", 100),
            new Restoration("Thick Wine", 40),
            new Restoration("Wine", 25)
        };

        public static readonly Restoration[] RestoreVita =
        {
            new Restoration("Ginseng", 2000),
            new Restoration("Broiled Meat", 1500),
            new Restoration("Boiled Fish", 1000),
            new Restoration("Roast Chicken", 1000),
            new Restoration("Tiger's Heart", 1000),
            new Restoration("Delicious Fish", 960),
            new Restoration("Grilled Beef", 800),
            new Restoration("Watermelon", 800),
            new Restoration("Tasty Fish", 540),
            new Restoration("Bear's Liver", 500),
            new Restoration("Lean Beef", 500),
            new Restoration("Large Fish", 440),
            new Restoration("Seaweed", 400),
            new Restoration("Yummier Rabbit Meat", 400),
            new Restoration("Medium Fish", 360),
            new Restoration("Fine Snake Meat", 320),
            new Restoration("Life Blossom", 300),
            new Restoration("Noodles", 300),
            new Restoration("Small Fish", 300),
            new Restoration("Yummy Rabbit Meat", 280),
            new Restoration("Antler", 248),
            new Restoration("Fine Rabbit Meat", 200),
            new Restoration("Horse Meat", 200),
            new Restoration("Violet Potion", 200),
            new Restoration("Scrawny Fish", 180),
            new Restoration("Pork", 128),
            new Restoration("Putrid Fish", 120),
            new Restoration("Bird Meat", 100),
            new Restoration("Blue Potion", 100),
            new Restoration("Boiled Beef", 100),
            new Restoration("Fried Eggs", 100),
            new Restoration("Peas", 100),
            new Restoration("Tiger Meat", 100),
            new Restoration("Tiny Fish", 100),
            new Restoration("Malodorous Fish", 80),
            new Restoration("Repugnant Fish", 80),
            new Restoration("Ginseng Piece", 60),
            new Restoration("Yellow Potion", 50),
            new Restoration("Bear Fur", 48),
            new Restoration("Rabbit Hide", 48),
            new Restoration("Rabbit Meat", 48),
            new Restoration("Wolf Meat", 48),
            new Restoration("Chicken Meat", 40),
            new Restoration("Rare Pork", 31),
            new Restoration("Cooked Fish", 20),
            new Restoration("Rose Petals", 20)
        };

        public static readonly string[] Rings =
        {
            "Love",
            "Blood Stone"
        };

        public const string YellowScroll = "Yellow Scroll";
    }
}
