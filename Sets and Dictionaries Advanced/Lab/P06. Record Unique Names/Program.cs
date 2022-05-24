using System;
using System.Collections.Generic;

namespace P06._Record_Unique_Names
{
    internal class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
