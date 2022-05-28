using System;
using System.Collections.Generic;

namespace P05._Count_Symbols
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<char,int> occurrences = new SortedDictionary<char,int>();

            foreach (char ch in input)
            {
                if (!occurrences.ContainsKey(ch))
                {
                    occurrences[ch] = 0;
                }
                occurrences[ch]++;
            }

            foreach (var (ch,time) in occurrences)
            {
                Console.WriteLine($"{ch}: {time} time/s");
            }
        }
    }
}
