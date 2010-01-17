using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 4782)]
    class Euler25 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            var sequence = SpecialCollections.FibonacciSequence(fibo => fibo.Length < 1000);

            Verify(sequence.Count() + 1);
        }
    }
}
