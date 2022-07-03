using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int taskToKill = int.Parse(Console.ReadLine());
            int currThread = 0;

            while (true)
            {
                int currTask = tasks.Peek();
                currThread = threads.Peek();

                if (currTask == taskToKill)
                {
                    break;
                }

                threads.Dequeue();

                if (currThread >= currTask)
                {
                    tasks.Pop();
                }
            }

            Console.WriteLine($"Thread with value {currThread} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
