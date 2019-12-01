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

using System.Linq;
using System.Threading.Tasks;
using AutoHotkey.Interop.ClassMemory;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Poet;
using TkMemory.Integration.TkClient.Properties.Npcs;
using TkMemory.Integration.TkClient.Properties.Spells;
using TkMemory.Integration.TkClient.Properties.Status;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Poet by reading the memory of the application.
    /// </summary>
    public class PoetClient : CasterClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Poet.
        /// </summary>
        /// <param name="classMemory">The application memory for the Poet's game client.</param>
        public PoetClient(ClassMemory classMemory) : base(classMemory)
        {
            Self.BasePath = BasePath.Poet;
            Spells = new PoetSpells(classMemory);
            Status = new PoetStatus(Activity);
            Commands = new PoetCommands(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets commands that can be performed by the Poet.
        /// </summary>
        public PoetCommands Commands { get; }

        /// <summary>
        /// Gets spells known to the Poet.
        /// </summary>
        public PoetSpells Spells { get; }

        /// <summary>
        /// Gets the current status of the Poet.
        /// </summary>
        public PoetStatus Status { get; }

        #endregion Properties

        #region Public Methods
        
        /// <summary>
        /// Scans the current screen for NPCs and adds any that are not already in the bot's NPC
        /// list to that list. By default, this happens no more often than once every 10 seconds,
        /// but it can also be done on command by setting the overriding that cooldown feature.
        /// </summary>
        /// <param name="targetableSpell">Any targetable spell.</param>
        /// <param name="overrideCooldown">Set to true for an on-demand scan regardless of current
        /// cooldown.</param>
        /// <returns>True if a scan is performed; false if the cooldown prevented a scan.</returns>
        public override async Task<bool> UpdateNpcs(Spell targetableSpell, bool overrideCooldown = false)
        {
            if (!await base.UpdateNpcs(targetableSpell, overrideCooldown))
            {
                return false;
            }

            foreach (var npc in Npcs.Where(npc => npc.Activity.Curse == null))
            {
                npc.Activity.Curse = new NpcDebuffActivity(Spells.KeySpells.Curse);
            }

            return true;
        }

        #endregion Public Methods
    }
}
