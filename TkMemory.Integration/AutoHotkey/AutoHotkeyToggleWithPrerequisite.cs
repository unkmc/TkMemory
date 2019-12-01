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

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.AutoHotkey
{
    /// <summary>
    /// An AutoHotkeyToggle object whose value is dependent on the value of a separate AutoHotkeyBool.
    /// Any time the value of the AutoHotkeyToggle is changed, the value of the AutoHotkeyBool is also
    /// changed to the same value. This is used to toggle actions that require two Booleans to coordinate
    /// all of the actions that should be taken when toggled.
    /// </summary>
    public class AutoHotkeyToggleWithPrerequisite : AutoHotkeyToggle
    {
        #region Fields

        private readonly AutoHotkeyBool _prerequisite;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Declare and initialize a Boolean variable in AutoHotkey whose value can be toggled with a hotkey.
        /// </summary>
        /// <param name="hotkey">The hotkey that will be used to toggle the value of the Boolean.</param>
        /// <param name="name">The name of the Boolean variable in AutoHotkey.</param>
        /// <param name="value">The initial value of the Boolean variable.</param>
        /// <param name="prerequisite">An AutoHotkeyBool whose value should be set to the same value whenever setting the value of this AutoHotkeyToggle.
        /// The value of the AutoHotkeyBool should never be toggled directly using a hotkey, so do not use an AutoHotkeyToggle instead.</param>
        public AutoHotkeyToggleWithPrerequisite(string hotkey, string name, bool value, AutoHotkeyBool prerequisite)
            : base(hotkey, name, value)
        {
            _prerequisite = prerequisite;
            _prerequisite.Value = value;
        }

        #endregion Constructors

        #region Protected Methods

        protected override bool GetValue()
        {
            var value = base.GetValue();

            if (CurrentValue != PreviousValue)
            {
                _prerequisite.Value = value;
            }

            return value;
        }

        protected override void SetValue(bool value)
        {
            base.SetValue(value);
            _prerequisite.Value = value;
        }

        #endregion Protected Methods
    }
}
