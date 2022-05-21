using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Fashion_Boutique
{
    internal class Program
    {
        static void Main()
        {
            int[] clothesInBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(clothesInBox);

            int count = 0;
            int currClothesSum = 0;

            while (clothes.Count > 0)
            {
                currClothesSum += clothes.Peek();

                if (currClothesSum < capacity)
                {
                    clothes.Pop();
                }
                else if (currClothesSum == capacity)
                {
                    clothes.Pop();
                    count++;
                    currClothesSum = 0;
                }
                else if (currClothesSum > capacity)
                {
                    count ++;
                    currClothesSum = 0;
                }
            }

            if (currClothesSum > 0)
            {
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
