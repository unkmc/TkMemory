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
using System.Configuration;
using NUnit.Framework;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class ReadGroupTests
    {
        [Explicit]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void ReadGroup(int groupPosition)
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetRogue();

            Console.WriteLine($"---Group Member {groupPosition}---");
            Console.WriteLine($"Name = {tkMemory.Group.GetName(groupPosition)}");
            Console.WriteLine($"UID = {tkMemory.Group.GetUid(groupPosition)}");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Mana Current = {tkMemory.Group.Mana.GetCurrent(groupPosition):N0}");
            Console.WriteLine($"Mana Deficit = {tkMemory.Group.Mana.GetDeficit(groupPosition):N0}");
            Console.WriteLine($"Mana Max = {tkMemory.Group.Mana.GetMax(groupPosition):N0}");
            Console.WriteLine($"Mana Percent = {tkMemory.Group.Mana.GetPercent(groupPosition):P}");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Vita Current = {tkMemory.Group.Vita.GetCurrent(groupPosition):N0}");
            Console.WriteLine($"Vita Deficit = {tkMemory.Group.Vita.GetDeficit(groupPosition):N0}");
            Console.WriteLine($"Vita Max = {tkMemory.Group.Vita.GetMax(groupPosition):N0}");
            Console.WriteLine($"Vita Percent = {tkMemory.Group.Vita.GetPercent(groupPosition):P}");
        }
    }
}
