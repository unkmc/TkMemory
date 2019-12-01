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

using TkMemory.Integration.TkClient.Properties.Commands.Peasant;

namespace TkMemory.Integration.TkClient.Properties.Commands.Poet
{
    /// <summary>
    /// Commands for physical attacks and casting attack spells specific to Poets.
    /// </summary>
    public class PoetAttackCommands : PeasantAttackCommands
    {
        #region Constructors

        /// <summary>
        /// Assigns attack spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public PoetAttackCommands(PoetClient self) : base(self) { }

        #endregion Constructors
    }
}
