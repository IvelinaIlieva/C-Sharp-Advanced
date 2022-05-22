using System;

namespace P7._Pascal_Triangle
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[][] triangle = new int[size][];

            for (int row = 0; row < size; row++)
            {
                triangle[row] = new int[row + 1];
                triangle[row][0] = 1;

                for (int col = 1; col < row; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }

                triangle[row][row] = 1;
            }

            foreach (int[] row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
