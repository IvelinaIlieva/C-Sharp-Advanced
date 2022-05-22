using System;
using System.Data;
using System.Linq;

namespace P6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] colsItem = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = new int[colsItem.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = colsItem[col];
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string cmdType = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                int cmdRow = int.Parse(cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                int cmdCol = int.Parse(cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2]);
                int number = int.Parse(cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[3]);

                if (!IsIndexValid(jaggedArray, cmdRow, cmdCol))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (cmdType == "Add")
                {
                    jaggedArray[cmdRow][cmdCol] += number;
                }
                else if (cmdType == "Subtract")
                {
                    jaggedArray[cmdRow][cmdCol] -= number;
                }
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            
        }

        private static bool IsIndexValid(int[][] jaggedArray, int row, int col)
        {
            if (row < 0 || col < 0 || jaggedArray.Length <= row || jaggedArray[row].Length <= col)
            {
                return false;
            }

            return true;
        }
    }
}
