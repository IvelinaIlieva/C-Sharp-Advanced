using System;
using System.Linq;

namespace P5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            const int Submatrix_Size = 2;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowsItems = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowsItems[col];
                }
            }

            int maxSum = int.MinValue;
            int currElementRow = 0;
            int currElementCol = 0;

            for (int row = 0; row < rows - (Submatrix_Size - 1); row++)
            {
                for (int col = 0; col < cols - (Submatrix_Size - 1); col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        currElementRow = row;
                        currElementCol = col;
                    }
                }
            }

            for (int row = currElementRow; row < currElementRow + Submatrix_Size; row++)
            {
                for (int col = currElementCol; col < currElementCol + Submatrix_Size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
