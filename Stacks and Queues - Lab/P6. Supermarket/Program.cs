using System;
using System.Collections.Generic;

namespace P6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> clients = new Queue<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                if (cmd == "Paid")
                {
                    while (clients.Count > 0)
                    {
                        Console.WriteLine(clients.Dequeue());
                    }
                }
                else
                {
                    string name = cmd;
                    clients.Enqueue(name);
                }
            }

            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}
