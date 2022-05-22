using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace P09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            Stack<string> currWord = new Stack<string>();
            currWord.Push(sb.ToString());

            for (int i = 0; i < count; i++)
            {
                string cmd = Console.ReadLine();

                int cmdType = int.Parse(cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);

                switch (cmdType)
                {
                    case 1:
                        string cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
                        sb.Append(cmdArgs);
                        currWord.Push(sb.ToString());
                        break;

                    case 2:
                        int countToRemove = int.Parse(cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                        sb.Remove(sb.Length - countToRemove, countToRemove);
                        currWord.Push(sb.ToString());
                        break;

                    case 3:
                        int index = int.Parse(cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                        string currChars = currWord.Peek();
                        char str = (char)currChars.ToCharArray().GetValue(index - 1);
                        Console.WriteLine(str);
                        break;

                    case 4:
                        currWord.Pop();
                        sb = new StringBuilder(currWord.Peek());
                        break;
                }
            }
        }
    }
}
