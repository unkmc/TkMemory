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
    internal class ReadActivityTests
    {
        [Test, Explicit]
        public void ReadActivity()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetRogue();

            Console.WriteLine("----------Activity----------");
#pragma warning disable 612
            Console.WriteLine($"LatestActivity = {tkMemory.Activity.LatestActivity}");
            Console.WriteLine($"StatusLatestChange = {tkMemory.Activity.LatestStatusEffectChanged}");
#pragma warning restore 612
            Console.WriteLine($"StatusActiveEffects =\n{tkMemory.Activity.ActiveStatusEffects}");
        }
    }
}
