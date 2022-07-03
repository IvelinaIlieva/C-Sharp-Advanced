using System;
using System.Collections.Generic;

namespace P02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] bakery = new char[size, size];

            int currRow = 0;
            int currCol = 0;

            List<int> pillarsPositions = new List<int>();

            FillBakery(bakery, ref currRow, ref currCol, pillarsPositions);

            const int MONEY_NEEDED = 50;

            int collectedMoney = 0;

            bool isOut = false;


            while (collectedMoney < MONEY_NEEDED)
            {
                string command = Console.ReadLine();

                bakery[currRow, currCol] = '-';

                switch (command)
                {
                    case "up":
                        currRow--;
                        CheckNewPosition(bakery, ref currRow, ref currCol, ref collectedMoney, ref isOut, pillarsPositions);
                        break;

                    case "down":
                        currRow++;
                        CheckNewPosition(bakery, ref currRow, ref currCol, ref collectedMoney, ref isOut, pillarsPositions);
                        break;

                    case "left":
                        currCol--;
                        CheckNewPosition(bakery, ref currRow, ref currCol, ref collectedMoney, ref isOut, pillarsPositions);
                        break;

                    case "right":
                        currCol++;
                        CheckNewPosition(bakery, ref currRow, ref currCol, ref collectedMoney, ref isOut, pillarsPositions);
                        break;
                }

                if (isOut)
                {
                    break;
                }
            }

            Console.WriteLine(isOut
                ? "Bad news, you are out of the bakery."
                : "Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {collectedMoney}");
            PrintBakery(bakery);
        }

        private static void PrintBakery(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }
        private static void FillBakery(char[,] bakery, ref int currRow, ref int currCol, List<int> pillars)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    bakery[row, col] = input[col];

                    if (bakery[row, col] == 'S')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    else if (bakery[row, col] == 'O')
                    {
                        pillars.Add(row);
                        pillars.Add(col);
                    }
                }
            }
        }
        private static bool IsInRange(char[,] bakery, int currRow, int currCol)
        {
            return currRow >= 0 && currCol >= 0 && currRow < bakery.GetLength(0) && currCol < bakery.GetLength(1);
        }
        private static void CheckNewPosition(char[,] bakery, ref int currRow, ref int currCol, ref int collectedMoney, ref bool isOut, List<int> pillarsPositions)
        {
            if (!IsInRange(bakery, currRow, currCol))
            {
                isOut = true;
                return;
            }

            bool isTherePillars = pillarsPositions.Count > 0;

            if (char.IsDigit(bakery[currRow, currCol]))
            {
                collectedMoney += bakery[currRow, currCol] - 48;
            }
            else if (isTherePillars)
            {
                if (bakery[currRow, currCol] == 'O')
                {
                    bakery[currRow, currCol] = '-';

                    if (currRow == pillarsPositions[0] && currCol == pillarsPositions[1])
                    {
                        currRow = pillarsPositions[2];
                        currCol = pillarsPositions[3];

                    }
                    else
                    {
                        currRow = pillarsPositions[0];
                        currCol = pillarsPositions[1];
                    }
                }
            }

            bakery[currRow, currCol] = 'S';
        }
    }
}
