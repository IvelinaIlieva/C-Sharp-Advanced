namespace P02.Bee
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            const int MIN_FLOWERS = 5;

            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            int rowB = 0;
            int colB = 0;

            GetField(field, ref rowB, ref colB);

            int pollinatedFlowers = 0;

            bool isOutOfField = false;

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                field[rowB, colB] = '.';

                switch (cmd)
                {
                    case "up":
                        rowB--;
                        CheckTheField(field, ref rowB, ref colB, ref isOutOfField, cmd, ref pollinatedFlowers);
                        break;

                    case "down":
                        rowB++;
                        CheckTheField(field, ref rowB, ref colB, ref isOutOfField, cmd, ref pollinatedFlowers);
                        break;

                    case "left":
                        colB--;
                        CheckTheField(field, ref rowB, ref colB, ref isOutOfField, cmd, ref pollinatedFlowers);
                        break;

                    case "right":
                        colB++;
                        CheckTheField(field, ref rowB, ref colB, ref isOutOfField, cmd, ref pollinatedFlowers);
                        break;
                }

                if (isOutOfField)
                {
                    break;
                }

                field[rowB, colB] = 'B';
            }

            if (isOutOfField)
            {
                Console.WriteLine("The bee got lost!");
            }

            Console.WriteLine(pollinatedFlowers < MIN_FLOWERS
                ? $"The bee couldn't pollinate the flowers, she needed {MIN_FLOWERS - pollinatedFlowers} flowers more"
                : $"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");

            PrintField(field);
        }

        private static void GetField(char[,] field, ref int rowB, ref int colB)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'B')
                    {
                        rowB = row;
                        colB = col;
                    }
                }
            }
        }
        private static void CheckTheField(char[,] field, ref int rowB, ref int colB, ref bool isOutOfField, string cmd, ref int pollinatedFlowers)
        {
            if (IsInRange(field, rowB, colB))
            {
                CheckForFlower(field, rowB, colB, ref pollinatedFlowers);

                CheckForBonus(field, ref rowB, ref colB, ref isOutOfField, cmd, ref pollinatedFlowers);
            }
            else
            {
                isOutOfField = true;
            }
        }
        private static bool IsInRange(char[,] field, int rowB, int colB)
        {
            return rowB >= 0 && colB >= 0 && rowB < field.GetLength(0) && colB < field.GetLength(1);
        }
        private static void CheckForFlower(char[,] field, int rowB, int colB, ref int pollinatedFlowers)
        {
            if (field[rowB, colB] == 'f')
            {
                pollinatedFlowers++;
            }
        }
        private static void CheckForBonus(char[,] field, ref int rowB, ref int colB, ref bool isOutOfField, string cmd, ref int pollinatedFlowers)
        {
            if (field[rowB, colB] == 'O')
            {
                field[rowB, colB] = '.';

                switch (cmd)
                {
                    case "up": rowB--; break;
                    case "down": rowB++; break;
                    case "left": colB--; break;
                    case "right": colB++; break;
                }

                if (IsInRange(field, rowB, colB))
                {
                    CheckForFlower(field, rowB, colB, ref pollinatedFlowers);
                }
                else
                {
                    isOutOfField = true;
                }
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
