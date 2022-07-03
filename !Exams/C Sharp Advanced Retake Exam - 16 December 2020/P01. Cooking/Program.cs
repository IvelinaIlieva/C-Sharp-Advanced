using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            SortedDictionary<string, int[]> foods = new SortedDictionary<string, int[]>()
            {
                {"Bread", new[] {25, 0}},
                {"Cake", new[] {50, 0}},
                {"Pastry", new[] {75, 0}},
                {"Fruit Pie", new[] {100, 0}}
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();

                int sum = currentLiquid + currentIngredient;

                bool isCooked = false;

                foreach (var food in foods)
                {
                    if (sum == food.Value[0])
                    {
                        food.Value[1]++;
                        isCooked = true;
                        continue;
                    }
                }

                if (!isCooked)
                {
                    ingredients.Push(currentIngredient + 3);
                }
            }

            Console.WriteLine(foods.Any(f => f.Value[1] == 0)
                ? "Ugh, what a pity! You didn't have enough materials to cook everything."
                : "Wohoo! You succeeded in cooking all the food!");

            Console.WriteLine(liquids.Count == 0
                ? "Liquids left: none"
                : $"Liquids left: {string.Join(", ", liquids)}");

            Console.WriteLine(ingredients.Count == 0
                ? "Ingredients left: none"
                : $"Ingredients left: {string.Join(", ", ingredients)}");

            foreach (var food in foods)
            {
                Console.WriteLine($"{food.Key}: {food.Value[1]}");
            }
        }
    }
}
