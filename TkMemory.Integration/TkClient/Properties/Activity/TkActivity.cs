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
using System.Threading.Tasks;
using AutoHotkey.Interop.ClassMemory;
using Serilog;
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties.Activity
{
    /// <summary>
    /// Contains information about activity (actions, status effects, commands, etc.) that are at least potentially
    /// beyond the full control of the player (e.g. status effects like Sanctuary that can be cast on the player
    /// without the player's consent). Status-related properties are cross-listed with TkStatus properties, but this
    /// class cannot access fully player-controlled status effects (e.g. fury, rage, cunning, invoke, etc.). Command-
    /// related properties and methods are cross-listed in PeasantCommands for convenience since that is an intuitive
    /// place to find them, but they really belong here as they are all related to the command cool down enforced by
    /// the server which is beyond the control of the player.
    /// </summary>
    public class TkActivity
    {
        #region Fields

        private const int MaximumSpellCooldownInMilliseconds = 1000;
        private const int MinimumSpellCooldownInMilliseconds = 333;
        private const int MeleeCommandCooldownInMilliseconds = 250;

        private readonly ClassMemory _classMemory;

        private int _defaultCommandCooldown;
        private DateTime _timeOfPreviousCommand;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's activity data. 
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkActivity(ClassMemory classMemory)
        {
            _classMemory = classMemory;
            _defaultCommandCooldown = MinimumSpellCooldownInMilliseconds;
            _timeOfPreviousCommand = DateTime.Now.AddMilliseconds(-MaximumSpellCooldownInMilliseconds);

            Asv = new AsvActivity(this);
            Debuffs = new DebuffActivity(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets a list of status effects currently affecting the player.
        /// </summary>
        public string ActiveStatusEffects => _classMemory.ReadString(TkAddresses.Self.Status.ActiveEffects, Constants.DefaultEncoding);

        /// <summary>
        /// Gets the latest activity documented in the box on the right side of the screen that shows things like experience gained
        /// and items picked up or dropped. However, certain types of entries in that box are not eligible to be returned by this.
        /// Items picked up or dropped is one such example. If that was your latest activity, this would return the activity before
        /// that one (assuming it is eligible). The eligibility criteria are unknown. Due to that inconsistency and the fact that
        /// many entries are identical with no good way to distinguish between no new entry and a new but identical entry, this
        /// property is quite unreliable and is not used in any significant way.
        /// </summary>
        [Obsolete]
        public string LatestActivity => _classMemory.ReadString(TkAddresses.Self.Status.LatestActivity);

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
        public string LatestStatusEffectChanged => _classMemory.ReadString(TkAddresses.Self.Status.LatestChange);

        /// <summary>
        /// The default number of milliseconds to wait in between commands.
        /// </summary>
        public int DefaultCommandCooldown
        {
            get => _defaultCommandCooldown;
            set
            {
                if (value < MinimumSpellCooldownInMilliseconds)
                {
                    value = MinimumSpellCooldownInMilliseconds;
                    Log.Warning($"Spell cool down adjusted to the minimum allowable value of {value} milliseconds.");
                }

                if (value > MaximumSpellCooldownInMilliseconds)
                {
                    value = MaximumSpellCooldownInMilliseconds;
                    Log.Warning($"Spell cool down adjusted to the maximum allowable value of {value} milliseconds.");
                }

                _defaultCommandCooldown = value;
            }
        }

        /// <summary>
        /// The current status of a player in regard to the Harden Armor, Sanctuary,
        /// and Valor buffs.
        /// </summary>
        public AsvActivity Asv { get; }

        /// <summary>
        /// The current status of a player in regard to various debuffs.
        /// </summary>
        public DebuffActivity Debuffs { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Resets that timestamp of the most recently performed command to be the current time.
        /// This method should usually be called any time a command is performed, although there
        /// are some exceptions when no cooldown is required between commands (e.g. using a mana
        /// restoration before casting a spell).
        /// </summary>
        public void ResetCommandCooldown()
        {
            _timeOfPreviousCommand = DateTime.Now;
        }

        /// <summary>
        /// Delays any further action until the number of milliseconds since the previous command
        /// is greater than the number of milliseconds currently assigned to the DefaultCommandCooldown
        /// property.
        /// </summary>
        public async Task WaitForCommandCooldown()
        {
            await WaitForCommandCooldown(DefaultCommandCooldown);
        }

        /// <summary>
        /// Delays any further melee commands until the number of milliseconds since the previous command
        /// is greater than of the number of milliseconds set for the cooldown on melee commands.
        /// </summary>
        public async Task WaitForMeleeCooldown()
        {
            await WaitForCommandCooldown(MeleeCommandCooldownInMilliseconds);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task WaitForCommandCooldown(int cooldown)
        {
            var remainingCooldown = (int)Math.Ceiling(cooldown - (DateTime.Now - _timeOfPreviousCommand).TotalMilliseconds);

            if (remainingCooldown > 0)
            {
                await Task.Delay(remainingCooldown);
            }
        }

        #endregion Private Methods
    }
}
