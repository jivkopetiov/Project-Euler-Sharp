using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 1366)]
    class Euler16 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            BigInt number = new BigInt(1);
            for (int counter = 0; counter < 1000; counter++)
            {
                number = number + number;
            }

            int sum = number.ToString()
                            .ToCharArray()
                            .Select(c => int.Parse(c.ToString()))
                            .Sum();

            Verify(sum);
        }
    }
}
