using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 4613732)]
    public class Euler2 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long sumOfEvenFiboNumbers =
                SpecialCollections.FibonacciSequenceSmall(4000000)
                                  .Where(num => num % 2 == 0)
                                  .Sum();

            Verify(sumOfEvenFiboNumbers);
        }
    }
}
