using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main()
        {
            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double,int> sheet = new Dictionary<double,int>();

            foreach (double num in input)
            {
                if (!sheet.ContainsKey(num))
                {
                    sheet[num] = 0;
                }

                sheet[num]++;
            }

            foreach (var (num,count) in sheet)
            {
                Console.WriteLine($"{num} - {count} times");
            }
        }
    }
}
