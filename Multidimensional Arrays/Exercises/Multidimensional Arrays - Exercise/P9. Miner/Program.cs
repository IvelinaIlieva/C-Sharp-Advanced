using System;
using System.Linq;

namespace P9._Miner
{
    internal class Program
    {
        static void Main()
        {

            int size = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[size, size];

            FillMatrix(field);

            int startRow = 0;
            int startCol = 0;
            int totalCoal = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (field[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }

                    if (field[row, col] == 'c')
                    {
                        totalCoal++;
                    }
                }
            }

            int currCoal = 0;
            int currRow = startRow;
            int currCol = startCol;

            foreach (string command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (IsIndexValid(field, currRow - 1, currCol))
                        {
                            currRow--;

                            if (field[currRow, currCol] == 'c')
                            {
                                currCoal++;

                                if (currCoal == totalCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }

                                field[currRow, currCol] = '*';
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, { currCol})");
                                return;
                            }
                        }
                        break;
                    case "down":
                        if (IsIndexValid(field, currRow + 1, currCol))
                        {
                            currRow++;

                            if (field[currRow, currCol] == 'c')
                            {
                                currCoal++;

                                if (currCoal == totalCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }

                                field[currRow, currCol] = '*';
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, { currCol})");
                                return;
                            }
                        }
                        break;
                    case "left":
                        if (IsIndexValid(field, currRow, currCol - 1))
                        {
                            currCol--;

                            if (field[currRow, currCol] == 'c')
                            {
                                currCoal++;

                                if (currCoal == totalCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }

                                field[currRow, currCol] = '*';
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, { currCol})");
                                return;
                            }
                        }
                        break;
                    case "right":
                        if (IsIndexValid(field, currRow, currCol + 1))
                        {
                            currCol++;

                            if (field[currRow, currCol] == 'c')
                            {
                                currCoal++;

                                if (currCoal == totalCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }

                                field[currRow, currCol] = '*';
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, { currCol})");
                                return;
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"{totalCoal - currCoal} coals left. ({currRow}, {currCol})");
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowItems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowItems[col];
                }
            }
        }
        private static bool IsIndexValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && matrix.GetLength(0) > row && matrix.GetLength(1) > col;
        }
    }
}
