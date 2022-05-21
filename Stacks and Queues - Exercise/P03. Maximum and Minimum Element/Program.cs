using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main()
        {
            int queries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                int[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int cmdType = cmd[0];

                switch (cmdType)
                {
                    case 1:
                        int numToPush = cmd[1];
                        stack.Push(numToPush);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine(stack.Max());
                        break;
                    case 4:
                        if (stack.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine(stack.Min());
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
