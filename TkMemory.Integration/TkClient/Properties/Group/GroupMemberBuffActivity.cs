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

using System;
using System.Collections.Generic;
using System.Linq;
using TkMemory.Domain.Spells;

namespace TkMemory.Integration.TkClient.Properties.Group
{
    /// <summary>
    /// Provides information about the current effect of a beneficial status effect upon a group member.
    /// This is only required for external group members as the status of multibox group members can be read
    /// directly instead of being tracked with timers.
    /// </summary>
    public class GroupMemberBuffActivity
    {
        #region Fields

        private readonly int _duration;
        private DateTime _timeLastCast;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a timer to track the status effect. For those few buffs that could have various
        /// durations based on the spell that was cast, the longest duration is used. This is imperfect
        /// because it creates the potential for a window of time in between when the buff expires and
        /// when the spell is recast. This will happen whenever the buff is applied using a spell with
        /// a shorter duration, but there is no way to eliminate that completely. This approach was
        /// deemed to have the most limited "downtime" in general, and it is also geared more toward
        /// end-game players that are expected to comprise most of the users of feature.
        /// </summary>
        /// <param name="buffKeySpells">A list of one or more spells that cause the status effect.</param>
        public GroupMemberBuffActivity(IEnumerable<BuffKeySpell> buffKeySpells)
        {
            _duration = GetMaxDuration(buffKeySpells) + 1;
            _timeLastCast = DateTime.Now.AddSeconds(-_duration);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets whether or not the status effect is currently affecting the player.
        /// </summary>
        public bool IsActive => (DateTime.Now - _timeLastCast).TotalSeconds < _duration;

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Resets the timer used track when the buff was most recently cast on the group member.
        /// </summary>
        public void ResetTimer()
        {
            _timeLastCast = DateTime.Now;
        }

        #endregion Public Methods

        #region Private Methods

        private static int GetMaxDuration(IEnumerable<BuffKeySpell> buffKeySpells)
        {
            return buffKeySpells.OrderByDescending(spell => spell.Duration).First().Duration;
        }

        #endregion Private Methods
    }
}
