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

namespace TkMemory.Integration.TkClient.Properties.Npcs
{
    /// <summary>
    /// Provides identifying information for an NPC as well as information about the activity
    /// performed upon an NPC (e.g. casting a status effect like Scourge).
    /// </summary>
    public class Npc
    {
        #region Constructors

        /// <summary>
        /// Initializes the activity data for a specified NPC.
        /// </summary>
        /// <param name="uid">The UID of the NPC.</param>
        public Npc(uint uid)
        {
            Activity = new NpcActivity();
            Uid = uid;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the activity data of the NPC.
        /// </summary>
        public NpcActivity Activity { get; }

        /// <summary>
        /// Gets the UID of the NPC.
        /// </summary>
        public uint Uid { get; }

        #endregion Properties
    }
}
