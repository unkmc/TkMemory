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
using System.Globalization;
using System.Linq;
using System.Text;
using TkMemory.Domain.Infrastructure;

namespace TkMemory.Domain.Items
{
    /// <summary>
    /// A collection of items most likely to be of relevance to a bot.
    /// </summary>
    public class KeyItems
    {
        #region Fields

        private readonly List<Item> _inventory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Scans a player's inventory to identify key items.
        /// </summary>
        /// <param name="inventory">A list of items held by the player.</param>
        public KeyItems(List<Item> inventory)
        {
            _inventory = inventory;

            Axe = GetItemByPriority(Priorities.Axe);
            MajorManaRestoration = GetRestorationByPriorityAndQuantity(Priorities.RestoreManaMajor);
            MiningPick = GetItemByPriority(Priorities.MiningPick);
            MinorManaRestoration = GetRestorationByPriorityAndQuantity(Priorities.RestoreManaMinor);
            Mount = GetMountByPriority(Priorities.Mount);
            Ring = GetItemByPriority(Priorities.Rings);
            VitaRestoration = GetRestorationByPriorityAndQuantity(Priorities.RestoreVita);
            YellowScroll = GetItemByPriority(Priorities.YellowScroll);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// An axe that can be used for the woodcutting skill.
        /// </summary>
        public Item Axe { get; }

        /// <summary>
        /// The most potent mana restoration item available. If there are multiple matches,
        /// the one with the lowest quantity will be selected.
        /// </summary>
        public Restoration MajorManaRestoration { get; }

        /// <summary>
        /// A mining pick that can be used for the mining skill.
        /// </summary>
        public Item MiningPick { get; }

        /// <summary>
        /// The least potent mana restoration item available. If there are multiple matches,
        /// the one with the lowest quantity will be selected.
        /// </summary>
        public Restoration MinorManaRestoration { get; }

        /// <summary>
        /// A creature that can be summoned and ridden for increased movement speed.
        /// </summary>
        public Item Mount { get; }

        /// <summary>
        /// An item used to transport a player to his/her partner.
        /// </summary>
        public Item Ring { get; }

        /// <summary>
        /// An item that can be consumed to restore vitality.
        /// </summary>
        public Restoration VitaRestoration { get; }

        /// <summary>
        /// An item that can be consumed to return the player to his/her home.
        /// </summary>
        public Item YellowScroll { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Generates a string representation of a player's key item inventory.
        /// </summary>
        /// <returns>A list of key items held by the player.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var propertyInfo in GetType().GetProperties())
            {
                sb.AppendLine($"{propertyInfo.Name.CamelCaseToString()} => {propertyInfo.GetValue(this)?.ToString() ?? "Empty"}");
            }

            return sb.ToString();
        }

        #endregion Public Methods

        #region Protected Methods

        protected Restoration GetRestorationByPriorityAndQuantity(IEnumerable<Restoration> priorityList)
        {
            var itemsByPriorityThenQuantity = priorityList.Select(restoration => from i in _inventory
                where string.Equals(i.Name, restoration.Name, StringComparison.OrdinalIgnoreCase)
                orderby i.Quantity
                select new Restoration(restoration.Name, restoration.RestoreAmount, Index.Parse(i.Letter), i.Quantity));

            var firstItemInList = itemsByPriorityThenQuantity
                .Select(x => x.FirstOrDefault())
                .FirstOrDefault(y => y != null);

            return firstItemInList;
        }

        #endregion Protected Methods

        #region Private Methods

        private Item GetMountByPriority(IEnumerable<string> priorityList)
        {
            return (from mount in priorityList
                from item in _inventory
                where CultureInfo.InvariantCulture.CompareInfo.IndexOf(item.Name, mount, CompareOptions.OrdinalIgnoreCase) >= 0
                select item
            ).FirstOrDefault();
        }

        private Item GetItemByPriority(string name)
        {
            var priorityList = new[] { name };
            return GetItemByPriority(priorityList);
        }

        private Item GetItemByPriority(IEnumerable<string> priorityList)
        {
            return (from itemName in priorityList
                from item in _inventory
                where CultureInfo.InvariantCulture.CompareInfo.IndexOf(itemName, item.Name, CompareOptions.OrdinalIgnoreCase) >= 0
                select new Item(Index.Parse(item.Letter), itemName, item.Quantity)
            ).FirstOrDefault();
        }

        #endregion Private Methods
    }
}
