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
using NUnit.Framework;

// ReSharper disable CompareOfFloatsByEqualityOperator
// ReSharper disable once InvertIf

namespace TkMemory.Tests.Unit
{
    [TestFixture]
    internal class EvaluateDoubleAsPercentageTests
    {
        [Test]
        public void TestEvaluateDoubleAsPercentage()
        {
            Assert.That(EvaluateAsPercentage(-15) == 0);
            Assert.That(EvaluateAsPercentage(-1.5) == 0);
            Assert.That(EvaluateAsPercentage(-1) == 0);
            Assert.That(EvaluateAsPercentage(-0.5) == 0);
            Assert.That(EvaluateAsPercentage(0) == 0);
            Assert.That(EvaluateAsPercentage(0.5) == 0.5);
            Assert.That(EvaluateAsPercentage(1) == 0.01);
            Assert.That(EvaluateAsPercentage(1.5) == 0.015);
            Assert.That(EvaluateAsPercentage(15) == 0.15);
        }

        /// <summary>
        /// Admittedly a terrible way to test a private method, but this method should always be
        /// equivalent to double.EvaluateAsPercentage().
        /// </summary>
        private static double EvaluateAsPercentage(double value)
        {
            if (value >= 1 || value <= -1)
            {
                value /= 100;
            }

            if (value < 0)
            {
                Console.WriteLine($"Warning: Negative percentages are not allowed. {value:P2} was replaced with {0:P2}.");
                value = 0;
            }

            return value;
        }
    }
}
