using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.CustomComparator
{
    public class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Comparer<int> comparer = Comparer<int>.Create((x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return x.CompareTo(y);
                }
            });

            Array.Sort(input, comparer);
            //Array.Sort(input, new CustomComparator(input));

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
