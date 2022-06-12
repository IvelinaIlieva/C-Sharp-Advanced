using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Beaver_at_Work
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            var curBeaverRow = 0;
            var curBeaverCol = 0;
            var branchCounter = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'B')
                    {
                        curBeaverRow = row;
                        curBeaverCol = col;
                    }
                    else if (char.IsLower(field[row, col]))
                    {
                        branchCounter++;
                    }
                }
            }

            List<char> branches = new List<char>();

            int lostBranches = 0;

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                if (cmd == "up")
                {
                    curBeaverRow--;

                    if (CheckTheField(field, size, curBeaverRow, curBeaverCol))
                    {
                        if (branches.Any())
                        {
                            branches.RemoveAt(branches.Count - 1);
                            lostBranches++;
                        }

                        curBeaverRow++;
                        continue;
                    }

                    if (CheckForBranch(field, curBeaverRow, curBeaverCol))
                    {
                        branches.Add(field[curBeaverRow, curBeaverCol]);
                        field[curBeaverRow, curBeaverCol] = 'B';
                        field[curBeaverRow + 1, curBeaverCol] = '-';
                    }
                    else if (field[curBeaverRow, curBeaverCol] == 'F')
                    {
                        field[curBeaverRow, curBeaverCol] = '-';
                        field[curBeaverRow + 1, curBeaverCol] = '-';

                        curBeaverRow = curBeaverRow != 0 ? 0 : field.GetLength(0) - 1;

                        if (CheckForBranch(field, curBeaverRow, curBeaverCol))
                        {
                            branches.Add(field[curBeaverRow, curBeaverCol]);
                        }

                        field[curBeaverRow, curBeaverCol] = 'B';
                    }
                    else
                    {
                        field[curBeaverRow, curBeaverCol] = 'B';
                        field[curBeaverRow + 1, curBeaverCol] = '-';
                    }
                }
                else if (cmd == "down")
                {
                    curBeaverRow++;
                    if (CheckTheField(field, size, curBeaverRow, curBeaverCol))
                    {
                        if (branches.Any())
                        {
                            branches.RemoveAt(branches.Count - 1);
                            lostBranches++;
                        }

                        curBeaverRow--;
                        continue;
                    }

                    if (CheckForBranch(field, curBeaverRow, curBeaverCol))
                    {
                        branches.Add(field[curBeaverRow, curBeaverCol]);
                        field[curBeaverRow, curBeaverCol] = 'B';
                        field[curBeaverRow - 1, curBeaverCol] = '-';
                    }
                    else if (field[curBeaverRow, curBeaverCol] == 'F')
                    {
                        field[curBeaverRow, curBeaverCol] = '-';
                        field[curBeaverRow - 1, curBeaverCol] = '-';

                        curBeaverRow = curBeaverRow == field.GetLength(0) - 1 ? 0 : field.GetLength(0) - 1;

                        if (CheckForBranch(field, curBeaverRow, curBeaverCol))
                        {
                            branches.Add(field[curBeaverRow, curBeaverCol]);
                        }

                        field[curBeaverRow, curBeaverCol] = 'B';
                    }
                    else
                    {
                        field[curBeaverRow, curBeaverCol] = 'B';
                        field[curBeaverRow - 1, curBeaverCol] = '-';
                    }
                }
                else if (cmd == "left")
                {
                    curBeaverCol--;
                    if (CheckTheField(field, size, curBeaverRow, curBeaverCol))
                    {
                        if (branches.Any())
                        {
                            branches.RemoveAt(branches.Count - 1);
                            lostBranches++;
                        }

                        curBeaverCol++;
                        continue;
                    }

                    if (CheckForBranch(field, curBeaverRow, curBeaverCol))
                    {
                        branches.Add(field[curBeaverRow, curBeaverCol]);
                        field[curBeaverRow, curBeaverCol] = 'B';
                        field[curBeaverRow, curBeaverCol + 1] = '-';
                    }
                    else if (field[curBeaverRow, curBeaverCol] == 'F')
                    {
                        field[curBeaverRow, curBeaverCol] = '-';
                        field[curBeaverRow, curBeaverCol + 1] = '-';

                        curBeaverCol = curBeaverCol != 0 ? 0 : field.GetLength(1) - 1;

                        if (CheckForBranch(field, curBeaverRow, curBeaverCol))
                        {
                            branches.Add(field[curBeaverRow, curBeaverCol]);
                        }

                        field[curBeaverRow, curBeaverCol] = 'B';
                    }
                    else
                    {
                        field[curBeaverRow, curBeaverCol] = 'B';
                        field[curBeaverRow, curBeaverCol + 1] = '-';
                    }
                }
                else if (cmd == "right")
                {
                    curBeaverCol++;
                    if (CheckTheField(field, size, curBeaverRow, curBeaverCol))
                    {
                        if (branches.Any())
                        {
                            branches.RemoveAt(branches.Count - 1);
                            lostBranches++;
                        }

                        curBeaverCol--;
                        continue;
                    }

                    if (CheckForBranch(field, curBeaverRow, curBeaverCol))
                    {
                        branches.Add(field[curBeaverRow, curBeaverCol]);
                        field[curBeaverRow, curBeaverCol - 1] = '-';
                        field[curBeaverRow, curBeaverCol] = 'B';
                    }
                    else if (field[curBeaverRow, curBeaverCol] == 'F')
                    {
                        field[curBeaverRow, curBeaverCol] = '-';
                        field[curBeaverRow, curBeaverCol - 1] = '-';

                        curBeaverCol = curBeaverCol == field.GetLength(1) - 1 ? 0 : field.GetLength(1) - 1;

                        if (CheckForBranch(field, curBeaverRow, curBeaverCol))
                        {
                            branches.Add(field[curBeaverRow, curBeaverCol]);
                        }

                        field[curBeaverRow, curBeaverCol] = 'B';
                    }
                    else
                    {
                        field[curBeaverRow, curBeaverCol - 1] = '-';
                        field[curBeaverRow, curBeaverCol] = 'B';
                    }

                }
                
                if (branchCounter == branches.Count + lostBranches)
                {
                    Console.WriteLine(
                        $"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
                    PrintMatrix(field);
                    return;
                }
            }

            Console.WriteLine(
                $"The Beaver failed to collect every wood branch. There are {branchCounter - branches.Count - lostBranches} branches left.");
            PrintMatrix(field);
        }

        private static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        
        private static bool CheckForBranch(char[,] field, int newRow, int newCol)
        {
            return char.IsLower(field[newRow, newCol]);
        }

        private static bool CheckTheField(char[,] field, int size, int row, int col)
        {
            return row < 0 || row >= size || col < 0 || col >= size;
        }
    }
}

