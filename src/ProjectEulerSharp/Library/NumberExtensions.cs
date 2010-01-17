using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerSharp
{
    public static class NumberExtensions
    {
        public static byte[] Digits(this long number)
        {
            int digitCount = number.Length();

            byte[] digits = new byte[digitCount];

            int counter = 0;
            while (number != 0)
            {
                digits[counter] = (byte)(number % 10);
                number /= 10;
                counter++;
            }

            return digits;
        }

        public static byte[] Digits(this int number)
        {
            return Digits((long)number);
        }

        public static int Length(this long number)
        {
            return number.ToString().Length;
        }

        public static int Length(this int number)
        {
            return number.ToString().Length;
        }

        public static long FirstNDigits(this long number, int N)
        {
            int numberOfDigits = number.Length();

            if (numberOfDigits < N)
            {
                throw new ArgumentException(string.Format(
                    "N cannot be greater than the number of digits {0} of {1}",
                    numberOfDigits,
                    number));
            }

            long divisor = (long)Math.Pow(10.0, numberOfDigits - N);
            return number / divisor;
        }

        public static bool IsPrime(long number)
        {
            for (int counter = 2; counter <= Math.Sqrt(number); counter++)
                if (number % counter == 0)
                    return false;

            return true;
        }

        /// <summary>
        ///     Only works with digits
        /// </summary>
        public static int ConstructNumber(this IEnumerable<byte> sequence)
        {
            var array = sequence.ToArray();
            int number = 0;
            for (int i = 0; i < array.Length; i++)
            {
                number += (int)Math.Pow(10, i) * array[array.Length - i - 1];
            }

            return number;
        }

        public static IEnumerable<long> Divisors(this long number)
        {
            yield return 1;

            for (int counter = 2; counter <= number / 2; counter++)
            {
                if (number % counter == 0)
                {
                    yield return counter;
                }
            }
        }

        public static IEnumerable<long> Divisors(this int number)
        {
            return Divisors((long)number);
        }

        public static int DivisorsCount(this long number)
        {
            int product = 1;

            int counter = 0;

            var primes = Primes.BelowTenMillion;

            for (int i = 0; i < primes.Length; i++)
            {
                if (number % primes[i] == 0)
                {
                    counter = 0;
                    do
                    {
                        counter++;
                        number /= primes[i];
                    }
                    while (number % primes[i] == 0);

                    product *= counter + 1;

                    if (number == 1)
                        break;
                }
            }

            return product - 1;
        }

        public static int DivisorsCount(this int number)
        {
            return DivisorsCount((long)number);
        }


        public static bool IsPalindrome(this long number)
        {
            var dic = new Dictionary<long, long>();

            int counter = 1;
            while (number > 0)
            {
                dic.Add(counter, (number % 10));
                number = number / 10;
                counter++;
            }

            int digits = dic.Count;
            int index = digits;

            while (index > 0)
            {
                if (dic[index] != dic[digits - index + 1])
                {
                    return false;
                }
                index--;
            }

            return true;
        }

        public static bool IsPalindrome(this int number)
        {
            return IsPalindrome((long)number);
        }

        public static bool IsInteger(this double number)
        {
            return (number - Math.Floor(number) == 0);
        }

        public static int FactorialFast(this int number)
        {
            if (number == 0 || number == 1)
            {
                return 1;
            }

            int factorial = 1;

            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public static BigInt Factorial(this int number)
        {
            BigInt factorer = new BigInt(1);
            for (int counter = 1; counter <= 100; counter++)
            {
                factorer = factorer * counter;
            }

            return factorer;
        }


        public static IEnumerable<KeyValuePair<int, int>> PrimeFactors(this int number)
        {
            return PrimeFactors((long)number);
        }

        public static IEnumerable<KeyValuePair<int, int>> PrimeFactors(this long number)
        {
            int counter = 0;

            var primes = Primes.BelowTenMillion;

            for (int i = 0; i < primes.Length; i++)
            {
                if (number % primes[i] == 0)
                {
                    counter = 0;
                    do
                    {
                        counter++;
                        number /= primes[i];
                    }
                    while (number % primes[i] == 0);
                    yield return new KeyValuePair<int, int>(primes[i], counter);
                }

                if (number == 1)
                    yield break;
            }
        }

        public static long Power(this long number, int power)
        {
            return (long)Math.Pow(number, power);
        }

        public static long Power(this int number, int power)
        {
            return (long)Math.Pow(number, power);
        }
    }
}
