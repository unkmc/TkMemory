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

namespace TkMemory.Domain.Spells.KeySpells.Priorities
{
    /// <summary>
    /// Key spell selection priorities for spells known to all paths.
    /// </summary>
    public class Peasant
    {
        /// <summary>
        /// Used to teleport to people. Person must be in an area that allows approaching, citizenship in the same kingdom,
        /// and be in your group to approach or else a "Fizzle" message is seen.
        /// </summary>
        public static readonly KeySpell Approach = new KeySpell("Approach", "Approach", 30);

        /// <summary>
        /// Teleport to North, South, East, or West Gate.
        /// </summary>
        public static readonly KeySpell Gateway = new KeySpell("Gateway", "Gateway", 0);

        /// <summary>
        /// Used to teleport people to you. Person must be in an area that allows approaching, citizenship in the same kingdom,
        /// and be in your group to approach or else a "Fizzle" message is seen.
        /// </summary>
        public static readonly KeySpell Summon = new KeySpell("Summon", "Summon", 30);
    }
}
