using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 162)]
    public class Euler42 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            var triangleNumbers = Enumerable.Range(1, 100000)
                                            .Select(n => (long)((n * (n + 1)) / 2))
                                            .ToHashSet();

            int count = File.ReadAllText(@"TextFiles\Euler42.txt")
                            .Trim()
                            .Split(',')
                            .Select(t => t.Trim(' ', '"').ToLowerInvariant())
                            .Count(word => triangleNumbers.Contains(word.AlphabeticalWeight()));

            Verify(count);
        }
    }
}
