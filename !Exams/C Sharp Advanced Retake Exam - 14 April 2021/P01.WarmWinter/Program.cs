using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.WarmWinter
{
    internal class Program
    {
        static void Main()
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Pop();
                int currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    int sum = currentHat + currentScarf;
                    sets.Add(sum);
                    
                    scarfs.Dequeue();
                }
                else if(currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    hats.Push(currentHat + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
