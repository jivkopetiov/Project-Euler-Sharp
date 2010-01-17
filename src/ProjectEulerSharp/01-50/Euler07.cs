using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 104743)]
    class Euler7 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int prime = Primes.BelowTenMillion
                              .ToArray()[10000];

            Verify(prime);
        }
    }
}
