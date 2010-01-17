using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 748317)]
    class Euler37 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long sum = SpecialCollections.TruncatablePrimes().Sum();

            Verify(sum);
        }
    }
}
