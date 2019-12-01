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
using Serilog;
using TkMemory.Domain.Items;
using TkMemory.Domain.Spells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands
{
    internal static class ItemCommands
    {
        #region Public Methods

        public static async Task RestoreMajorManaForSpell(TkClient itemUser, KeySpell spell)
        {
            await RestoreManaForSpell(itemUser, spell, itemUser.Inventory.KeyItems.MajorManaRestoration);
        }

        public static async Task RestoreMinorManaForSpell(TkClient itemUser, KeySpell spell)
        {
            await RestoreManaForSpell(itemUser, spell, itemUser.Inventory.KeyItems.MinorManaRestoration);
        }

        public static async Task UseMajorManaRestorationItem(TkClient itemUser, int minimumRestoration = 1)
        {
            var majorManaRestorationItem = itemUser.Inventory.KeyItems.MajorManaRestoration;
            await UseManaRestorationItem(itemUser, majorManaRestorationItem, minimumRestoration);
        }

        public static async Task UseMinorManaRestorationItem(TkClient itemUser, int minimumRestoration = 1)
        {
            var minorManaRestorationItem = itemUser.Inventory.KeyItems.MinorManaRestoration;
            await UseManaRestorationItem(itemUser, minorManaRestorationItem, minimumRestoration);
        }

        #endregion Public Methods

        #region Private Methods

        private static async Task RestoreManaForSpell(TkClient itemUser, KeySpell spell, Restoration manaRestorationItem)
        {
            await itemUser.Activity.WaitForCommandCooldown();
            var currentMana = (int)itemUser.Self.Mana.Current;

            if (currentMana < spell.Cost)
            {
                await UseManaRestorationItem(itemUser, manaRestorationItem, spell.Cost - currentMana);
            }
        }

        // ReSharper disable once UnusedMember.Local
        private static async Task RestoreManaIfBelowPercent(TkClient itemUser, double minimumManaPercent, Restoration manaRestorationItem)
        {
            await itemUser.Activity.WaitForCommandCooldown();
            var currentManaPercent = itemUser.Self.Mana.Percent;

            if (currentManaPercent < minimumManaPercent)
            {
                await UseManaRestorationItem(itemUser, manaRestorationItem);
            }
        }

        // ReSharper disable once UnusedMember.Local
        private static async Task RestoreManaIfEligible(TkClient itemUser, Restoration manaRestorationItem)
        {
            await itemUser.Activity.WaitForCommandCooldown();
            var currentManaDeficit = itemUser.Self.Mana.Deficit;

            if (currentManaDeficit > manaRestorationItem.RestoreAmount)
            {
                var usages = (int)(currentManaDeficit / manaRestorationItem.RestoreAmount);
                await UseManaRestorationItem(itemUser, manaRestorationItem, usages);
            }
        }

        public static async Task<bool> UseItem(TkClient itemUser, Item item, int usages = 1)
        {
            if (item == null)
            {
                return false;
            }

            itemUser.Inventory.Update();
            await itemUser.Activity.WaitForCommandCooldown();

            if (usages > item.Quantity)
            {
                usages = item.Quantity;
            }

            for (var i = 0; i < usages; i++)
            {
                itemUser.Send($"{Keys.Esc}u{item.Letter}");
                await Task.Delay(20);

                Log.Information($"{itemUser.Self.Name} used {item.Name}.");
            }
            
            // ReSharper disable once InvertIf
            if (usages == item.Quantity)
            {
                // Updates the item inventory again if the current item was completely used up.
                // This creates an extra delay of one command cycle, but it usually (barring
                // significant lag) prevents an attempt to use the item once after it is gone.
                itemUser.Activity.ResetCommandCooldown();
                await itemUser.Activity.WaitForCommandCooldown();
                itemUser.Inventory.Update();
            }

            return true;
        }

        private static async Task UseManaRestorationItem(TkClient itemUser, Restoration manaRestorationItem, int minimumRestoration = 1)
        {
            var requiredUsages = (int)Math.Ceiling((float)minimumRestoration / manaRestorationItem.RestoreAmount);
            itemUser.IncrementManaRestorationItemUsageCount(requiredUsages);

            if (!await UseItem(itemUser, manaRestorationItem, requiredUsages))
            {
                Log.Error($"{itemUser.Self.Name} does not have any mana restoration items.");
            }
        }

        #endregion Private Methods
    }
}
