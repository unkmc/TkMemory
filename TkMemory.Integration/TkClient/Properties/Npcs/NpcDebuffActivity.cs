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
using TkMemory.Domain.Spells;

namespace TkMemory.Integration.TkClient.Properties.Npcs
{
    /// <summary>
    /// Provides information about the current effect of a detrimental status effect upon an NPC.
    /// </summary>
    public class NpcDebuffActivity
    {
        #region Fields

        private readonly int _duration;
        private DateTime _timeLastCast;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a timer to track the status effect.
        /// </summary>
        /// <param name="buffKeySpell">The spell that causes the status effect.</param>
        public NpcDebuffActivity(BuffKeySpell buffKeySpell)
        {
            if (buffKeySpell == null)
            {
                _duration = int.MaxValue;
                _timeLastCast = DateTime.MaxValue;
                return;
            }

            _duration = buffKeySpell.Duration + 1;
            _timeLastCast = DateTime.Now.AddSeconds(-_duration);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets whether or not the status effect is currently affecting the NPC.
        /// </summary>
        public bool IsActive => (DateTime.Now - _timeLastCast).TotalSeconds < _duration;

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Resets the timer used track when the debuff was most recently cast on the NPC.
        /// </summary>
        public void ResetTimer()
        {
            _timeLastCast = DateTime.Now;
        }

        #endregion Public Methods
    }
}
