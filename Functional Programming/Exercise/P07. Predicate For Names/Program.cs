using System;
using System.Linq;

namespace P07._Predicate_For_Names
{
    internal class Program
    {
        static void Main()
        {
            int maxLength = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Predicate<string> inLengthLimit = name => name.Length <= maxLength;

            Console.WriteLine(string.Join("\n", names.Where(n => inLengthLimit(n))));
        }
    }
}
