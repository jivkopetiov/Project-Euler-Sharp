using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 837799)]
    class Euler14 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int result = Enumerable.Range(1, 1000000)
                                   .Select(n => new
                                   {
                                       Key = n,
                                       Length = SpecialCollections.CollatzSequence(n).Count()
                                   })
                                   .MaxBy(pair => pair.Length).Key;

            Verify(result);
        }
    }
}

