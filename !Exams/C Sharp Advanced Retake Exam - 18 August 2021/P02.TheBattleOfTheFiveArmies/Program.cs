using System;
using System.Data;
using System.Runtime.InteropServices;

namespace P02.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main()
        {
            int armour = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            char[][] field = new char[rows][];

            DrawTheField(field);

            int rowA = 0;
            int colA = 0;
            int rowM = 0;
            int colM = 0;

            GetTheStartPositions(field, ref rowA, ref colA, ref rowM, ref colM);

            while (rowA != rowM || colA != colM)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = cmdArgs[0];
                int rowO = int.Parse(cmdArgs[1]);
                int colO = int.Parse(cmdArgs[2]);

                field[rowO][colO] = 'O';

                armour--;

                int moveRow = 0;
                int moveCol = 0;

                bool isEnd = false;

                switch (direction)
                {
                    case "up":
                        moveRow--;
                        if (IsIndexValid(field, rowA + moveRow, colA + moveCol))
                        {
                            rowA += moveRow;
                            colA += moveCol;
                        }

                        Movement(field, ref rowA, ref colA, ref armour, ref moveRow, ref moveCol, ref isEnd);
                        if (isEnd) return;
                        
                        break;

                    case "down":
                        moveRow++;

                        if (IsIndexValid(field, rowA + moveRow, colA + moveCol))
                        {
                            rowA += moveRow;
                            colA += moveCol;
                        }

                        Movement(field, ref rowA, ref colA, ref armour, ref moveRow, ref moveCol, ref isEnd);
                        if (isEnd) return;
                        break;

                    case "left":
                        moveCol--;

                        if (IsIndexValid(field, rowA + moveRow, colA + moveCol))
                        {
                            rowA += moveRow;
                            colA += moveCol;
                        }

                        Movement(field, ref rowA, ref colA, ref armour, ref moveRow, ref moveCol, ref isEnd);
                        if (isEnd) return;
                        break;

                    case "right":
                        moveCol++;
                        if (IsIndexValid(field, rowA + moveRow, colA + moveCol))
                        {
                            rowA += moveRow;
                            colA += moveCol;
                        }

                        Movement(field, ref rowA, ref colA, ref armour, ref moveRow, ref moveCol, ref isEnd);
                        if (isEnd) return;
                        break;
                }
            }
        }

        private static void DrawTheField(char[][] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                field[row] = input;
            }
        }
        private static void GetTheStartPositions(char[][] field, ref int rowA, ref int colA, ref int rowM, ref int colM)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'A')
                    {
                        rowA = row;
                        colA = col;
                    }

                    if (field[row][col] == 'M')
                    {
                        rowM = row;
                        colM = col;
                    }
                }
            }
        }
        private static bool IsIndexValid(char[][] field, int row, int col)
        {
            return row >= 0 && col >= 0 && row < field.GetLength(0) && col < field[row].Length;
        }
        private static void Movement(char[][] field, ref int row, ref int col, ref int armour, ref int moveRow, ref int moveCol, ref bool isEnd)
        {
            if (field[row][col] == 'O')
            {
                armour -= 2;
                field[row - moveRow][col - moveCol] = '-';

                if (armour <= 0)
                {
                    field[row][col] = 'X';
                    Console.WriteLine($"The army was defeated at {row};{col}.");
                    PrintField(field);
                    isEnd = true;
                }
                else
                {
                    field[row][col] = 'A';
                }
            }
            else if (field[row][col] == 'M')
            {
                field[row][col] = '-';
                field[row - moveRow][col - moveCol] = '-';
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armour}");
                PrintField(field);
                isEnd = true;
            }
            else
            {
                field[row][col] = 'A';
                field[row - moveRow][col - moveCol] = '-';

                if (armour <= 0)
                {
                    field[row][col] = 'X';
                    field[row - moveRow][col - moveCol] = '-';
                    Console.WriteLine($"The army was defeated at {row};{col}.");
                    PrintField(field);
                    isEnd = true;
                }
            }
        }
        private static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}
