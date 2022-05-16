using System;
using System.Collections.Generic;

namespace P4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> bracketsStack = new Stack<int>();

            List<string> substrings = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracketsStack.Push(i);
                }
                else if (input[i] == ')')
                {
                    if (bracketsStack.Count > 0)
                    {
                        int startIndex = bracketsStack.Pop();
                        int endIndex = i;

                        string substring = input.Substring(startIndex, endIndex - startIndex + 1);
                        substrings.Add(substring);
                    }
                }
            }

            foreach (string substring in substrings)
            {
                Console.WriteLine(substring);
            }
        }
    }
}
