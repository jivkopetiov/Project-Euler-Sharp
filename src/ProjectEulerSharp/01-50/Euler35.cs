using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 55)]
    public class Euler35 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int count = CircularPrimes(1000000).Count();

            Verify(count);
        }

        private IEnumerable<int> CircularPrimes(int max)
        {
            foreach (int number in Enumerable.Range(1, max))
            {
                if (IsCircularPrime(number))
                {
                    yield return number;
                }
            }
        }

        private bool IsCircularPrime(int number)
        {
            if (!Primes.BelowTenMillionHashSet.Contains(number))
            {
                return false;
            }

            var siblings = CircularSiblings(number);

            return siblings.All(sibling => Primes.BelowTenMillionHashSet.Contains(sibling));
        }

        private IEnumerable<int> CircularSiblings(int number)
        {
            int digitsCount = number.Length();
            for (int index = 0; index < digitsCount - 1; index++)
            {
                int lastDigit = (number % 10);
                number /= 10;
                number += lastDigit * (int)Math.Pow(10, digitsCount - 1);

                yield return number;
            }
        }
    }
}
