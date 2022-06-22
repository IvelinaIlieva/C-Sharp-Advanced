using System;

namespace P02.Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            int rowP = 0;
            int colP = 0;

            FillTheField(field, ref rowP, ref colP);
            
            bool hasWin = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string direction = Console.ReadLine();

                field[rowP, colP] = '-';

                switch (direction)
                {
                    case "up":
                        rowP--;

                        Teleport(IsIndexValid(field, rowP, colP), ref rowP, ref colP, field);

                        if (field[rowP, colP] == 'F')
                        {
                            field[rowP, colP] = 'f';
                            hasWin = true;
                            break;
                        }
                        else if (field[rowP, colP] == 'B')
                        {
                            rowP--;
                            Teleport(IsIndexValid(field, rowP, colP), ref rowP, ref colP, field);
                            if (field[rowP, colP] == 'F')
                            {
                                field[rowP, colP] = 'f';
                                hasWin = true;
                                break;
                            }
                            
                            field[rowP, colP] = 'f';
                        }
                        else if (field[rowP, colP] == 'T')
                        {
                            rowP++;
                            field[rowP, colP] = 'f';
                        }
                        else
                        {
                            field[rowP, colP] = 'f';
                        }
                        break;

                    case "down":
                        rowP++;

                        Teleport(IsIndexValid(field, rowP, colP), ref rowP, ref colP, field);

                        if (field[rowP, colP] == 'F')
                        {
                            field[rowP, colP] = 'f';
                            hasWin = true;
                            break;
                        }
                        else if (field[rowP, colP] == 'B')
                        {
                            rowP++;
                            Teleport(IsIndexValid(field, rowP, colP), ref rowP, ref colP, field);
                            if (field[rowP, colP] == 'F')
                            {
                                field[rowP, colP] = 'f';
                                hasWin = true;
                                break;
                            }
                            
                            field[rowP, colP] = 'f';
                        }
                        else if (field[rowP, colP] == 'T')
                        {
                            rowP--;
                            field[rowP, colP] = 'f';
                        }
                        else
                        {
                            field[rowP, colP] = 'f';
                        }
                        break;

                    case "left":
                        colP--;

                        Teleport(IsIndexValid(field, rowP, colP), ref rowP, ref colP, field);

                        if (field[rowP, colP] == 'F')
                        {
                            field[rowP, colP] = 'f';
                            hasWin = true;
                            break;
                        }
                        else if (field[rowP, colP] == 'B')
                        {
                            colP--;
                            Teleport(IsIndexValid(field, rowP, colP), ref rowP, ref colP, field);
                            if (field[rowP, colP] == 'F')
                            {
                                field[rowP, colP] = 'f';
                                hasWin = true;
                                break;
                            }
                            
                            field[rowP, colP] = 'f';
                        }
                        else if (field[rowP, colP] == 'T')
                        {
                            colP++;
                            field[rowP, colP] = 'f';
                        }
                        else
                        {
                            field[rowP, colP] = 'f';
                        }
                        break;

                    case "right":
                        colP++;
                        Teleport(IsIndexValid(field, rowP, colP), ref rowP, ref colP, field);

                        if (field[rowP, colP] == 'F')
                        {
                            field[rowP, colP] = 'f';
                            hasWin = true;
                            break;
                        }
                        else if (field[rowP, colP] == 'B')
                        {
                            colP++;
                            Teleport(IsIndexValid(field, rowP, colP), ref rowP, ref colP, field);
                            if (field[rowP, colP] == 'F')
                            {
                                field[rowP, colP] = 'f';
                                hasWin = true;
                                break;
                            }
                            
                            field[rowP, colP] = 'f';
                        }
                        else if (field[rowP, colP] == 'T')
                        {
                            colP--;
                            field[rowP, colP] = 'f';
                        }
                        else
                        {
                            field[rowP, colP] = 'f';
                        }
                        break;
                }

                if (hasWin)
                {
                    break;
                }
            }

            Console.WriteLine(hasWin ? "Player won!" : "Player lost!");

            PrintField(field);
        }
        
        private static void FillTheField(char[,] field, ref int rowP, ref int colP)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == 'f')
                    {
                        rowP = row;
                        colP = col;
                    }
                }
            }
        }
        private static bool IsIndexValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
        private static void Teleport(bool b, ref int rowP, ref int colP, char[,] field)
        {
            if (!b)
            {
                if (rowP < 0)
                {
                    rowP = field.GetLength(0) - 1;
                }
                else if (colP < 0)
                {
                    colP = field.GetLength(1) - 1;
                }
                else if (rowP == field.GetLength(0))
                {
                    rowP = 0;
                }
                else if (colP == field.GetLength(1))
                {
                    colP = 0;
                }
            }
        }
        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
