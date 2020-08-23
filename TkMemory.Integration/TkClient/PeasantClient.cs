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
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;
using TkMemory.Integration.TkClient.Properties.Spells;
using TkMemory.Integration.TkClient.Properties.Status;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Peasant by reading the memory of the application.
    /// </summary>
    public class PeasantClient : FighterClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Peasant.
        /// </summary>
        /// <param name="classMemory">The application memory for the Peasant's game client.</param>
        public PeasantClient(ClassMemory classMemory) : base(classMemory)
        {
            Self.BasePath = BasePath.Peasant;
            Spells = new PeasantSpells(classMemory);
            Status = new TkStatus(this.Activity);
            Commands = new PeasantCommands(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets commands that can be performed by the Peasant.
        /// </summary>
        public PeasantCommands Commands { get; }

        /// <summary>
        /// Gets spells known to the Peasant.
        /// </summary>
        public PeasantSpells Spells { get; }

        /// <summary>
        /// Gets the current status of the Peasant.
        /// </summary>
        public TkStatus Status { get; }

        #endregion Properties
    }
}
