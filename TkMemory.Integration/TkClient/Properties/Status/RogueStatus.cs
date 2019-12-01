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

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the Rogue
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Fury, Cunning, etc.).
    /// </summary>
    public class RogueStatus : FighterStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes a Rogue's status data.
        /// </summary>
        /// <param name="self">All game client data for the Rogue.</param>
        public RogueStatus(TkClient self) : base(self.Activity)
        {
            var mightBuffs = new List<BuffKeySpell>();
            mightBuffs.AddRange(Caster.Valor);
            mightBuffs.AddRange(Rogue.Might);

            DesperateAttack = new BuffStatus(Activity, Rogue.DesperateAttack);
            Invisible = new InvisibleStatus(Activity, Rogue.Invisible);
            LethalStrike = new BuffStatus(Activity, Rogue.LethalStrike);
            Fury = new BuffStatus(Activity, Rogue.Fury);
            Might = new BuffStatus(Activity, mightBuffs);
            Rage = new RageStatus(self, Rogue.Cunning);
            ShadowFigure = new BuffStatus(Activity, Rogue.ShadowFigure);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the status of the Desperate Attack key spell.
        /// </summary>
        public BuffStatus DesperateAttack { get; }

        /// <summary>
        /// Gets the status of the Invisible buff.
        /// </summary>
        public InvisibleStatus Invisible { get; }

        /// <summary>
        /// Gets the status of the Lethal Strike key spell.
        /// </summary>
        public BuffStatus LethalStrike { get; }

        /// <summary>
        /// Gets the status of the Might/Valor buff.
        /// </summary>
        public BuffStatus Might { get; }

        /// <summary>
        /// Gets the status of the Shadow Figure buff.
        /// </summary>
        public BuffStatus ShadowFigure { get; }

        #endregion Properties
    }
}
