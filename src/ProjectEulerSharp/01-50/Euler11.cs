using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ProjectEulerSharp
{
    [TestFixture]
    [Metadata(Result = 70600674)]
    public class Euler11 : EulerProblem
    {
        [Test]
        public override void Solve()
        {
            int[][] matrix = File.ReadAllText(@"TextFiles\Euler11.txt")
                                 .Trim()
                                 .Split(new[] { "\r\n" }, StringSplitOptions.None)
                                 .Select(row => row.Trim()
                                                   .Split(' ')
                                                   .Select(num => int.Parse(num))
                                                   .ToArray())
                                 .ToArray();

            int maxProduct = 1;

            // horizontal
            for (int i = 0; i <= matrix.Length - 4; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    int product = matrix[i][j] * matrix[i + 1][j] * matrix[i + 2][j] * matrix[i + 3][j];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }
            }

            // vertical
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j <= matrix.Length - 4; j++)
                {
                    int product = matrix[i][j] * matrix[i][j + 1] * matrix[i][j + 2] * matrix[i][j + 3];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }
            }

            // diagonal left to right
            for (int i = 0; i <= matrix.Length - 4; i++)
            {
                for (int j = 0; j <= matrix.Length - 4; j++)
                {
                    int product = matrix[i][j] * matrix[i + 1][j + 1] * matrix[i + 2][j + 2] * matrix[i + 3][j + 3];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }
            }

            // diagonal right to left
            for (int i = 3; i < matrix.Length; i++)
            {
                for (int j = 0; j <= matrix.Length - 4; j++)
                {
                    int product = matrix[i][j] * matrix[i - 1][j + 1] * matrix[i - 2][j + 2] * matrix[i - 3][j + 3];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }
            }

            Verify(maxProduct);
        }
    }
}