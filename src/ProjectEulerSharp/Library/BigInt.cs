using System;
using System.Linq;

namespace ProjectEulerSharp
{
    public struct BigInt
    {
        private byte[] digits;

        public BigInt(byte[] bytes)
        {
            digits = bytes;
        }

        public BigInt(string number)
        {
            digits = number.ToCharArray()
                           .Select(ch => byte.Parse(ch.ToString()))
                           .Reverse()
                           .ToArray();
        }

        public BigInt(int number)
        {
            digits = number.Digits();
        }

        public byte this[int index]
        {
            get { return digits[index]; }
        }

        public int Length
        {
            get { return digits.Length; }
        }

        public override string ToString()
        {
            string result = string.Empty;
            for (int index = digits.Length - 1; index >= 0; index--)
            {
                result += digits[index];
            }
            return result;
        }

        public long ToNumber()
        {
            long result = 0;
            for (int index = 0; index < digits.Length; index++)
            {
                result += 10.Power(index) * digits[index];
            }

            return result;
        }

        public static BigInt operator +(BigInt first, BigInt second)
        {
            return SumInternal(first, second);
        }

        public static BigInt operator *(BigInt number, long multiplier)
        {
            return MultiplyInternal(number, multiplier);
        }

        public static BigInt operator *(BigInt number, int multiplier)
        {
            return MultiplyInternal(number, (long)multiplier);
        }

        private static BigInt MultiplyInternal(BigInt number, long multiplier)
        {
            if (multiplier % 10 == 0)
            {
                byte factorsOfTen = 0;
                while (multiplier % 10 == 0)
                {
                    multiplier /= 10;
                    factorsOfTen++;
                }

                number = new BigInt(
                                Enumerable.Repeat<byte>(0, factorsOfTen)
                                          .Concat(number.digits)
                                          .ToArray());
            }

            if (multiplier == 1)
            {
                return number;
            }
            else if (multiplier == 0)
            {
                return default(BigInt);
            }

            byte carry = 0;
            byte[] resultArray = null;
            byte product = 0;

            BigInt result = new BigInt(new byte[0]);
            var digits = multiplier.Digits();

            for (int digitIndex = 0; digitIndex < digits.Length; digitIndex++)
            {
                if (digits[digitIndex] == 0)
                {
                    continue;
                }

                resultArray = new byte[number.Length];
                carry = 0;
                product = 0;

                for (int index = 0; index < number.Length; index++)
                {
                    product = (byte)(number[index] * digits[digitIndex]);

                    product += carry;

                    if (product > 9)
                    {
                        carry = (byte)(product / 10);
                        product %= 10;
                    }
                    else
                    {
                        carry = 0;
                    }

                    resultArray[index] = product;
                }

                if (carry != 0)
                {
                    resultArray = resultArray.Concat(new byte[] { carry }).ToArray();
                }

                result = result + (new BigInt(resultArray) * 10.Power(digitIndex));
            }

            return result;
        }

        private static BigInt SumInternal(BigInt first, BigInt second)
        {
            if (first.Length < second.Length)
            {
                BigInt swap = first;
                first = second;
                second = swap;
            }

            bool carry = false;
            byte[] result = new byte[first.Length];
            byte sumDigits = 0;

            for (int index = 0; index < first.Length; index++)
            {
                if (index < second.Length)
                {
                    sumDigits = (byte)(first[index] + second[index]);
                }
                else
                {
                    sumDigits = first[index];
                }

                if (carry)
                {
                    sumDigits++;
                }

                if (sumDigits > 9)
                {
                    sumDigits -= 10;
                    carry = true;
                }
                else
                {
                    carry = false;
                }

                result[index] = (byte)sumDigits;
            }

            if (carry)
            {
                result = result.Concat(new byte[] { 1 }).ToArray();
            }

            return new BigInt(result);
        }
    }
}
