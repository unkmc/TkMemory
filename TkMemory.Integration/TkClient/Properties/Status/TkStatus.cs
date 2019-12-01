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
using TkMemory.Integration.TkClient.Properties.Activity;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the player
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Fury, Rage, Cunning, Invoke, etc.).
    /// </summary>
    public abstract class TkStatus
    {
        #region Fields

        protected readonly TkActivity Activity;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's status data.
        /// </summary>
        /// <param name="activity">The activity data of the player.</param>
        protected TkStatus(TkActivity activity)
        {
            Activity = activity;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets a list of status effects currently affecting the player.
        /// </summary>
        public string ActiveEffects => Activity.ActiveStatusEffects;

        /// <summary>
        /// Gets the name of the status effect that was most recently activated or deactivated. For example, if Sanctuary is cast
        /// on you, this will return "Sanctuary" until another status effect is activated or deactivated. And when the Sanctuary
        /// effect wears off, this will again return "Sanctuary" until another status effect is activated or deactivated. There is
        /// no known difference that indicates activation vs. deactivation. Some other types of data can appear here as well. The
        /// only known example is that it always gets information about the player's profile picture when the game first loads. Due
        /// to the data inconsistency and inability to distinguish between a status effect being toggled on or off, this property
        /// is quite unreliable and is not used in any significant way.
        /// </summary>
        [Obsolete]
        public string LatestEffectChanged => Activity.LatestStatusEffectChanged;

        /// <summary>
        /// The current status of a player in regard to the Harden Armor, Sanctuary,
        /// and Valor buffs.
        /// </summary>
        public AsvActivity Asv => Activity.Asv;

        /// <summary>
        /// The current status of a player in regard to various debuffs.
        /// </summary>
        public DebuffActivity Debuffs => Activity.Debuffs;

        #endregion Properties
    }
}
