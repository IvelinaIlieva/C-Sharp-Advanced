using System;
using System.Linq;

namespace P02.Survivor
{
    internal class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] beach = new char[rows][];

            FillBeach(beach);

            int tokens = 0;
            int opponentTokens = 0;

            string cmd;
            while ((cmd = Console.ReadLine()) != "Gong")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (cmdType == "Find")
                {
                    if (IsIndexValid(beach, row, col))
                    {
                        CheckForTokens(beach, row, col, ref tokens);
                    }
                }
                else if (cmdType == "Opponent")
                {
                    string direction = cmdArgs[3];

                    if (IsIndexValid(beach, row, col))
                    {
                        CheckForTokens(beach, row, col, ref opponentTokens);
                    }
                    else
                    {
                        continue;
                    }

                    for (int steps = 0; steps < 3; steps++)
                    {
                        switch (direction)
                        {
                            case "up":
                                row--;
                                break;
                            case "down":
                                row++;
                                break;
                            case "left":
                                col--;
                                break;
                            case "right":
                                col++;
                                break;
                        }

                        if (IsIndexValid(beach, row, col))
                        {
                            CheckForTokens(beach, row, col, ref opponentTokens);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            PrintBeach(beach);

            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
              
        private static void FillBeach(char[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[row] = inputRow;
            }
        }
        private static bool IsIndexValid(char[][] beach, int row, int col)
        {
            return row >= 0 && col >= 0 && row < beach.GetLength(0) && col < beach[row].Length;
        }
        private static void CheckForTokens(char[][] beach, int row, int col, ref int tokens)
        {
            if (beach[row][col] == 'T')
            {
                tokens++;
                beach[row][col] = '-';
            }
        }
        private static void PrintBeach(char[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }
        }
    }
}
