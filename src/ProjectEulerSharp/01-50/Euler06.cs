using System;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 25164150)]
    class Euler6 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long sumOfSquares = Enumerable.Range(1, 100)
                                          .Select(num => num * num)
                                          .Sum();
            long squareOfSum = (long)Math.Pow(Enumerable.Range(1, 100).Sum(), 2);
            long result = (long)Math.Abs(sumOfSquares - squareOfSum);

            Verify(result);
        }
    }
}
