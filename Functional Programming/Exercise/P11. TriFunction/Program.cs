using System;
using System.Collections.Generic;
using System.Linq;

namespace P11._TriFunction
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Predicate<string> sumOfChars = str => str.ToCharArray().Select(c=> (int) c).Sum() >= number;

            foreach (var name in names)
            {
                if (sumOfChars(name))
                {
                    Console.WriteLine(name);
                    break;
                }
            }

            
        }
    }
}
