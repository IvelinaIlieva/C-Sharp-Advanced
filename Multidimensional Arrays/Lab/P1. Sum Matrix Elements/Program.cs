using System;
using System.Linq;

namespace P1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows,cols];

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

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            int sum = 0;

            foreach (int item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
