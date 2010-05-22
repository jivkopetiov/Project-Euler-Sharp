using System;
using System.Collections.Generic;

namespace ProjectEulerSharp
{
    public static class MatrixExtensions
    {
        public static int SumOfDiagonals(this int[,] matrix)
        {
            int sum = 0;
            int rank = matrix.GetUpperBound(1);

            for (int i = 0; i <= rank; i++)
            {
                sum += matrix[i, i];
                if (i != rank / 2)
                {
                    sum += matrix[rank - i, i];
                }
            }

            return sum;
        }

        public static List<int> GetDiagonalNumbers(this int[,] matrix)
        {
            int rank = matrix.GetLength(0);

            var diagonalNumbers = new List<int>();
            for (int i = 0; i < rank; i++)
            {
                diagonalNumbers.Add(matrix[i, i]);
            }

            for (int i = 0; i < rank; i++)
            {
                if (i != rank - i - 1)
                {
                    diagonalNumbers.Add(matrix[i, rank - i - 1]);
                }
            }

            return diagonalNumbers;
        }

        public static int[,] GenerateClockwiseSpiralMatrix(int rank)
        {
            int[,] spiral = new int[rank, rank];

            int i = rank / 2;
            int j = rank / 2;
            spiral[i, j] = 1;
            int counter = 1;
            int currentRank = 1;

            while (currentRank <= rank)
            {
                // move right
                for (int repetitions = 1; repetitions <= currentRank; repetitions++)
                {
                    i++;
                    if (i >= rank) return spiral;
                    spiral[i, j] = ++counter;
                }

                // move down
                for (int repetitions = 1; repetitions <= currentRank; repetitions++)
                {
                    j++;
                    if (j >= rank) return spiral;
                    spiral[i, j] = ++counter;
                }

                currentRank++;

                // move left
                for (int repetitions = 1; repetitions <= currentRank; repetitions++)
                {
                    i--;
                    if (i < 0) return spiral;
                    spiral[i, j] = ++counter;
                }

                // move up
                for (int repetitions = 1; repetitions <= currentRank; repetitions++)
                {
                    j--;
                    if (j < 0) return spiral;
                    spiral[i, j] = ++counter;
                }

                currentRank++;
            }

            return spiral;
        }

        public static int[,] GenerateAntiClockwiseSpiralMatrix(int rank)
        {
            int[,] spiral = new int[rank, rank];

            int i = rank / 2;
            int j = rank / 2;
            spiral[i, j] = 1;
            int counter = 1;
            int currentRank = 1;

            while (currentRank <= rank)
            {
                // move right
                for (int repetitions = 1; repetitions <= currentRank; repetitions++)
                {
                    i++;
                    if (i >= rank) return spiral;
                    spiral[i, j] = ++counter;
                }

                // move up
                for (int repetitions = 1; repetitions <= currentRank; repetitions++)
                {
                    j--;
                    if (j < 0) return spiral;
                    spiral[i, j] = ++counter;
                }
                currentRank++;

                // move left
                for (int repetitions = 1; repetitions <= currentRank; repetitions++)
                {
                    i--;
                    if (i < 0) return spiral;
                    spiral[i, j] = ++counter;
                }

                // move down
                for (int repetitions = 1; repetitions <= currentRank; repetitions++)
                {
                    j++;
                    if (j >= rank) return spiral;
                    spiral[i, j] = ++counter;
                }

                currentRank++;
            }

            return spiral;
        }

        public static void Print(this int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[j, i]);
                }
                Console.WriteLine();
            }
        }
    }
}
