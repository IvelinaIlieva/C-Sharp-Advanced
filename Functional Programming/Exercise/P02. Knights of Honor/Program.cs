using System;
using System.Linq;

namespace P02._Knights_of_Honor
{
    internal class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split();
            Action<string> print = name => Console.WriteLine($"Sir {name}");
            names.ToList().ForEach(word => print(word));
        }
    }
}
