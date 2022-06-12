using System;
using System.Collections.Generic;

namespace P02._Armory
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            var armory = new char[size, size];

            var currRow = 0;
            var currCol = 0;

            List<int> mirrorsPosition = new List<int>();

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = input[col];

                    if (armory[row, col] == 'A')
                    {
                        currRow = row;
                        currCol = col;
                    }

                    if (armory[row, col] == 'M')
                    {
                        mirrorsPosition.Add(row);
                        mirrorsPosition.Add(col);
                    }
                }
            }

            bool hasMirrors = false;

            int mirr1Row = 0;
            int mirr1Col = 0;
            int mirr2Row = 0;
            int mirr2Col = 0;

            if (mirrorsPosition.Count > 0)
            {
                hasMirrors = true;
                mirr1Row = mirrorsPosition[0];
                mirr1Col = mirrorsPosition[1];
                mirr2Row = mirrorsPosition[2];
                mirr2Col = mirrorsPosition[3];
            }

            var sum = 0;

            while (sum < 65)
            {
                var direction = Console.ReadLine();

                armory[currRow, currCol] = '-';

                switch (direction)
                {
                    case "up":
                        currRow--;
                        if (!IsInRange(armory, currRow, currCol))
                        {
                            Console.WriteLine("I do not need more swords!");
                            Console.WriteLine($"The king paid {sum} gold coins.");

                            PrintMatrix(armory);
                            return;
                        }
                        if (hasMirrors)
                        {
                            if (armory[currRow, currCol] == 'M')
                            {
                                if (currRow == mirr1Row && currCol == mirr1Col)
                                {
                                    currRow = mirr2Row;
                                    currCol = mirr2Col;
                                    armory[mirr1Row, mirr1Col] = '-';
                                }
                                else
                                {
                                    currRow = mirr1Row;
                                    currCol = mirr1Col;
                                    armory[mirr2Row, mirr2Col] = '-';
                                }
                            }
                        }

                        if (char.IsDigit(armory[currRow, currCol]))
                        {
                            sum += armory[currRow, currCol] - 48;
                        }

                        armory[currRow, currCol] = 'A';
                        break;

                    case "down":
                        currRow++;
                        if (!IsInRange(armory, currRow, currCol))
                        {
                            Console.WriteLine("I do not need more swords!");
                            Console.WriteLine($"The king paid {sum} gold coins.");

                            PrintMatrix(armory);
                            return;
                        }
                        if (hasMirrors)
                        {
                            if (armory[currRow, currCol] == 'M')
                            {
                                if (currRow == mirr1Row && currCol == mirr1Col)
                                {
                                    currRow = mirr2Row;
                                    currCol = mirr2Col;
                                    armory[mirr1Row, mirr1Col] = '-';
                                }
                                else
                                {
                                    currRow = mirr1Row;
                                    currCol = mirr1Col;
                                    armory[mirr2Row, mirr2Col] = '-';
                                }
                            }
                        }

                        if (char.IsDigit(armory[currRow, currCol]))
                        {
                            sum += armory[currRow, currCol] - 48;
                        }

                        armory[currRow, currCol] = 'A';
                        break;

                    case "left":
                        currCol--;
                        if (!IsInRange(armory, currRow, currCol))
                        {
                            Console.WriteLine("I do not need more swords!");
                            Console.WriteLine($"The king paid {sum} gold coins.");

                            PrintMatrix(armory);
                            return;
                        }
                        if (hasMirrors)
                        {
                            if (armory[currRow, currCol] == 'M')
                            {
                                if (currRow == mirr1Row && currCol == mirr1Col)
                                {
                                    currRow = mirr2Row;
                                    currCol = mirr2Col;
                                    armory[mirr1Row, mirr1Col] = '-';
                                }
                                else
                                {
                                    currRow = mirr1Row;
                                    currCol = mirr1Col;
                                    armory[mirr2Row, mirr2Col] = '-';
                                }
                            }
                        }

                        if (char.IsDigit(armory[currRow, currCol]))
                        {
                            sum += armory[currRow, currCol] - 48;
                        }

                        armory[currRow, currCol] = 'A';
                        break;

                    case "right":
                        currCol++;
                        if (!IsInRange(armory, currRow, currCol))
                        {
                            Console.WriteLine("I do not need more swords!");
                            Console.WriteLine($"The king paid {sum} gold coins.");

                            PrintMatrix(armory);
                            return;
                        }
                        if (hasMirrors)
                        {
                            if (armory[currRow, currCol] == 'M')
                            {
                                if (currRow == mirr1Row && currCol == mirr1Col)
                                {
                                    currRow = mirr2Row;
                                    currCol = mirr2Col;
                                    armory[mirr1Row, mirr1Col] = '-';
                                }
                                else
                                {
                                    currRow = mirr1Row;
                                    currCol = mirr1Col;
                                    armory[mirr2Row, mirr2Col] = '-';
                                }
                            }
                        }

                        if (char.IsDigit(armory[currRow, currCol]))
                        {
                            sum += armory[currRow, currCol] - 48;
                        }

                        armory[currRow, currCol] = 'A';
                        break;
                }
            }

            if (sum >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {sum} gold coins.");

            PrintMatrix(armory);
        }

        private static void PrintMatrix(char[,] armory)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write(armory[row,col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsInRange(char[,] field, int row, int col)
        {
            return row >= 0 && col >= 0 && row < field.GetLength(0) && col < field.GetLength(1);
        }
    }
}
