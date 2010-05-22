using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 669171001)]
    public class Euler28 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            var sum = MatrixExtensions.GenerateClockwiseSpiralMatrix(1001)
                                      .SumOfDiagonals();

            Verify(sum);
        }
    }
}
