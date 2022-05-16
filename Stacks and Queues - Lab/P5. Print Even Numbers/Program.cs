using System;
using System.Collections.Generic;
using System.Linq;

namespace P5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> inputQueue = new Queue<int>(input);

            List<int> evenNum = new List<int>();

            while (inputQueue.Count > 0)
            {
                int currNum = inputQueue.Dequeue();

                if (currNum % 2 == 0)
                {
                    evenNum.Add(currNum);
                }
            }

            Console.WriteLine(string.Join(", ", evenNum));
        }
    }
}
