using System.IO;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 210)]
    public class Euler40 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            var sequence = IrrationalDecimalFractionSequence().Take(1000000).ToArray();
            int result = sequence[0] *
                         sequence[9] *
                         sequence[99] *
                         sequence[999] *
                         sequence[9999] *
                         sequence[99999] *
                         sequence[999999];

            Verify(result);
        }

        public static IEnumerable<byte> IrrationalDecimalFractionSequence()
        {
            int counter = 0;
            while (true)
            {
                counter++;

                foreach (byte digit in counter.Digits().Reverse())
                {
                    yield return digit;
                }
            }
        }
    }
}
