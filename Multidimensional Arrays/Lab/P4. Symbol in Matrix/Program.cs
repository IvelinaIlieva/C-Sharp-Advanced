using System;
using System.Linq;

namespace P4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rowsItems = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowsItems[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            bool isFound = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (symbol == matrix[row, col])
                    {
                        isFound = true;
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
