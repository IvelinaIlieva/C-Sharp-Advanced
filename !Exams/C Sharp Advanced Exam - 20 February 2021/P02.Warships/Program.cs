using System;
using System.Linq;

namespace P02.Warships
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] coordinates = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[size, size];

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            FillTheField(field, ref firstPlayerShips, ref secondPlayerShips);

            int totalCount = firstPlayerShips + secondPlayerShips;

            bool isEnd = false;

            for (int movies = 0; movies < coordinates.Length; movies++)
            {
                int[] currentCoordinates = coordinates[movies].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = currentCoordinates[0];
                int column = currentCoordinates[1];

                if (!IsIndexValid(field, row, column))
                {
                    continue;
                }

                IsShipDestroyed(field, row, column, ref firstPlayerShips, ref secondPlayerShips);

                if (field[row, column] == '#')
                {
                    CheckAround(field, row, column, ref firstPlayerShips, ref secondPlayerShips);
                }

                if (firstPlayerShips == 0 || secondPlayerShips == 0)
                {
                    isEnd = true;
                    break;
                }
            }

            if (isEnd)
            {
                Console.WriteLine(firstPlayerShips > 0
                    ? $"Player One has won the game! {totalCount-firstPlayerShips} ships have been sunk in the battle."
                    : $"Player Two has won the game! {totalCount-secondPlayerShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }

        private static void FillTheField(char[,] field, ref int firstPlayerShips, ref int secondPlayerShips)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }
        }
        private static bool IsIndexValid(char[,] field, int row, int column)
        {
            return row >= 0 && column >= 0 && row < field.GetLength(0) && column < field.GetLength(1);
        }
        private static void IsShipDestroyed(char[,] field, int row, int column, ref int firstPlayerShips, ref int secondPlayerShips)
        {
            if (field[row, column] == '>')
            {
                secondPlayerShips--;
                field[row, column] = 'X';
            }

            if (field[row, column] == '<')
            {
                firstPlayerShips--;
                field[row, column] = 'X';
            }
        }
        private static void CheckAround(char[,] field, int row, int column, ref int firstPlayerShips, ref int secondPlayerShips)
        {
            if (IsIndexValid(field, row - 1, column - 1))
            {
                IsShipDestroyed(field, row - 1, column - 1, ref firstPlayerShips,
                    ref secondPlayerShips);
            }

            if (IsIndexValid(field, row - 1, column))
            {
                IsShipDestroyed( field, row - 1, column, ref firstPlayerShips,
                    ref secondPlayerShips);
            }

            if (IsIndexValid(field, row - 1, column + 1))
            {
                IsShipDestroyed( field, row - 1, column + 1, ref firstPlayerShips,
                    ref secondPlayerShips);
            }

            if (IsIndexValid(field, row, column - 1))
            {
                IsShipDestroyed(field, row, column - 1, ref firstPlayerShips,
                    ref secondPlayerShips);
            }

            if (IsIndexValid(field, row, column + 1))
            {
                IsShipDestroyed( field, row, column + 1, ref firstPlayerShips,
                    ref secondPlayerShips);
            }

            if (IsIndexValid(field, row + 1, column - 1))
            {
                IsShipDestroyed( field, row + 1, column - 1, ref firstPlayerShips,
                    ref secondPlayerShips);
            }

            if (IsIndexValid(field, row + 1, column))
            {
                IsShipDestroyed(field, row + 1, column, ref firstPlayerShips,
                    ref secondPlayerShips);
            }

            if (IsIndexValid(field, row + 1, column + 1))
            {
                IsShipDestroyed( field, row + 1, column + 1, ref firstPlayerShips,
                    ref secondPlayerShips);
            }
        }
    }
}
