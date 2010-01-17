using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 40730)]
    public class Euler34 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long sum = NumbersEqualToTheSumOfDigitFactorials(10000000).Sum();

            Verify(sum);
        }

        private IEnumerable<long> NumbersEqualToTheSumOfDigitFactorials(long max)
        {
            var digitFactorials = Enumerable.Range(0, 10)
                                            .Select(digit => digit.FactorialFast())
                                            .ToArray();

            long workerNumber = 0;
            int sum = 0;

            for (long number = 3; number < max; number++)
            {
                workerNumber = number;
                sum = 0;

                while (workerNumber != 0)
                {
                    sum += digitFactorials[workerNumber % 10];
                    workerNumber /= 10;
                }

                if (number == sum)
                {
                    yield return number;
                }
            }
        }
    }
}
