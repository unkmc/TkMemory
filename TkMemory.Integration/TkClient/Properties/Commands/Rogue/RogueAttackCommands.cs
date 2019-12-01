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
using TkMemory.Integration.TkClient.Infrastructure;
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Rogue
{
    /// <summary>
    /// Commands for physical attacks and casting attack spells specific to Rogues.
    /// </summary>
    public class RogueAttackCommands : PeasantAttackCommands
    {
        #region Fields

        private readonly KeySpell _ambushSpell;
        private readonly KeySpell _desperateAttackSpell;
        private readonly BuffStatus _desperateAttackStatus;
        private readonly KeySpell _lethalStrikeSpell;
        private readonly BuffStatus _lethalStrikeStatus;
        private readonly RogueClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns attack spells from the Rogue's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Rogue.</param>
        public RogueAttackCommands(RogueClient self) : base(self)
        {
            _self = self;

            _ambushSpell = self.Spells.KeySpells.Ambush;
            _desperateAttackSpell = self.Spells.KeySpells.DesperateAttack;
            _desperateAttackStatus = self.Status.DesperateAttack;
            _lethalStrikeSpell = self.Spells.KeySpells.LethalStrike;
            _lethalStrikeStatus = self.Status.LethalStrike;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Teleports to the opposite side of the target in front of the caster
        /// and performs a physical attack on that target.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Ambush()
        {
            return await SpellCommands.CastSpell(Self, _ambushSpell, true);
        }

        /// <summary>
        /// Casts the Desperate Attack attack spell on the target in front of the caster.
        /// </summary>
        /// <param name="minimumVitaPercent">Vita percent threshold below which the spell
        /// will not be cast.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> DesperateAttack(double minimumVitaPercent = 80)
        {
            if (Self.Self.Vita.Percent < minimumVitaPercent.EvaluateAsPercentage())
            {
                return false;
            }

            return await SpellCommands.CastAetheredSpell(Self, _desperateAttackSpell, _desperateAttackStatus);
        }

        /// <summary>
        /// Casts the Lethal Strike attack spell on the target in front of the caster.
        /// </summary>
        /// <param name="minimumVitaPercent">Vita percent threshold below which the spell
        /// will not be cast.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> LethalStrike(double minimumVitaPercent = 80)
        {
            if (Self.Self.Vita.Percent < minimumVitaPercent.EvaluateAsPercentage())
            {
                return false;
            }

            return await SpellCommands.CastAetheredSpell(Self, _lethalStrikeSpell, _lethalStrikeStatus);
        }

        /// <summary>
        /// Casts Invisible and then attacks with either Ambush or a normal physical attack. This will perform
        /// three actions each time it is called. Generally, that will be casting Invisible and attacking twice.
        /// If you do not have Invisible, it will attack three times. Many of these commands will be missed by
        /// the server. Automatic Rogue attacking requires a great deal of spamming commands, missed and accepted,
        /// to function without significant delays in between commands.
        /// </summary>
        /// <param name="shouldAmbush">Toggle for ambushing versus using a normal physical attack.</param>
        public async Task Melee(bool shouldAmbush)
        {
            var attackDelegate = shouldAmbush && _ambushSpell != null
                ? Ambush()
                : Task.Run(Melee);

            await Self.Activity.WaitForMeleeCooldown();

            if (!await _self.Commands.Buffs.Invisible())
            {
                await attackDelegate;
            }

            Self.Activity.ResetCommandCooldown();
            await Self.Activity.WaitForMeleeCooldown();
            await attackDelegate;

            Self.Activity.ResetCommandCooldown();
            await Self.Activity.WaitForMeleeCooldown();
            await attackDelegate;

            Self.Activity.ResetCommandCooldown();
        }

        #endregion Public Methods

        #region Private Methods

        private new void Melee()
        {
            Self.Send($"{Keys.Esc}{Keys.Space}");
        }

        #endregion Private Methods
    }
}
