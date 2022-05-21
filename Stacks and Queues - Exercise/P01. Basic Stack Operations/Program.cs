using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            if (stack.Count >= countToPop)
            {
                for (int i = 0; i < countToPop; i++)
                {
                    stack.Pop();
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (stack.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
