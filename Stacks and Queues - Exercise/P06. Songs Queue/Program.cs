using System;
using System.Collections.Generic;

namespace P06._Songs_Queue
{
    internal class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmd.StartsWith("Add"))
                {
                    string song = cmd.Substring(4);
                    
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
