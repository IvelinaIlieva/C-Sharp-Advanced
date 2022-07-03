using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] garden = new int[dimensions[0], dimensions[1]];

            CreateGarden(garden);

            List<int> flowerCoordinates = new List<int>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = cmd.Split().Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (!IsInRange(garden, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                garden[row, col]++;
                flowerCoordinates.Add(row);
                flowerCoordinates.Add(col);
            }

            for (int coordinates = 0; coordinates < flowerCoordinates.Count; coordinates += 2)
            {
                int currRow = flowerCoordinates[coordinates];
                int currCol = flowerCoordinates[coordinates + 1];

                for (int row = 0; row < garden.GetLength(0); row++)
                {
                    garden[row, currCol]++;
                }

                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[currRow, col]++;
                }

                garden[currRow, currCol] -= 2;
            }

            PrintGarden(garden);
        }

        private static void CreateGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }
        }
        private static bool IsInRange(int[,] garden, int row, int col)
        {
            return row >= 0 && col >= 0 && row < garden.GetLength(0) && col < garden.GetLength(1);
        }
        private static void PrintGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
