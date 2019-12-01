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
using TkMemory.Integration.TkClient.Properties.Npcs;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Peasant
{
    /// <summary>
    /// Commands for physical attacks and casting attack spells common to all paths.
    /// </summary>
    public abstract class PeasantAttackCommands
    {
        #region Fields

        protected readonly TkClient Self;
        protected readonly KeySpell ZapSpell;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns attack spells from the Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        protected PeasantAttackCommands(MageClient self)
        {
            Self = self;
            ZapSpell = self.Spells.KeySpells.Zap;
        }

        /// <summary>
        /// Assigns attack spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        protected PeasantAttackCommands(PoetClient self)
        {
            Self = self;
            ZapSpell = self.Spells.KeySpells.Zap;
        }

        /// <summary>
        /// Assigns attack spells from the Rogue's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Rogue.</param>
        protected PeasantAttackCommands(RogueClient self)
        {
            Self = self;
            ZapSpell = self.Spells.KeySpells.Zap;
        }

        /// <summary>
        /// Assigns attack spells from the Warrior's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Warrior.</param>
        protected PeasantAttackCommands(WarriorClient self)
        {
            Self = self;
            ZapSpell = self.Spells.KeySpells.Zap;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Performs a physical melee attack.
        /// </summary>
        public async Task Melee()
        {
            await Self.Activity.WaitForMeleeCooldown();
            Self.Send($"{Keys.Esc}{Keys.Space}");
            Self.Activity.ResetCommandCooldown();
        }

        /// <summary>
        /// Zaps an NPC once. Taunts are designed primarily for drawing the attention of NPCs,
        /// not damaging them. Though taunts are useful for Mages for finishing off Venom targets.
        /// </summary>
        /// <param name="target">The NPC to target for the attack.</param>
        /// <param name="isLowCostSpell">If true, a minor mana restoration item will be used if the
        /// caster lacks sufficient mana to cast the spell. If false, a major mana restoration item
        /// will be used instead.</param>
        /// <returns>True if a spell is cast. False otherwise.</returns>
        public async Task<bool> Taunt(Npc target, bool isLowCostSpell = true)
        {
            return await Zap(target, true);
        }

        /// <summary>
        /// Zaps each on-screen NPC once. Taunts are designed primarily for drawing the attention of NPCs,
        /// not damaging them. Though taunts are useful for Mages for finishing off Venom targets.
        /// </summary>
        /// <param name="isLowCostSpell">If true, a minor mana restoration item will be used if the
        /// caster lacks sufficient mana to cast the spell. If false, a major mana restoration item
        /// will be used instead.</param>
        /// <returns>True if a spell is cast. False otherwise.</returns>
        public async Task<bool> TauntNpcs(bool isLowCostSpell = true)
        {
            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = Self.TauntTargetIndex; i >= 0; i--)
            {
                Self.TauntTargetIndex--;

                if (await Zap(Self.Npcs[i], isLowCostSpell))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Zaps a target for ranged magic damage.
        /// </summary>
        /// <param name="target">The NPC to target for the attack.</param>
        /// <param name="isLowCostSpell">If true, a minor mana restoration item will be used if the
        /// caster lacks sufficient mana to cast the spell. If false, a major mana restoration item
        /// will be used instead.</param>
        /// <returns>True if a spell is cast. False otherwise.</returns>
        public async Task<bool> Zap(Npc target, bool isLowCostSpell = false)
        {
            return await SpellCommands.CastTargetableSpell(Self, ZapSpell, target, isLowCostSpell);
        }

        /// <summary>
        /// When called iteratively, this zaps a single NPC until death and then moves on to the
        /// next NPC and repeats.
        /// </summary>
        /// <returns>True if a spell is cast. False otherwise.</returns>
        public async Task<bool> ZapNpcs()
        {
            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = Self.Npcs.Count - 1; i >= 0; i--)
            {
                if (await Zap(Self.Npcs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Public Methods
    }
}
