using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int claimedSum = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int currentFirstBoxItem = firstBox.Peek();
                int currentSecondBoxItem = secondBox.Pop();
                int currentSum = currentFirstBoxItem + currentSecondBoxItem;

                if (currentSum % 2 == 0)
                {
                    claimedSum += currentSum;
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(currentSecondBoxItem);
                }
            }

            Console.WriteLine(firstBox.Count == 0 ? "First lootbox is empty" : "Second lootbox is empty");

            Console.WriteLine(claimedSum>=100 ? $"Your loot was epic! Value: {claimedSum}" : $"Your loot was poor... Value: {claimedSum}");
        }
    }
}
