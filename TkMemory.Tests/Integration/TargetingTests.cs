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
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    internal class TargetingTests
    {
        [Explicit]
        [TestCase((uint)1561)]
        public async Task IsTargetOffScreen(uint uid)
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();

            var result = await tkMemory.IsTargetOffScreen(uid, tkMemory.Spells.KeySpells.Zap)
                ? "Target is off screen."
                : "Target is on screen.";

            Console.WriteLine(result);
        }

        [Test, Explicit]
        public async Task ReadNpcs()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();
            await tkMemory.UpdateNpcs(tkMemory.Spells.KeySpells.Zap);

            var sb = new StringBuilder();
            sb.AppendLine("NPC UIDs:");
            foreach (var npc in tkMemory.Npcs)
            {
                sb.AppendLine(npc.Uid.ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
