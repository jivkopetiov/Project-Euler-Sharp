using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 5777)]
    public class Euler46 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            var primes = Primes.Below(10000);
            var primesHash = primes.ToHashSet();

            int foundNumber = -1;

            for (int number = 3; number < 100000; number += 2)
            {
                if (primesHash.Contains(number)) { continue; }

                foreach (int prime in primes.Where(p => p < number))
                {
                    for (int factorer = 1; factorer < Math.Sqrt(number); factorer++)
                    {
                        if (number == prime + 2 * factorer * factorer)
                        {
                            goto next;
                        }
                    }
                }

                foundNumber = number;
                break;

            next: ;
            }

            Verify(foundNumber);
        }
    }
}
