using System;
using System.Linq;

namespace P04._Add_VAT
{
    internal class Program
    {
        static void Main()
        {
            double[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(x => x * 1.20).ToArray();

            input.ToList().ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
