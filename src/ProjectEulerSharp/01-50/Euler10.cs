using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 142913828922)]
    class Euler10 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long sum = Primes.Below(2000000)
                             .Select(i => (long)i)
                             .Sum();

            Verify(sum);
        }
    }
}
