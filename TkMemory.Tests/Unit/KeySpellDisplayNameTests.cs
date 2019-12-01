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

using System;
using NUnit.Framework;
using TkMemory.Domain.Spells;

// ReSharper disable StringLiteralTypo

namespace TkMemory.Tests.Unit
{
    [TestFixture]
    internal class KeySpellDisplayNameTests
    {
        [TestCase("Abritrary Unaligned Spell", "Abritrary unaligned spell", "Abritrary Unaligned Spell")]
        [TestCase("Call of the Wild", "Summon Legend", "Call of the Wild (Summon Legend)")]
        [TestCase("Call of the Wild", "Call of the Wild (Okapi)", "Call of the Wild (Okapi)")]
        [TestCase("Baekho's Cunning 1", "Baekho's Cunning", "Baekho's Cunning 1")]
        [TestCase("Dispel", "Dispell", "Dispel")]
        [TestCase("Chung Ryong's Rage 1", "Chung Ryong's Rage", "Chung Ryong's Rage 1")]
        public void TestDisplayName(string unalignedName, string alignedName, string expectedDisplayName)
        {
            var actualDisplayName = new KeySpell(unalignedName, alignedName, 0).DisplayName;

            Console.WriteLine($"Actual: {actualDisplayName}");
            Console.WriteLine($"Expect: {expectedDisplayName}");

            var result = actualDisplayName == expectedDisplayName;
            Console.WriteLine($"Result: {result}");

            Assert.IsTrue(result);
        }
    }
}
