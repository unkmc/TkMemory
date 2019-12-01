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
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Fighter;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Rogue
{
    /// <summary>
    /// Commands specific to Rogues that are used to cast buffs.
    /// </summary>
    public class RogueBuffCommands : FighterBuffCommands
    {
        #region Fields

        private readonly KeySpell _invisibleSpell;
        private readonly InvisibleStatus _invisibleStatus;
        private readonly KeySpell _mightSpell;
        private readonly BuffStatus _mightStatus;
        private readonly KeySpell _shadowFigureSpell;
        private readonly BuffStatus _shadowFigureStatus;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns buff spells from the Rogue's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Rogue.</param>
        public RogueBuffCommands(RogueClient self) : base(self)
        {
            _invisibleSpell = self.Spells.KeySpells.Invisible;
            _invisibleStatus = self.Status.Invisible;
            _mightSpell = self.Spells.KeySpells.Might;
            _mightStatus = self.Status.Might;
            _shadowFigureSpell = self.Spells.KeySpells.ShadowFigure;
            _shadowFigureStatus = self.Status.ShadowFigure;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Makes the caster invisible to multiply physical attack damage.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Invisible()
        {
            return await SpellCommands.CastInvisibleSpell(Self, _invisibleSpell, _invisibleStatus);
        }

        /// <summary>
        /// Casts the Might buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Might()
        {
            return await SpellCommands.CastAetheredSpell(Self, _mightSpell, _mightStatus);
        }

        /// <summary>
        /// Casts the Shadow Figure buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> ShadowFigure()
        {
            return await SpellCommands.CastAetheredSpell(Self, _shadowFigureSpell, _shadowFigureStatus);
        }

        #endregion Public Methods
    }
}
