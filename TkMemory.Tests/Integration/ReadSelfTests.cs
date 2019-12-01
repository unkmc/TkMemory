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
    internal class ReadSelfTests
    {
        [Test, Explicit]
        public void ReadSelf()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetRogue();

            Console.WriteLine("----------Self----------");
            Console.WriteLine($"Name = {tkMemory.Self.Name}");
            Console.WriteLine($"Uid = {tkMemory.Self.Uid}");
            Console.WriteLine($"Path = {tkMemory.Self.Path}");
            Console.WriteLine($"Level = {tkMemory.Self.Level}");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Vita Current = {tkMemory.Self.Vita.Current:N0}");
            Console.WriteLine($"Vita Deficit = {tkMemory.Self.Vita.Deficit:N0}");
            Console.WriteLine($"Vita Max = {tkMemory.Self.Vita.Max:N0}");
            Console.WriteLine($"Vita Percent = {tkMemory.Self.Vita.Percent:P}");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Mana Current = {tkMemory.Self.Mana.Current:N0}");
            Console.WriteLine($"Mana Deficit = {tkMemory.Self.Mana.Deficit:N0}");
            Console.WriteLine($"Mana Max = {tkMemory.Self.Mana.Max:N0}");
            Console.WriteLine($"Mana Percent = {tkMemory.Self.Mana.Percent:P}");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Gold = {tkMemory.Self.Gold:N0}");
            Console.WriteLine($"Exp = {tkMemory.Self.Exp:N0}");
        }
    }
}
