using System;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Linq;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 40824)]
    class Euler8 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int[] numbers = File.ReadAllText(@"TextFiles\Euler08.txt")
                                .ReplaceWithRegex(@"\s", "")
                                .ToCharArray()
                                .Select(ch => int.Parse(ch.ToString()))
                                .ToArray();

            int maxProduct = 1;
            for (int counter = 0; counter < numbers.Length - 4; counter++)
            {
                int product = numbers[counter] *
                              numbers[counter + 1] *
                              numbers[counter + 2] *
                              numbers[counter + 3] *
                              numbers[counter + 4];

                if (product > maxProduct)
                {
                    maxProduct = product;
                }
            }

            Verify(maxProduct);
        }
    }
}
