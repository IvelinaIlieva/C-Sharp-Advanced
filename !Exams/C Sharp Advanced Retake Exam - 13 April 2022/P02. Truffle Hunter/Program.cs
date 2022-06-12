using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Truffle_Hunter
{
    internal class Program
    {
        static void Main()
        {
            int side = int.Parse(Console.ReadLine());

            char[,] forest = new char[side, side];

            FillTheMatrix(forest);

            Dictionary<char, int> trufflesOfPeter = new Dictionary<char, int>
            {
                {'B', 0},
                {'S', 0},
                {'W', 0}
            };

            int boarTruffles = 0;

            string cmd;
            while ((cmd = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = cmd.Split();
                int currRow = int.Parse(cmdArgs[1]);
                int currCol = int.Parse(cmdArgs[2]);

                if (cmd.StartsWith("Collect"))
                {
                    if (CheckIsTruffle(forest, currRow, currCol))
                    {
                        trufflesOfPeter[forest[currRow, currCol]]++;
                        forest[currRow, currCol] = '-';
                    }
                }
                else if (cmd.StartsWith("Wild_Boar"))
                {
                    string direction = cmdArgs[3];

                    switch (direction)
                    {
                        case "up":
                            for (int row = currRow; row >= 0; row -= 2)
                            {
                                boarTruffles += BoarMovement(forest, row, currCol);
                            }

                            break;

                        case "down":
                            for (int row = currRow; row < side; row += 2)
                            {
                                boarTruffles += BoarMovement(forest, row, currCol);
                            }
                            break;

                        case "left":
                            for (int col = currCol; col >= 0; col -= 2)
                            {
                                boarTruffles += BoarMovement(forest, currRow, col);
                            }
                            break;

                        case "right":
                            for (int col = currCol; col < side; col += 2)
                            {
                                boarTruffles += BoarMovement(forest, currRow, col);
                            }
                            break;
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {trufflesOfPeter['B']} black, {trufflesOfPeter['S']} summer, and {trufflesOfPeter['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");

            PrintMatrix(forest);
        }

        private static void PrintMatrix(char[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write(forest[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int BoarMovement(char[,] forest, int row, int col)
        {
            int boarTruffles = 0;

            if (CheckIsTruffle(forest, row, col))
            {
                boarTruffles++;
                forest[row, col] = '-';
            }

            return boarTruffles;
        }

        private static bool CheckIsTruffle(char[,] forest, int row, int col)
        {
            return forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W';
        }

        private static void FillTheMatrix(char[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    forest[row, col] = currRow[col];
                }
            }
        }
    }
}
