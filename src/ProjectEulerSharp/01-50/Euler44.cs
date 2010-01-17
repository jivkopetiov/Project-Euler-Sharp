using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 5482660)]
    public class Euler44 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long minimal = FindDifferences(10000).Min();

            Verify(minimal);
        }

        private IEnumerable<long> FindDifferences(int max)
        {
            var pentagonals = Enumerable.Range(1, max)
                                        .Select(n => (long)n)
                                        .Select(n => ((n * (3 * n - 1)) / 2))
                                        .ToArray();

            var pentagonalsHash = pentagonals.ToHashSet();

            long minDifference = long.MaxValue;

            for (int i = 0; i < pentagonals.Length - 1; i++)
            {
                for (int j = i + 1; j < pentagonals.Length; j++)
                {
                    if (pentagonalsHash.Contains(pentagonals[i] + pentagonals[j]) &&
                        pentagonalsHash.Contains(pentagonals[j] - pentagonals[i]))
                    {
                        long difference = pentagonals[j] - pentagonals[i];
                        if (difference < minDifference)
                        {
                            minDifference = difference;
                            yield return difference;
                        }
                    }
                }
            }
        }
    }
}
