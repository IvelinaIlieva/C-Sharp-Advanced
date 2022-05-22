using System;
using System.Collections.Generic;
using System.Linq;

namespace P12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int currBottle = bottles.Pop();
                int currCup = cups.Dequeue();

                if (currBottle < currCup)
                {
                    currCup -= currBottle;

                    List<int> currCupsList = new List<int>(cups);
                    
                    currCupsList.Insert(0, currCup);
                    
                    cups = new Queue<int>(currCupsList);
                }
                else if (currBottle > currCup)
                {
                    wastedWater += currBottle - currCup;
                }
            }

            Console.WriteLine(bottles.Count > 0 ? $"Bottles: {string.Join(" ", bottles)}" : $"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
