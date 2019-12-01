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

using System.Threading.Tasks;
using TkMemory.Domain.Items;

namespace TkMemory.Integration.TkClient.Properties.Commands.Peasant
{
    /// <summary>
    /// Commands common to all paths for using items.
    /// </summary>
    public class PeasantItemCommands
    {
        #region Fields

        private readonly Item _ring;
        private readonly TkClient _self;
        private readonly Item _yellowScroll;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns key items from the item user's inventory.
        /// </summary>
        /// <param name="self">The game client data for the item user.</param>
        public PeasantItemCommands(TkClient self)
        {
            _self = self;

            _ring = _self.Inventory.KeyItems.Ring;
            _yellowScroll = _self.Inventory.KeyItems.YellowScroll;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Uses a Love or Blood stone to teleport the item user to his/her spouse or
        /// blood sibling, respectively.
        /// </summary>
        /// <returns>True if an item was used; false otherwise.</returns>
        public virtual async Task<bool> UseRing()
        {
            return await ItemCommands.UseItem(_self, _ring);
        }

        /// <summary>
        /// Consumes one Yellow scroll to teleport the item user to his/her home.
        /// </summary>
        /// <returns>True if an item was used; false otherwise.</returns>
        public virtual async Task<bool> UseYellowScroll()
        {
            return await ItemCommands.UseItem(_self, _yellowScroll);
        }

        #endregion Public Methods
    }
}
