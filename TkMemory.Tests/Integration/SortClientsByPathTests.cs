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
    internal class SortClientsByPathTests
    {
        [Test, Explicit]
        public void SortTkInstancesByPath()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);

            foreach (var mage in clients.Mages)
            {
                Console.WriteLine($"Mage: {mage.Self.Name}");
            }

            foreach (var poet in clients.Poets)
            {
                Console.WriteLine($"Poet: {poet.Self.Name}");
            }

            foreach (var rogue in clients.Rogues)
            {
                Console.WriteLine($"Rogue: {rogue.Self.Name}");
            }

            foreach (var warrior in clients.Warriors)
            {
                Console.WriteLine($"Warrior: {warrior.Self.Name}");
            }
        }
    }
}
