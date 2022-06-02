using System;
using System.Collections.Generic;
using System.Linq;

namespace P08._List_Of_Predicates
{
    internal class Program
    {
        static void Main()
        {
            int end = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                numbers.Add(i);
            }

            HashSet<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToHashSet();

            Divide divide = (num1, num2) => num1 % num2;

            foreach (var number in numbers)
            {
                int counter = 0;

                foreach (var divider in dividers)
                {
                    if (divide(number, divider) != 0)
                    {
                        break;
                    }
                    counter++;

                    if (counter == dividers.Count)
                    {
                        Console.Write(number + " ");
                    }
                }
            }
        }

        public delegate int Divide(int num1, int num2);
    }
}

