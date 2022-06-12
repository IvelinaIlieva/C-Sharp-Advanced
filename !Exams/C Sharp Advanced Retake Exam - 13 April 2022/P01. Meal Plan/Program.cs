using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Meal_Plan
{
    internal class Program
    {
        static void Main()
        {
            string[] inputMeals = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] inputCalories = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<string> meals = new Queue<string>(inputMeals);
            Stack<int> dailyCalories = new Stack<int>(inputCalories);

            Dictionary<string, int> mealCalories = new Dictionary<string, int>
            {
                {"salad", 350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790}
            };

            int currDailyCalories = 0;

            while (meals.Count != 0 && dailyCalories.Count != 0)
            {
                int diff = currDailyCalories;
                currDailyCalories = dailyCalories.Peek() + diff;

                while (currDailyCalories > 0)
                {
                    if (meals.Count == 0)
                    {
                        dailyCalories.Pop();
                        dailyCalories.Push(currDailyCalories);
                        Console.WriteLine($"John had {inputMeals.Length} meals.");
                        Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
                        return;
                    }
                    string currMeal = meals.Dequeue();
                    currDailyCalories -= mealCalories[currMeal];
                }

                dailyCalories.Pop();
            }

            Console.WriteLine($"John ate enough, he had {inputMeals.Length - meals.Count} meals.");
            Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
        }
    }
}
