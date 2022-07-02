using System;

namespace P02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            int rowV = 0;
            int colV = 0;

            FillTheField(field, ref rowV, ref colV);

            int rods = 0;

            int movies = 0;
            bool isEnd = false;

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                movies++;
                switch (cmd)
                {
                    case "up":
                        rowV--;

                        if (!AreCoordinatesValid(field, rowV, colV))
                        {
                            rowV++;
                            continue;
                        }

                        if (field[rowV, colV] == 'R')
                        {
                            rowV++;
                            Console.WriteLine("Vanko hit a rod!");
                            rods++;
                            continue;
                        }
                        else if (field[rowV, colV] == 'C')
                        {
                            field[rowV + 1, colV] = '*';
                            field[rowV, colV] = 'E';
                            isEnd = true;
                            break;
                        }
                        else if (field[rowV, colV] == '*')
                        {
                            field[rowV, colV] = 'V';
                            field[rowV + 1, colV] = '*';
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                        }
                        else
                        {
                            field[rowV + 1, colV] = '*';
                            field[rowV, colV] = 'V';
                        }
                        break;

                    case "down":
                        rowV++;

                        if (!AreCoordinatesValid(field, rowV, colV))
                        {
                            rowV--;
                            continue;
                        }


                        if (field[rowV, colV] == 'R')
                        {
                            rowV--;
                            Console.WriteLine("Vanko hit a rod!");
                            rods++;
                            continue;
                        }
                        else if (field[rowV, colV] == 'C')
                        {
                            field[rowV - 1, colV] = '*';
                            field[rowV, colV] = 'E';
                            isEnd = true;
                            break;
                        }
                        else if (field[rowV, colV] == '*')
                        {
                            field[rowV, colV] = 'V';
                            field[rowV - 1, colV] = '*';
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                        }
                        else
                        {
                            field[rowV - 1, colV] = '*';
                            field[rowV, colV] = 'V';
                        }
                        break;

                    case "left":
                        colV--;

                        if (!AreCoordinatesValid(field, rowV, colV))
                        {
                            colV++;
                            continue;
                        }

                        if (field[rowV, colV] == 'R')
                        {
                            colV++;
                            Console.WriteLine("Vanko hit a rod!");
                            rods++;
                            continue;
                        }
                        else if (field[rowV, colV] == 'C')
                        {
                            field[rowV, colV + 1] = '*';
                            field[rowV, colV] = 'E';
                            isEnd = true;
                            break;
                        }
                        else if (field[rowV, colV] == '*')
                        {
                            field[rowV, colV] = 'V';
                            field[rowV, colV + 1] = '*';
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                        }
                        else
                        {
                            field[rowV, colV + 1] = '*';
                            field[rowV, colV] = 'V';
                        }
                        break;

                    case "right":
                        colV++;

                        if (!AreCoordinatesValid(field, rowV, colV))
                        {
                            colV--;
                            continue;
                        }

                        if (field[rowV, colV] == 'R')
                        {
                            colV--;
                            Console.WriteLine("Vanko hit a rod!");
                            rods++;
                            continue;
                        }
                        else if (field[rowV, colV] == 'C')
                        {
                            field[rowV, colV - 1] = '*';
                            field[rowV, colV] = 'E';
                            isEnd = true;
                            break;
                        }
                        else if (field[rowV, colV] == '*')
                        {
                            field[rowV, colV] = 'V';
                            field[rowV, colV - 1] = '*';
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                        }
                        else
                        {
                            field[rowV, colV - 1] = '*';
                            field[rowV, colV] = 'V';
                        }
                        break;
                }

                if (isEnd)
                {
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {GetHoles(field)} hole(s).");
                    PrintField(field);
                    return;
                }
            }

            Console.WriteLine($"Vanko managed to make {GetHoles(field)} hole(s) and he hit only {rods} rod(s).");

            PrintField(field);
        }
        private static void FillTheField(char[,] field, ref int rowV, ref int colV)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'V')
                    {
                        rowV = row;
                        colV = col;
                    }
                }
            }
        }
        private static bool AreCoordinatesValid(char[,] field, int rowV, int colV)
        {
            return rowV >= 0 && colV >= 0 && rowV < field.GetLength(0) && colV < field.GetLength(1);
        }
        private static int GetHoles(char[,] field)
        {
            int holes = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == '*' || field[row, col] == 'V' || field[row, col] == 'E')
                    {
                        holes++;
                    }
                }
            }
            return holes;
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
