using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int countToPush = input[0];
            int countToPop = input[1];
            int numToCheck = input[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < countToPush; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            if (queue.Count >= countToPop)
            {
                for (int i = 0; i < countToPop; i++)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (queue.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
