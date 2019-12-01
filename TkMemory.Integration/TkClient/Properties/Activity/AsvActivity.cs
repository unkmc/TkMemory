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

using System.Collections.Generic;
using TkMemory.Domain.Spells;
using TkMemory.Domain.Spells.KeySpells.Priorities;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Activity
{
    /// <summary>
    /// A collection of properties that describes the current status of a player
    /// in regard to the Harden Armor, Sanctuary, and Valor buffs.
    /// </summary>
    public class AsvActivity
    {
        #region Constructors

        /// <summary>
        /// Initializes tracking of Harden Armor, Sanctuary, and Valor buffs.
        /// </summary>
        /// <param name="activity">The player's activity data.</param>
        public AsvActivity(TkActivity activity)
        {
            var valorBuffs = new List<BuffKeySpell>();
            valorBuffs.AddRange(Caster.Valor);
            valorBuffs.AddRange(Rogue.Might);

            HardenArmor = new BuffStatus(activity, Caster.HardenArmor);
            Sanctuary = new BuffStatus(activity, Caster.Sanctuary);
            Valor = new BuffStatus(activity, valorBuffs);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The current status of the Harden Armor buff.
        /// </summary>
        public BuffStatus HardenArmor { get; }

        /// <summary>
        /// The current status of the Sanctuary buff.
        /// </summary>
        public BuffStatus Sanctuary { get; }

        /// <summary>
        /// The current status of the Valor/Might buff.
        /// </summary>
        public BuffStatus Valor { get; }

        #endregion Properties
    }
}
