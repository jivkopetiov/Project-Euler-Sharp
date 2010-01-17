using System.IO;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 16695334890)]
    public class Euler43 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long result = Enumerable.Range(1, 999)
                                    .Select(n => (long)n)
                                    .Where(n => n % 17 == 0)
                                    .Filter(3, 13)
                                    .Filter(4, 11)
                                    .Filter(5, 7)
                                    .Filter(6, 5)
                                    .Filter(7, 3)
                                    .Filter(8, 2)
                                    .Where(n => n.Length() == 9)
                                    .Select(n => (n.NextDigitInPandigitalForm() * 10.Power(9)) + n)
                                    .Sum();

            Verify(result);
        }
    }

    public static class Euler43Extensions
    {
        public static IEnumerable<long> Filter(this IEnumerable<long> numbers, int startingIndex, byte divisor)
        {
            long powerOfNewDigit = 10.Power(startingIndex);
            long powerOfOldDigit = 10.Power(startingIndex - 2);

            foreach (long number in numbers)
            {
                for (int counter = 0; counter < 10; counter++)
                {
                    if ((counter * 100 + number / powerOfOldDigit) % divisor == 0)
                    {
                        long newNumber = counter * powerOfNewDigit + number;
                        int digitsCount = newNumber.Digits().Distinct().Count();

                        if ((digitsCount == startingIndex + 1) ||
                            (digitsCount == startingIndex && counter == 0))
                        {
                            yield return newNumber;
                        }
                    }
                }
            }
        }

        public static byte NextDigitInPandigitalForm(this long number)
        {
            var digits = number.Digits();
            for (byte i = 0; i < 10; i++)
            {
                if (!digits.Contains(i))
                {
                    return i;
                }
            }

            return 255;
        }
    }
}

