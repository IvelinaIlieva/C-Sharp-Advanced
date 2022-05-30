using System;
using System.Linq;

namespace P01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
