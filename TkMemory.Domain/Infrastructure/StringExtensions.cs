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
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TkMemory.Domain.Infrastructure
{
    internal static class StringExtensions
    {
        private static readonly Regex CamelCaseRegex = new Regex(@"(\B[A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", RegexOptions.Compiled);

        internal static string CamelCaseToString(this string value)
        {
            return CamelCaseRegex.Replace(value, " $1");
        }

        internal static string RemoveApostrohes(this string value)
        {
            return value.Replace("'", string.Empty);
        }

        internal static string Sort(this string value)
        {
            var lines = new List<string>(value.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            lines.Sort();
            return new StringBuilder(string.Join(Environment.NewLine, lines.ToArray())).ToString();
        }
    }
}
