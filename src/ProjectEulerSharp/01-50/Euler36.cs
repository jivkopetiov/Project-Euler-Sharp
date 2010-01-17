using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 872187)]
    public class Euler36 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long sum = PalindromesInBinAndDecimal(1000000).Sum();

            Verify(sum);
        }

        private IEnumerable<long> PalindromesInBinAndDecimal(int max)
        {
            foreach (long number in Enumerable.Range(1, max))
            {
                string binary = Convert.ToString(number, 2);

                if (binary[0] == '0')
                    continue;

                if (binary.IsPalindrome() && number.IsPalindrome())
                {
                    yield return number;
                }
            }
        }
    }
}
