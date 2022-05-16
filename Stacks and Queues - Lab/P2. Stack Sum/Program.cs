using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace P2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numStack = new Stack<int>(input);

            string cmd;
            while ((cmd = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "add")
                {
                    int num1 = int.Parse(cmdArgs[1]);
                    int num2 = int.Parse(cmdArgs[2]);

                    numStack.Push(num1);
                    numStack.Push(num2);
                }
                else if (cmdType == "remove")
                {
                    int num = int.Parse(cmdArgs[1]);

                    if (numStack.Count >= num)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            numStack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {numStack.Sum()}");
        }
    }
}
