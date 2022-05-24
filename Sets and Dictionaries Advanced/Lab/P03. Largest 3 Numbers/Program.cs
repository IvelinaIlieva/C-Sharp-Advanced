using System;
using System.Linq;

namespace P03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(n=>n)
                .ToArray();

            int counter = 0;

            counter = input.Length < 3 
                ? input.Length 
                : 3;

            Console.WriteLine(string.Join(" ", input.Take(counter)));
        }
    }
}
