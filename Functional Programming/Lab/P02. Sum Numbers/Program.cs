using System;
using System.Linq;

namespace P02._Sum_Numbers
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(input.Length);
            Console.WriteLine(input.Sum());
        }
    }
}
