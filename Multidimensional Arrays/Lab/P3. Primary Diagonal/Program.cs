using System;
using System.Linq;

namespace P3._Primary_Diagonal
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            int primaryDiagonalSum = 0;

            for (int row = 0; row < size; row++)
            {
                int[] rowsItems = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowsItems[col];

                    if (row == col)
                    {
                        primaryDiagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
