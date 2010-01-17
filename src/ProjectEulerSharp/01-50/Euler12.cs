using NUnit.Framework;
using System.Linq;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 76576500)]
    class Euler12 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long result =
                SpecialCollections.TriangleNumbers(1000000)
                                  .First(number => number.DivisorsCount() >= 500);

            Verify(result);
        }
    }
}
