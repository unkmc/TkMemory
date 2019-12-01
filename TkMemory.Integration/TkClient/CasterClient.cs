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

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Mage or Poet by reading the memory of the application.
    /// </summary>
    public class CasterClient : TkClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Mage or Poet.
        /// </summary>
        /// <param name="classMemory">The application memory for the Mage's or Poet's game client.</param>
        public CasterClient(ClassMemory classMemory) : base(classMemory) { }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Sets conditions such that the Mage or Poet will cast every known debuff cure on each external
        /// group member. This is a brute force method, but it is not really very inefficient. The debuff
        /// cures are still only cast according to the priority set in the bot's logic, so this does not
        /// spam the bot with extra commands unless the bot has capacity for them. (This is not required
        /// for multibox group members as their debuffs can be read directly and cured automatically.)
        /// </summary>
        public void MarkExternalGroupMembersForEsuna()
        {
            foreach (var member in Group.ExternalMembers)
            {
                member.Activity.Blindness.IsActive = true;
                member.Activity.Paralysis.IsActive = true;
                member.Activity.Scourge.IsActive = true;
                member.Activity.Venom.IsActive = true;
                member.Activity.Vex.IsActive = true;
            }
        }

        #endregion Public Methods
    }
}
