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

using System.Threading.Tasks;
using AutoHotkey.Interop.ClassMemory;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Mage;
using TkMemory.Integration.TkClient.Properties.Npcs;
using TkMemory.Integration.TkClient.Properties.Spells;
using TkMemory.Integration.TkClient.Properties.Status;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Mage by reading the memory of the application.
    /// </summary>
    public class MageClient : CasterClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Mage.
        /// </summary>
        /// <param name="classMemory">The application memory for the Mage's game client.</param>
        public MageClient(ClassMemory classMemory) : base(classMemory)
        {
            Self.BasePath = BasePath.Mage;
            Spells = new MageSpells(classMemory);
            Status = new MageStatus(Activity);
            Commands = new MageCommands(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets commands that can be performed by the Mage.
        /// </summary>
        public MageCommands Commands { get; }

        /// <summary>
        /// Gets spells known to the Mage.
        /// </summary>
        public MageSpells Spells { get; }

        /// <summary>
        /// Gets the current status of the Mage.
        /// </summary>
        public MageStatus Status { get; }

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

            foreach (var npc in Npcs)
            {
                if (npc.Activity.Blind == null)
                {
                    npc.Activity.Blind = new NpcDebuffActivity(Spells.KeySpells.Blind);
                }

                if (npc.Activity.Curse == null)
                {
                    npc.Activity.Curse = new NpcDebuffActivity(Spells.KeySpells.Curse);
                }

                if (npc.Activity.Doze == null)
                {
                    npc.Activity.Doze = new NpcDebuffActivity(Spells.KeySpells.Doze);
                }

                if (npc.Activity.Paralyze == null)
                {
                    npc.Activity.Paralyze = new NpcDebuffActivity(Spells.KeySpells.Paralyze);
                }

                if (npc.Activity.Sleep == null)
                {
                    npc.Activity.Sleep = new NpcDebuffActivity(Spells.KeySpells.Sleep);
                }

                if (npc.Activity.Venom == null)
                {
                    npc.Activity.Venom = new NpcDebuffActivity(Spells.KeySpells.Venom);
                }
            }

            return true;
        }

        #endregion Public Methods
    }
}
