using System;
using System.Linq;

namespace P03._Custom_Min_Function
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNumber = num => numbers.Min();

            Console.WriteLine(minNumber(numbers));
        }
    }
}
