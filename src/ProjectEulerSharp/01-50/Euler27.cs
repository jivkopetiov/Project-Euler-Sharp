using System.Linq;
using NUnit.Framework;
using System;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = -59231)]
    public class Euler27 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int maxLength = -1;
            int maxProduct = -1;

            foreach (int b in Primes.Below(1000))
            {
                for (int a = -999; a < 1000; a++)
                {
                    int n = 0;

                    while (true)
                    {
                        int prime = (n * n) + (n * a) + b;
                        if (Primes.BelowTenMillionHashSet.Contains(prime))
                        {
                            n++;
                        }
                        else
                        {
                            n--;
                            break;
                        }
                    }

                    if (n > maxLength)
                    {
                        maxLength = n;
                        maxProduct = a * b;
                    }
                }
            }

            Verify(maxProduct);
        }
    }
}
