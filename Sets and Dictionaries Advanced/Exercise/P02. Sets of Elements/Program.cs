using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Sets_of_Elements
{
    internal class Program
    {
        static void Main()
        {
            int[] inputInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            HashSet<int> firstHashSet = new HashSet<int>();
            HashSet<int> secondHashSet = new HashSet<int>();

            for (int i = 0; i < inputInfo[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstHashSet.Add(num);
            }

            for (int i = 0; i < inputInfo[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondHashSet.Add(num);
            }

            firstHashSet.IntersectWith(secondHashSet);

            Console.WriteLine(string.Join(" ", firstHashSet));
        }
    }
}
