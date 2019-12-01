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

using TkMemory.Integration.TkClient.Properties.Commands.Caster;
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;

namespace TkMemory.Integration.TkClient.Properties.Commands.Mage
{
    /// <summary>
    /// Commands specific to Mages.
    /// </summary>
    public class MageCommands : CasterCommands
    {
        #region Constructors

        /// <summary>
        /// Assigns spells from the Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        public MageCommands(MageClient self) : base(self)
        {
            Attacks = new MageAttackCommands(self);
            Debuffs = new MageDebuffCommands(self);
            Heal = new PeasantHealCommands(self);
            Mana = new MageManaCommands(self);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Commands for physical attacks and casting attack spells.
        /// </summary>
        public MageAttackCommands Attacks { get; }

        /// <summary>
        /// Commands for casting debuffs and debuff cures.
        /// </summary>
        public MageDebuffCommands Debuffs { get; }

        /// <summary>
        /// Commands for casting vita restoration spells.
        /// </summary>
        public PeasantHealCommands Heal { get; }

        /// <summary>
        /// Commands for casting mana restoration spells.
        /// </summary>
        public MageManaCommands Mana { get; }

        #endregion Properties
    }
}
