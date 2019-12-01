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
    internal static class Index
    {
        internal static int Parse(string letter, char upperBound = 'Z')
        {
            return TryParse(letter, out var result, upperBound)
                ? result
                : throw new Exception($"Failed to parse letter '{letter}' into an index. Values must be between 'a' and 'z' or 'A' and '{upperBound}'.");
        }

        internal static bool TryParse(string letter, out int result, char upperBound = 'Z')
        {
            if (upperBound < 'A' || upperBound > 'Z')
            {
                throw new Exception($"Invalid index parsing upper bound '{upperBound}'. Value must be between 'A' and 'Z'.");
            }

            if (string.IsNullOrWhiteSpace(letter) || letter.Length != 1)
            {
                result = 0;
                return false;
            }

            if (letter[0] >= 'a' && letter[0] <= 'z')
            {
                result = letter[0] - 'a';
                return true;
            }

            if (letter[0] >= 'A' && letter[0] <= upperBound)
            {
                result = letter[0] - 'A' + 26;
                return true;
            }

            result = 0;
            return false;
        }
    }
}
