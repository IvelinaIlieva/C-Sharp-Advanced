namespace P02.Snake
{
    using System;

    internal class Program
    {
        private const int MinFood = 10;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rowS = -1;
            int colS = -1;

            int rowB1 = -1;
            int colB1 = -1;

            int rowB2 = -1;
            int colB2 = -1;

            char[,] field = new char[size, size];
            FillTheField(field, ref rowS, ref colS, ref rowB1, ref colB1, ref rowB2, ref colB2);

            int foodCount = 0;
            bool isOutOfRange = false;

            while (foodCount < MinFood)
            {
                string direction = Console.ReadLine();

                field[rowS, colS] = '.';

                switch (direction)
                {
                    case "up":
                        rowS--;
                        CheckTheField(field, ref rowS, ref colS, ref isOutOfRange, ref rowB1, ref colB1, ref rowB2,
                            ref colB2, ref foodCount);
                        break;

                    case "down":
                        rowS++;
                        CheckTheField(field, ref rowS, ref colS, ref isOutOfRange, ref rowB1, ref colB1, ref rowB2,
                            ref colB2, ref foodCount);
                        break;

                    case "left":
                        colS--;
                        CheckTheField(field, ref rowS, ref colS, ref isOutOfRange, ref rowB1, ref colB1, ref rowB2,
                            ref colB2, ref foodCount);
                        break;

                    case "right":
                        colS++;
                        CheckTheField(field, ref rowS, ref colS, ref isOutOfRange, ref rowB1, ref colB1, ref rowB2,
                            ref colB2, ref foodCount);
                        break;
                }

                if (isOutOfRange)
                {
                    break;
                }
            }

            Console.WriteLine(isOutOfRange 
            ? "Game over!"
            : "You won! You fed the snake.");

            Console.WriteLine($"Food eaten: {foodCount}");
            PrintField(field);
        }

        private static void FillTheField(char[,] field, ref int rowS, ref int colS, ref int rowB1, ref int colB1, ref int rowB2, ref int colB2)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowChars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowChars[col];

                    if (rowChars[col] == 'S')
                    {
                        rowS = row;
                        colS = col;
                    }

                    if (rowChars[col] == 'B')
                    {
                        if (rowB1 == -1 && colB1 == -1)
                        {
                            rowB1 = row;
                            colB1 = col;
                        }
                        else
                        {
                            rowB2 = row;
                            colB2 = col;
                        }
                    }
                }
            }
        }
        private static bool IsOutOfRange(char[,] field, int rowS, int colS) 
            => rowS < 0 || colS < 0 || rowS >= field.GetLength(0) || colS >= field.GetLength(1);

        private static void CheckTheField(char[,] field, ref int rowS, ref int colS, ref bool isOutOfRange, ref int rowB1, ref int colB1, ref int rowB2, ref int colB2, ref int foodCount)
        {
            if (IsOutOfRange(field, rowS, colS))
            {
                isOutOfRange = true;
            }
            else
            {
                if (field[rowS, colS] == '*')
                {
                    foodCount++;
                }
                else if (field[rowS, colS] == 'B')
                {
                    if (rowS == rowB1 && colS == colB1)
                    {
                        rowS = rowB2;
                        colS = colB2;

                        field[rowB1, colB1] = '.';
                    }
                    else
                    {
                        rowS = rowB1;
                        colS = colB1;

                        field[rowB2, colB2] = '.';
                    }
                }

                field[rowS, colS] = 'S';
            }
        }

        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
