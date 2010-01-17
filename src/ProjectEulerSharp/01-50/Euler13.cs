using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 5537376230)]
    class Euler13 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long result = File.ReadAllText(@"TextFiles\Euler13.txt")
                              .Trim()
                              .Split(new[] { "\r\n" }, StringSplitOptions.None)
                              .Select(s => s.Substring(0, 17))
                              .Select(s => long.Parse(s))
                              .Sum()
                              .FirstNDigits(10);

            Verify(result);
        }
    }
}
