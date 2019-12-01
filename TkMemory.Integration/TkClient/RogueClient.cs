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

using AutoHotkey.Interop.ClassMemory;
using TkMemory.Integration.TkClient.Properties.Commands.Rogue;
using TkMemory.Integration.TkClient.Properties.Spells;
using TkMemory.Integration.TkClient.Properties.Status;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Rogue by reading the memory of the application.
    /// </summary>
    public class RogueClient : FighterClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Rogue.
        /// </summary>
        /// <param name="classMemory">The application memory for the Rogue's game client.</param>
        public RogueClient(ClassMemory classMemory) : base(classMemory)
        {
            Self.BasePath = BasePath.Rogue;
            Spells = new RogueSpells(classMemory);
            Status = new RogueStatus(this);
            Commands = new RogueCommands(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets commands that can be performed by the Rogue.
        /// </summary>
        public RogueCommands Commands { get; }

        /// <summary>
        /// Gets spells known to the Rogue.
        /// </summary>
        public RogueSpells Spells { get; }

        /// <summary>
        /// Gets the current status of the Rogue.
        /// </summary>
        public RogueStatus Status { get; }

        #endregion Properties
    }
}
