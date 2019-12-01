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

using System.Linq;
using System.Threading.Tasks;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Caster;
using TkMemory.Integration.TkClient.Properties.Group;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Poet
{
    /// <summary>
    /// Commands for spells specific to Poets that are used restore the mana.
    /// </summary>
    public class PoetManaCommands : CasterManaCommands
    {
        #region Fields

        private const double DefaultInspireManaPercentCeiling = 0.8;

        private readonly KeySpell _inspireSpell;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns mana restoration spells from a Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public PoetManaCommands(PoetClient self) : base(self)
        {
            _inspireSpell = self.Spells.KeySpells.Inspire;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Transfers mana from the caster to the target. Inspires will only be performed if the
        /// caster possesses the Invoke spell and the target has a lower current mana percentage
        /// than the specified ceiling.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <param name="manaPercentCeiling">The mana percentage threshold below which a target
        /// is eligible to be Inspired.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Inspire(TkClient target, double manaPercentCeiling = DefaultInspireManaPercentCeiling)
        {
            if (target.Self.Mana.Percent > manaPercentCeiling)
            {
                return false;
            }

            return await Inspire(target.Self.Name, target.Self.Uid);
        }

        /// <summary>
        /// Transfers mana from the caster to the target. Inspires will only be performed if the
        /// caster possesses the Invoke spell and the target has a lower current mana percentage
        /// than the specified ceiling.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <param name="manaPercentCeiling">The mana percentage threshold below which a target
        /// is eligible to be Inspired.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Inspire(GroupMember target, double manaPercentCeiling = DefaultInspireManaPercentCeiling)
        {
            if (Self.Group.Mana.GetPercent(target.Position) > manaPercentCeiling)
            {
                return false;
            }

            return await Inspire(target.Name, target.Uid);
        }

        /// <summary>
        /// Iterates through the caster's group and casts Inspire on the first group member found
        /// to be eligible for it. The method will exit and return true as soon as the spell is
        /// cast on one group member. If no group members are eligible for the spell, the method
        /// will return false. The priority order is the caster, multibox group members who are
        /// Rogues or Warriors, and then external group members with an attempt to exclude Mages,
        /// other Poets, and anyone with sufficiently high max mana to drain too much mana from
        /// the caster.
        /// </summary>
        /// <param name="manaPercentCeiling">The mana percentage threshold below which a target
        /// is eligible to be Inspired.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> InspireGroup(double manaPercentCeiling = DefaultInspireManaPercentCeiling)
        {
            foreach (var fighter in Self.Group.MultiboxMembers.Where(member =>
                member.Self.BasePath == TkClient.BasePath.Warrior ||
                member.Self.BasePath == TkClient.BasePath.Rogue))
            {
                return await Inspire(fighter);
            }

            foreach (var externalMember in Self.Group.ExternalMembers)
            {
                var i = externalMember.Position;

                // Tries to weed out Mages, Poets, and other targets with relatively large max mana.
                if (Self.Group.Mana.GetMax(i) > Self.Group.Vita.GetMax(i) / 2 ||
                    Self.Group.Mana.GetMax(i) > Self.Self.Mana.Max / 2)
                {
                    return false;
                }

                if (Self.Group.Mana.GetPercent(i) < manaPercentCeiling && await Inspire(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<bool> Inspire(string targetName, uint targetUid)
        {
            if (InvokeSpell == null)
            {
                return false;
            }

            return await SpellCommands.CastTargetableSpell(Self, _inspireSpell, targetUid, targetName, true);
        }

        #endregion Private Methods
    }
}
