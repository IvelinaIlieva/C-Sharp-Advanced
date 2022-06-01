using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Channels;

namespace P05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                switch (cmd)
                {
                    case "add":
                        numbers = numbers.Select(x => x + 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x * 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => x - 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(' ', numbers));
                        break;
                }
            }
        }
    }
}
