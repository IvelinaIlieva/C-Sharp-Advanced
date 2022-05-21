using System;
using System.Collections.Generic;

namespace P08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> openBrackets = new Stack<char>();

            bool balansed = false;

            foreach (char ch in input)
            {
                if (ch == '{' || ch == '[' || ch == '(')
                {
                    openBrackets.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (openBrackets.Count > 0)
                    {
                        char currOpenBracket = openBrackets.Pop();

                        if (currOpenBracket == '{' && ch == '}')
                        {
                            balansed = true;
                        }
                        else if (currOpenBracket == '[' && ch == ']')
                        {
                            balansed = true;
                        }
                        else if (currOpenBracket == '(' && ch == ')')
                        {
                            balansed = true;
                        }
                        else
                        {
                            balansed = false;
                            break;
                        }
                    }
                    else
                    {
                        balansed = false;
                        break;
                    }
                }
            }

            Console.WriteLine(balansed ? "YES" : "NO");
        }
    }
}
