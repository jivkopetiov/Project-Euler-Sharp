using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 232792560)]
    class Euler5 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            long foundNumber = -1;

            byte[] divisors = new byte[] { 19, 17, 16, 13, 11, 9, 7, 5 };

            for (long number = 2; number < 1000000000; number++)
            {
                for (byte index = 0; index < divisors.Length; index++)
                {
                    if (number % divisors[index] != 0) goto notfound;
                }

                foundNumber = number;
                goto found;

            notfound: ;
            }

        found: ;

            Verify(foundNumber);
        }
    }
}
