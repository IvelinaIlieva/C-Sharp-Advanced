using System;
using System.Collections.Generic;
using System.Linq;

namespace P3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            Stack<string> inputStack = new Stack<string>(input);

            int sum = int.Parse(inputStack.Pop());

            while (inputStack.Count > 0)
            {
                string currStr = inputStack.Pop();

                if (currStr == "+")
                {
                    sum += int.Parse(inputStack.Pop());
                }
                else if (currStr == "-")
                {
                    sum -= int.Parse(inputStack.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
