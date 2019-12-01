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

namespace TkMemory.Integration.TkClient.Properties.Group
{
    /// <summary>
    /// Provides basic information about a group member, his/her position within the group,
    /// and his/her current buff/debuff activity.
    /// </summary>
    public class GroupMember
    {
        #region Constructors

        /// <summary>
        /// Initializes data about a group member.
        /// </summary>
        /// <param name="position">The group member's zero-indexed position within the group.</param>
        /// <param name="name">The name of the group member.</param>
        /// <param name="uid">The UID of the group member.</param>
        public GroupMember(int position, string name, uint uid)
        {
            Activity = new GroupMemberActivity();
            Position = position;
            Name = name;
            Uid = uid;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Describes the current state of buffs/debuffs affecting the group member.
        /// </summary>
        public GroupMemberActivity Activity { get; }

        /// <summary>
        /// The name of the group member.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The zero-indexed position of the group member within the group.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// The UID of the group member.
        /// </summary>
        public uint Uid { get; }

        #endregion Properties
    }
}
