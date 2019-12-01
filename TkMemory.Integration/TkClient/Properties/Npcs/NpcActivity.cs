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
    /// Contains information about activity performed upon an NPC (e.g. casting a status effect like Scourge).
    /// </summary>
    public class NpcActivity
    {
        #region Properties

        /// <summary>
        /// Gets the activity data for the Blindness debuff.
        /// </summary>
        public NpcDebuffActivity Blind { get; internal set; }

        /// <summary>
        /// Gets the activity data for a Curse debuff (i.e. Vex or Scourge).
        /// </summary>
        public NpcDebuffActivity Curse { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Doze debuff.
        /// </summary>
        public NpcDebuffActivity Doze { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Paralyze debuff.
        /// </summary>
        public NpcDebuffActivity Paralyze { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Sleep debuff.
        /// </summary>
        public NpcDebuffActivity Sleep { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Venom debuff.
        /// </summary>
        public NpcDebuffActivity Venom { get; internal set; }

        #endregion Properties
    }
}
