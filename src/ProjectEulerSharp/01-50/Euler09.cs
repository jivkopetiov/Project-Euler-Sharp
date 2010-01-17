using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 31875000)]
    class Euler9 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            var triplet = SpecialCollections.PythagoreanTripletsWithTheSumOf(1000).First();
            long product = triplet.First * triplet.Second * triplet.Third;

            Verify(product);
        }
    }
}
