using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Even_Times
{
    internal class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<int,int> numbers = new Dictionary<int,int>();

            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }

                numbers[num]++;
            }

            int searchedNum = numbers.First(n => n.Value % 2 == 0).Key;
            Console.WriteLine(searchedNum);
        }
    }
}
