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

namespace TkMemory.Domain.Infrastructure
{
    internal static class Letter
    {
        internal static string Parse(int index, int upperBound = 51)
        {
            return TryParse(index, out var result, upperBound)
                ? result
                : throw new Exception($"Failed to parse index '{index}' into a letter. Values must be between '0' and '51'.");
        }

        internal static bool TryParse(int index, out string result, int upperBound = 51)
        {
            if (upperBound < 0 || upperBound > 51)
            {
                throw new Exception($"Invalid letter parsing upper bound '{upperBound}'. Value must be between '0' and '51'.");
            }

            if (index < 0 || index > upperBound)
            {
                result = null;
                return false;
            }

            var letter = index < 26
                ? (char)(index + 97)
                : (char)(index + 39);

            result = letter.ToString();
            return true;
        }
    }
}
