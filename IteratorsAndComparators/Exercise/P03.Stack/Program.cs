using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Stack
{
    public class Program
    {
        static void Main()
        {
            MyStack<string> stack = new MyStack<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                if (cmd.StartsWith("Push"))
                {
                    stack.Push(cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(p=>p.Split(',').First()).ToArray());
                }
                else if (cmd.StartsWith("Pop"))
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
