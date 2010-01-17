using System.Linq;
using NUnit.Framework;
using System;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 142857)]
    public class Euler52 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int foundNumber = -1;
            int candidate = -1;
            for (int number = 1; number < 1000000; number++)
            {
                var digits = number.Digits().ToHashSet();

                for (int iteration = 2; iteration <= 6; iteration++)
                {
                    candidate = number * iteration;

                    while (candidate != 0)
                    {
                        if (!digits.Contains((byte)(candidate % 10)))
                        {
                            goto notFound;
                        }
                        candidate /= 10;
                    }
                }

                foundNumber = number;
                break;

            notFound: ;
            }

            Verify(foundNumber);
        }
    }
}
