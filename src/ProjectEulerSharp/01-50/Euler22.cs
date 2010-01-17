using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 871198282)]
    class Euler22 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            string[] array = File.ReadAllText(@"TextFiles\Euler22.txt")
                                 .Trim()
                                 .Split(',')
                                 .Select(s => s.Trim('"'))
                                 .OrderBy(s => s)
                                 .ToArray();

            long totalScore = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int score = array[i].ToLowerInvariant().AlphabeticalWeight();

                // we increment i by one because the alphabical position starts from 1 instead of 0
                totalScore += (i + 1) * score;
            }

            Verify(totalScore);
        }
    }
}
