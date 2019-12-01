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

using TkMemory.Domain.Spells.KeySpells.Priorities;

namespace TkMemory.Integration.TkClient.Properties.Group
{
    /// <summary>
    /// Contains information about activity performed upon a group member (e.g. casting a status effect like Sanctuary).
    /// </summary>
    public class GroupMemberActivity
    {
        #region Constructors

        /// <summary>
        /// Initializes a group member's buff/debuff activity data.
        /// </summary>
        public GroupMemberActivity()
        {
            HardenArmor = new GroupMemberBuffActivity(Caster.HardenArmor);
            Sanctuary = new GroupMemberBuffActivity(Caster.Sanctuary);
            Valor = new GroupMemberBuffActivity(Caster.Valor);

            Blindness = new GroupMemberDebuffActivity();
            Paralysis = new GroupMemberDebuffActivity();
            Scourge = new GroupMemberDebuffActivity();
            Venom = new GroupMemberDebuffActivity();
            Vex = new GroupMemberDebuffActivity();
        }

        #endregion Constructors

        #region Properties

        #region Buffs

        /// <summary>
        /// Gets information about a group member's current status in regard to the Harden Armor buff.
        /// </summary>
        public GroupMemberBuffActivity HardenArmor { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Sanctuary buff.
        /// </summary>
        public GroupMemberBuffActivity Sanctuary { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Valor/Might buff.
        /// </summary>
        public GroupMemberBuffActivity Valor { get; }

        #endregion

        #region Debuffs

        /// <summary>
        /// Gets information about a group member's current status in regard to the Blindness debuff.
        /// </summary>
        public GroupMemberDebuffActivity Blindness { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Paralysis debuff.
        /// </summary>
        public GroupMemberDebuffActivity Paralysis { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Scourge debuff.
        /// </summary>
        public GroupMemberDebuffActivity Scourge { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Venom debuff.
        /// </summary>
        public GroupMemberDebuffActivity Venom { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Vex debuff.
        /// </summary>
        public GroupMemberDebuffActivity Vex { get; }

        #endregion

        #endregion Properties
    }
}
