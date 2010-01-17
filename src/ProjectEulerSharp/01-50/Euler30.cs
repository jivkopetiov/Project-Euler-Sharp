using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 443839)]
    class Euler30 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long sum = FindNumbers(1000000).Sum();

            Verify(sum);
        }

        private IEnumerable<long> FindNumbers(long max)
        {
            var digitPowers = Enumerable.Range(0, 10)
                                        .Select(digit => (int)digit.Power(5))
                                        .ToArray();

            long number = 10;
            while (number < max)
            {
                int sum = number.Digits().Select(digit => digitPowers[digit]).Sum();
                if (number == sum)
                {
                    yield return number;
                }

                number++;
            }
        }
    }
}

