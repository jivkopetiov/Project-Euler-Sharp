using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 233168)]
    public class Euler1 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int sum =
                Enumerable.Range(1, 999)
                          .Where(num => (num % 5 == 0 || num % 3 == 0))
                          .Sum();

            Verify(sum);
        }
    }
}
