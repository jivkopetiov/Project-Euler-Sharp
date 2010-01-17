using System;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 21124)]
    class Euler17 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int result = Enumerable.Range(1, 1000)
                                   .Select(num => ConvertNumberToText(num))
                                   .Aggregate((s1, s2) => s1 + s2)
                                   .Replace(" ", "")
                                   .Length;

            Verify(result);
        }

        private string ConvertNumberToText(int number)
        {
            int tens = number % 100;
            int hundreds = (number / 100) % 10;
            int thousands = (number / 1000) % 10;

            if (thousands == 0 && hundreds == 0 && tens == 0)
                return "zero";

            else if (thousands == 0 && hundreds == 0)
                return ConvertTwoDigitToText(tens);

            else if (thousands == 0 && tens == 0)
                return String.Format("{0} hundred", ConvertDigitToText(hundreds));

            else if (hundreds == 0 && tens == 0)
                return String.Format("{0} thousand", ConvertDigitToText(thousands));

            else if (hundreds == 0)
                return String.Format("{0} thousand and {1}",
                                     ConvertDigitToText(thousands),
                                     ConvertTwoDigitToText(tens));

            else if (thousands == 0)
                return String.Format("{0} hundred and {1}",
                                     ConvertDigitToText(hundreds),
                                     ConvertTwoDigitToText(tens));

            else if (tens == 0)
                return String.Format("{0} thousand and {1} hundred",
                                              ConvertDigitToText(thousands),
                                              ConvertDigitToText(hundreds));

            else
                return String.Format("{0} thousand and {1} hundred and {2}",
                                              ConvertDigitToText(thousands),
                                              ConvertDigitToText(hundreds),
                                              ConvertTwoDigitToText(tens));
        }

        private string ConvertDigitToText(int digit)
        {
            switch (digit)
            {
                case 0:
                    return "";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new NotSupportedException("Cannot operate on non-digit numbers");
            }
        }

        private string ConvertTwoDigitToText(int twoDigit)
        {
            int digit = twoDigit % 10;
            int ten = (twoDigit / 10) % 10;

            switch (ten)
            {
                case 0:
                    return ConvertDigitToText(digit);
                case 1:
                    return ConvertTwoDigitWithOneToText(digit);
                case 2:
                    return "twenty " + ConvertDigitToText(digit);
                case 3:
                    return "thirty " + ConvertDigitToText(digit);
                case 4:
                    return "forty " + ConvertDigitToText(digit);
                case 5:
                    return "fifty " + ConvertDigitToText(digit);
                case 6:
                    return "sixty " + ConvertDigitToText(digit);
                case 7:
                    return "seventy " + ConvertDigitToText(digit);
                case 8:
                    return "eighty " + ConvertDigitToText(digit);
                case 9:
                    return "ninety " + ConvertDigitToText(digit);
                default:
                    throw new NotSupportedException("Cannot operate on non-digit numbers");
            }
        }

        private string ConvertTwoDigitWithOneToText(int digit)
        {
            switch (digit)
            {
                case 0:
                    return "ten";
                case 1:
                    return "eleven";
                case 2:
                    return "twelve";
                case 3:
                    return "thirteen";
                case 4:
                    return "fourteen";
                case 5:
                    return "fifteen";
                case 6:
                    return "sixteen";
                case 7:
                    return "seventeen";
                case 8:
                    return "eighteen";
                case 9:
                    return "nineteen";
                default:
                    throw new NotSupportedException("Cannot operate on non-digit numbers");
            }
        }
    }
}
