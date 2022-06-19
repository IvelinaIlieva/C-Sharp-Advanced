using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> meals = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int wastedFood = 0;

            while (guests.Count > 0 && meals.Count > 0)
            {
                int currentGuest = guests.Dequeue();
                int currentMeal = meals.Pop();

                if (currentMeal >= currentGuest)
                {
                    wastedFood += currentMeal - currentGuest;
                }
                else
                {
                    currentGuest -= currentMeal;

                    while (currentGuest > 0)
                    {
                        currentMeal = meals.Pop();

                        if (currentMeal >= currentGuest)
                        {
                            wastedFood += currentMeal - currentGuest;
                        }
                        currentGuest -= currentMeal;
                    }
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ', meals)}");
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
