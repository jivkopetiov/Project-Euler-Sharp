using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 840)]
    public class Euler39 : EulerProblem
    {
        [Test]
        /// <summary>
        /// the solution of the system
        ///     a + b + c = p
        ///     a^2 + b^2 = c^2
        ///  is 
        ///  a = (p * (p - 2b)) / (2 * (p - b))
        /// </summary>
        public override void Solve()
        {
            int maxCounter = 0;
            int perimeterWithMaxCounter = 0;

            for (int p = 1; p <= 1000; p++)
            {
                int counter = 0;

                for (int b = 1; b < p / 2; b++)
                {
                    double a = (double)(p * (p - 2 * b)) / (double)(2 * (p - b));

                    if (a.IsInteger())
                    {
                        counter++;
                    }
                }

                // remove the duplicate solutions e.g. {3,4,5} and {4,3,5}
                counter /= 2;

                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    perimeterWithMaxCounter = p;
                }
            }

            Verify(perimeterWithMaxCounter);
        }
    }
}
