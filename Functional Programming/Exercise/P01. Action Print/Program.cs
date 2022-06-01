using System;
using System.Linq;

namespace P01._Action_Print
{
    internal class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split();

            Action<string> print = word => Console.WriteLine(word);

            words.ToList().ForEach(word => print(word));
        }
    }
}
