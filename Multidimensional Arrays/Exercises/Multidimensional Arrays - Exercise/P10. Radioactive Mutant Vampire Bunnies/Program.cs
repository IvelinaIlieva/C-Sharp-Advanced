using System;
using System.Collections.Generic;
using System.Linq;

namespace P10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            char[,] field = new char[rows, cols];
            FillMatrix(field);

            char[] commands = Console.ReadLine().ToCharArray();

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            int currRow = startRow;
            int currCol = startCol;

            int winRow = 0;
            int winCol = 0;

            bool hasWin = false;

            foreach (char cmd in commands)
            {
                if (cmd == 'U')
                {
                    if (!IsIndexValid(field, currRow - 1, currCol))
                    {
                        hasWin = true;
                        field[currRow, currCol] = '.';
                        winRow = currRow;
                        winCol = currCol;
                        BunnySpread(field);
                        break;
                    }

                    field[currRow, currCol] = '.';
                    currRow--;

                    if (field[currRow, currCol] == 'B')
                    {
                        BunnySpread(field);
                        break;
                    }
                    field[currRow, currCol] = 'P';

                    BunnySpread(field);

                    if (field[currRow, currCol] == 'B')
                    {
                        break;
                    }
                }
                else if (cmd == 'D')
                {
                    if (!IsIndexValid(field, currRow + 1, currCol))
                    {
                        hasWin = true;
                        field[currRow, currCol] = '.';
                        winRow = currRow;
                        winCol = currCol;
                        BunnySpread(field);
                        break;
                    }

                    field[currRow, currCol] = '.';
                    currRow++;

                    if (field[currRow, currCol] == 'B')
                    {
                        BunnySpread(field);
                        break;
                    }
                    field[currRow, currCol] = 'P';

                    BunnySpread(field);

                    if (field[currRow, currCol] == 'B')
                    {
                        break;
                    }
                }
                else if (cmd == 'L')
                {
                    if (!IsIndexValid(field, currRow, currCol - 1))
                    {
                        hasWin = true;
                        field[currRow, currCol] = '.';
                        winRow = currRow;
                        winCol = currCol;
                        BunnySpread(field);
                        break;
                    }

                    field[currRow, currCol] = '.';
                    currCol--;

                    if (field[currRow, currCol] == 'B')
                    {
                        BunnySpread(field);
                        break;
                    }
                    field[currRow, currCol] = 'P';

                    BunnySpread(field);

                    if (field[currRow, currCol] == 'B')
                    {
                        break;
                    }
                }
                else if (cmd == 'R')
                {
                    if (!IsIndexValid(field, currRow, currCol + 1))
                    {
                        hasWin = true;
                        field[currRow, currCol] = '.';
                        winRow = currRow;
                        winCol = currCol;
                        BunnySpread(field);
                        break;
                    }

                    field[currRow, currCol] = '.';
                    currCol++;

                    if (field[currRow, currCol] == 'B')
                    {
                        BunnySpread(field);
                        break;
                    }
                    field[currRow, currCol] = 'P';

                    BunnySpread(field);

                    if (field[currRow, currCol] == 'B')
                    {
                        break;
                    }
                }
            }
            PrintMatrix(field);

            Console.WriteLine(hasWin != true ? $"dead: {currRow} {currCol}" : $"won: {winRow} {winCol}");
        }

        private static void BunnySpread(char[,] field)
        {
            Queue<string> currBunnies = new Queue<string>();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row,col] == 'B')
                    {
                        string currBunny = row + "," + col;
                        currBunnies.Enqueue(currBunny);
                    }
                }
            }

            foreach (string bunny in currBunnies)
            {
                int row = int.Parse(bunny.Split(',')[0]);
                int col = int.Parse(bunny.Split(',')[1]);

                if (IsIndexValid(field, row + 1, col))
                {
                    field[row + 1, col] = 'B';
                }

                if (IsIndexValid(field, row - 1, col))
                {
                    field[row - 1, col] = 'B';
                }

                if (IsIndexValid(field, row, col - 1))
                {
                    field[row, col - 1] = 'B';
                }

                if (IsIndexValid(field, row, col + 1))
                {
                    field[row, col + 1] = 'B';
                }
            }
        }
        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowItems = Console.ReadLine().ToCharArray();

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
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
