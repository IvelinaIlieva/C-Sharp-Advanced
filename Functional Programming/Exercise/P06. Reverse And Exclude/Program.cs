using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            
            int num = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = number => number % num == 0;
            numbers.RemoveAll(isDivisible);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
