using System;

namespace P02._Pawn_Wars
{
    internal class Program
    {
        static void Main()
        {
            char[,] board = new char[8, 8];
            int rowW = 0;
            int colW = 0;
            int rowB = 0;
            int colB = 0;

            FillMatrix(board, ref rowW, ref colW, ref rowB, ref colB);

            if (Math.Abs(colW - colB) == 1 && rowW != rowB)
            {
                Capture(board, ref rowW, ref colW, ref rowB, ref colB);
            }
            else
            {
                Promote(board, ref rowW, ref colW, ref rowB, ref colB);
            }
        }

        private static void FillMatrix(char[,] board, ref int rowW, ref int colW, ref int rowB, ref int colB)
        {
            for (int row = 0; row < 8; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = input[col];

                    if (board[row, col] == 'w')
                    {
                        rowW = row;
                        colW = col;
                    }

                    if (board[row, col] == 'b')
                    {
                        rowB = row;
                        colB = col;
                    }
                }
            }
        }
        private static void Capture(char[,] board, ref int rowW, ref int colW, ref int rowB, ref int colB)
        {
            int movements = rowW - rowB;

            int winRow = 0;
            int winCol = 0;

            string chessPosition = "";

            if (movements % 2 != 0)
            {
                winRow = 7 - (rowB + movements / 2);
                winCol = colB;

                chessPosition = GetPosition(winRow, winCol);
                Console.WriteLine($"Game over! White capture on {chessPosition}.");
            }
            else
            {
                winRow = 7 - (rowW - movements / 2);
                winCol = colW;

                chessPosition = GetPosition(winRow, winCol);
                Console.WriteLine($"Game over! Black capture on {chessPosition}.");
            }
        }
        private static void Promote(char[,] board, ref int rowW, ref int colW, ref int rowB, ref int colB)
        {
            int whiteToPromote = rowW - 0;
            int blackToPromote = 7 - rowB;

            int winRow = 0;
            int winCol = 0;

            string chessPosition = "";

            if (whiteToPromote <= blackToPromote)
            {
                winRow = board.GetLength(1) - 1;
                winCol = colW;

                chessPosition = GetPosition(winRow, winCol);

                Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessPosition}.");
            }
            else
            {
                winRow = 0;
                winCol = colB;

                chessPosition = GetPosition(winRow, winCol);
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessPosition}.");
            }
        }

        private static string GetPosition(int winRow, int winCol)
        {
            char col = (char)(winCol + 97);
            int row = winRow + 1;

            return $"{col}{row}";
        }
    }
}
