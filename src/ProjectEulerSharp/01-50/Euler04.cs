using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 906609)]
    class Euler4 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long maxPalindrome = SpecialCollections.PalinromesThatAreProductOfNDigitNumbers(3).Max();

            Verify(maxPalindrome);
        }
    }
}
