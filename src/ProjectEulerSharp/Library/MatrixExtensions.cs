using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static int[,] GenerateSpiralMatrix(int rank)
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
    }
}
