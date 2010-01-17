using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 648)]
    public class Euler20 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int sum = 100.Factorial()
                         .ToString()
                         .ToCharArray()
                         .Select(c => int.Parse(c.ToString()))
                         .Sum();

            Verify(sum);
        }
    }
}
