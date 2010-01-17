using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 134043)]
    public class Euler47 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            var primes = Primes.Below(10000);

            int worker = -1;
            int counter = -1;
            byte matchingNumbers = 0;
            int foundNumber = -1;

            foreach (int number in Enumerable.Range(1, 1000000))
            {
                worker = number;
                counter = 0;

                for (int index = 0; index < primes.Length; index++)
                {
                    if (worker % primes[index] == 0)
                    {
                        do
                        {
                            worker /= primes[index];
                        }
                        while (worker % primes[index] == 0);
                        counter++;

                        if (counter == 4)
                        {
                            goto match;
                        }

                        if (counter > 4 || number == 1)
                            goto noMatch;
                    }
                }

            noMatch: ;

                matchingNumbers = 0;
                continue;


            match: ;

                matchingNumbers++;
                if (matchingNumbers == 4)
                {
                    foundNumber = number - 3;
                    break;
                }
            }

            Verify(foundNumber);
        }
    }
}
