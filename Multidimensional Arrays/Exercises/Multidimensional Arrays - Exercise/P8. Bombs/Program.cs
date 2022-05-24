using System;
using System.Linq;

namespace P8._Bombs
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            FillMatrix(matrix);

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < coordinates.Length; i++)
            {
                int row = int.Parse(coordinates[i].Split(',')[0]);
                int col = int.Parse(coordinates[i].Split(',')[1]);

                DetonateTheBomb(matrix, row, col);
            }

            int aliveCells = 0;
            int sumAliveCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sumAliveCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");

            PrintMatrix(matrix);
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        private static void DetonateTheBomb(int[,] matrix, int row, int col)
        {
            int value = matrix[row, col];

            if (value <= 0)
            {
                return;
            }

            matrix[row, col] = 0;

            if (IsIndexValid(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
            {
                matrix[row - 1, col - 1] -= value;
            }
            if (IsIndexValid(matrix, row - 1, col) && matrix[row - 1, col] > 0)
            {
                matrix[row - 1, col] -= value;
            }
            if (IsIndexValid(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
            {
                matrix[row - 1, col + 1] -= value;
            }
            if (IsIndexValid(matrix, row, col - 1) && matrix[row, col - 1] > 0)
            {
                matrix[row, col - 1] -= value;
            }
            if (IsIndexValid(matrix, row, col + 1) && matrix[row, col + 1] > 0)
            {
                matrix[row, col + 1] -= value;
            }
            if (IsIndexValid(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
            {
                matrix[row + 1, col - 1] -= value;
            }
            if (IsIndexValid(matrix, row + 1, col) && matrix[row + 1, col] > 0)
            {
                matrix[row + 1, col] -= value;
            }
            if (IsIndexValid(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
            {
                matrix[row + 1, col + 1] -= value;
            }
        }
        private static bool IsIndexValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && matrix.GetLength(0) > row && matrix.GetLength(1) > col;
        }
        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowItems = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowItems[col];
                }
            }
        }
    }
}
