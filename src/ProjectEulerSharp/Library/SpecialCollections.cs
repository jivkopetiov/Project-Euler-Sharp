using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace ProjectEulerSharp
{
    public static class SpecialCollections
    {
        /// <summary>
        ///     The system
        ///         a^2 + b^2 = c^2
        ///         a + b + c = sum
        ///     Has the following solution:
        ///     a = sum(sum - 2b) / 2(sum - b)
        /// </summary>
        public static IEnumerable<Triplet> PythagoreanTripletsWithTheSumOf(long sum)
        {
            for (int b = 1; b < sum / 2; b++)
            {
                double aFloat = (double)(sum * (sum - 2 * b)) / (double)(2 * (sum - b));

                if (aFloat.IsInteger())
                {
                    long a = (long)aFloat;
                    long c = (long)Math.Sqrt(a * a + b * b);
                    yield return new Triplet(a, b, c);
                }
            }
        }

        public static IEnumerable<long> TriangleNumbers(long max)
        {
            long currentSum = 0;
            for (long counter = 1; counter <= max; counter++)
            {
                currentSum += counter;
                yield return currentSum;
            }
        }

        public static IEnumerable<long> FibonacciSequenceSmall(long max)
        {
            int fibo1 = 1;
            int fibo2 = 2;

            do
            {
                yield return fibo1;
                yield return fibo2;

                fibo1 = fibo1 + fibo2;
                fibo2 = fibo1 + fibo2;
            }
            while (fibo2 <= max);
        }

        public static IEnumerable<BigInt> FibonacciSequence(Func<BigInt, bool> stopPredicate)
        {
            BigInt fibo1 = new BigInt(1);
            BigInt fibo2 = new BigInt(1);

            yield return fibo1;
            yield return fibo2;

            while (true)
            {
                fibo1 = fibo1 + fibo2;
                fibo2 = fibo1 + fibo2;

                if (!stopPredicate(fibo1))
                {
                    yield break;
                }

                yield return fibo1;

                if (!stopPredicate(fibo2))
                {
                    yield break;
                }

                yield return fibo2;
            }
        }

        public static IEnumerable<long> CollatzSequence(long number)
        {
            while (number != 1)
            {
                if (number % 2 == 0)
                {
                    number = number / 2;
                }
                else
                {
                    number = 3 * number + 1;
                }

                yield return number;
            }
        }

        public static IEnumerable<KeyValuePair<long, long>> AmicableNumbers(long max)
        {
            var map = new Dictionary<long, long>();

            for (long i = 2; i <= max; i++)
            {
                long sumOfDivisors = i.Divisors().Sum();
                map.Add(i, sumOfDivisors);
            }

            foreach (var entry in map)
            {
                if (map.ContainsKey(entry.Value) &&
                    map[entry.Value] == entry.Key &&
                    entry.Key != entry.Value)
                {
                    yield return entry;
                }
            }
        }

        public static IEnumerable<long> PalinromesThatAreProductOfNDigitNumbers(int digits)
        {
            long min = (long)Math.Pow(10.0, digits - 1);
            long max = (long)Math.Pow(10.0, digits) - 1;

            for (long i = max; i >= min; i--)
            {
                for (long j = max; j >= min; j--)
                {
                    long product = i * j;

                    if (product.IsPalindrome())
                    {
                        yield return product;
                    }
                }
            }
        }

        public static IEnumerable<long> TruncatablePrimes()
        {
            var allPrimes = Primes.BelowTenMillion.Select(p => (long)p).ToHashSet();

            var truncatablePrimes = new Collection<long>();

            long divisor = 0;
            int digits = 0;

            foreach (long prime in allPrimes)
            {
                if (prime / 10 == 1)
                {
                    continue;
                }

                divisor = prime;
                while (divisor != 0)
                {
                    divisor = divisor / 10;

                    if (divisor == 0)
                    {
                        break;
                    }

                    if (divisor == 1 || divisor == 4 || divisor == 6 || divisor == 8 || divisor == 9)
                    {
                        goto notfound;
                    }

                    if (!allPrimes.Contains(divisor))
                    {
                        goto notfound;
                    }
                }

                divisor = prime;
                digits = prime.Length();
                for (long product = (long)Math.Pow(10.0, (double)(digits - 1)); product > 1; product /= 10)
                {
                    divisor = divisor - (divisor / product) * product;

                    if (divisor == 0)
                    {
                        break;
                    }

                    if (!allPrimes.Contains(divisor))
                    {
                        goto notfound;
                    }
                }

                truncatablePrimes.Add(prime);

            notfound: ;
            }

            truncatablePrimes.Remove(2);
            truncatablePrimes.Remove(3);
            truncatablePrimes.Remove(5);
            truncatablePrimes.Remove(7);

            return truncatablePrimes;
        }
    }
}
