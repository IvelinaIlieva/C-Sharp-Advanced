using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Masterchef
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            SortedDictionary<string, int[]> dishes = new SortedDictionary<string, int[]>()
            {
                {"Dipping sauce", new[] {150, 0}},
                {"Green salad", new[] {250, 0}},
                {"Chocolate cake", new[] {300, 0}},
                {"Lobster", new[] {400, 0}},
            };

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                int currentFreshness = freshness.Pop();

                int freshLevel = currentIngredient * currentFreshness;

                bool isCooked = false;

                foreach (var dish in dishes)
                {
                    if (dish.Value[0] == freshLevel)
                    {
                        dish.Value[1]++;
                        isCooked = true;
                    }
                }

                if (!isCooked)
                {
                    currentIngredient += 5;
                    ingredients.Enqueue(currentIngredient);
                }
            }

            Console.WriteLine(dishes.Count(d => d.Value[1] > 0) >= 4
                ? $"Applause! The judges are fascinated by your dishes!"
                : $"You were voted off. Better luck next year.");

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes.Where(d => d.Value[1] > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value[1]}");
            }
        }
    }
}
