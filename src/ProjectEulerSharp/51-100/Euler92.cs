using System.Linq;
using NUnit.Framework;
using System;
using Facet.Combinatorics;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 8581146)]
    public class Euler92 : EulerProblem
    {
        private HashSet<int> _eightyNinesCache = new HashSet<int>();
        private HashSet<int> _onesCache = new HashSet<int>();

        [Test]
        public override void Solve()
        {
            _eightyNinesCache.Add(89);
            _onesCache.Add(1);

            int resultCount = 0;

            for (int number = 1; number < 10000001; number++)
            {
                if (IsEightyNine(number))
                    resultCount++;
            }

            Verify(resultCount);
        }

        private bool IsEightyNine(int number)
        {
            if (_eightyNinesCache.Contains(number))
            {
                return true;
            }
            else if (_onesCache.Contains(number))
            {
                return false;
            }
            else
            {
                int sum = 0;

                while (number != 0)
                {
                    int a = number % 10;
                    sum += a * a;
                    number /= 10;
                }

                bool isEN = IsEightyNine(sum);
                if (isEN)
                {
                    if (!_eightyNinesCache.Contains(sum))
                        _eightyNinesCache.Add(sum);
                }
                else
                {
                    if (!_onesCache.Contains(sum))
                        _onesCache.Add(sum);
                }

                return isEN;
            }
        }
    }
}
