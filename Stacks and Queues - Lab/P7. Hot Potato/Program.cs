using System;
using System.Collections.Generic;

namespace P7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int hotTime = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(input);

            while (kids.Count > 1)
            {
                for (int i = 0; i < hotTime - 1; i++)
                {
                    string currKid = kids.Dequeue();
                    kids.Enqueue(currKid);
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
