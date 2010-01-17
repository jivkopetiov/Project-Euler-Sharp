using System;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 6857)]
    public class Euler3 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int maxPrimeFactor = 600851475143.PrimeFactors()
                                             .Select(pair => pair.Key)
                                             .Max();

            Verify(maxPrimeFactor);
        }
    }
}
