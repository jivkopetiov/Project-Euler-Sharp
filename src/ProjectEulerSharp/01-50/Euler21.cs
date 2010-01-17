using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 31626)]
    class Euler21 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long sum = SpecialCollections.AmicableNumbers(10000)
                                         .Sum(pair => pair.Key);

            Verify(sum);
        }
    }
}
