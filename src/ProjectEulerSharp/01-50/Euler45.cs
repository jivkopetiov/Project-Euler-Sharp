using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 1533776805)]
    public class Euler45 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long result = TrianglePentagonalAndHexagonalNumbers(1000000).ToArray()[2];

            Verify(result);
        }

        public static IEnumerable<long> TrianglePentagonalAndHexagonalNumbers(int max)
        {
            var triangles = Enumerable.Range(1, max)
                                      .Select(n => (long)n)
                                      .Select(n => ((n * (n + 1)) / 2));

            var pentagonals = Enumerable.Range(1, max)
                                        .Select(n => (long)n)
                                        .Select(n => ((n * ((3 * n) - 1)) / 2))
                                        .ToHashSet();

            var hexagonals = Enumerable.Range(1, max)
                                       .Select(n => (long)n)
                                       .Select(n => (n * ((2 * n) - 1)))
                                       .ToHashSet();

            foreach (long triangle in triangles)
            {
                if (pentagonals.Contains(triangle) && hexagonals.Contains(triangle))
                {
                    yield return triangle;
                }
            }
        }
    }
}
