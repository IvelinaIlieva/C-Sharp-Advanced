namespace P01.Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            const int bombCasingDecreaseValue = 5;
            const int minBombsForPouch = 3;

            Queue<int> bombEffect = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, List<int>> bombs = new Dictionary<string, List<int>>
        {
        {"Datura Bombs", new List<int> {40, 0}},
        {"Cherry Bombs", new List<int> {60, 0}},
        {"Smoke Decoy Bombs", new List<int> {120, 0}}

        };

            bool isBombPouch = false;

            while (bombEffect.Count > 0 && bombCasings.Count > 0)
            {
                int currentBombEffect = bombEffect.Peek();
                int currentBombCasing = bombCasings.Pop();

                int currentSum = currentBombEffect + currentBombCasing;

                if (currentSum == bombs["Datura Bombs"][0])
                {
                    bombs["Datura Bombs"][1]++;
                }
                else if (currentSum == bombs["Cherry Bombs"][0])
                {
                    bombs["Cherry Bombs"][1]++;
                }
                else if (currentSum == bombs["Smoke Decoy Bombs"][0])
                {
                    bombs["Smoke Decoy Bombs"][1]++;
                }
                else
                {
                    currentBombCasing -= bombCasingDecreaseValue;
                    bombCasings.Push(currentBombCasing);
                    continue;
                }

                bombEffect.Dequeue();

                if (bombs["Datura Bombs"][1] >= minBombsForPouch && bombs["Cherry Bombs"][1] >= minBombsForPouch &&
                    bombs["Smoke Decoy Bombs"][1] >= minBombsForPouch)
                {
                    isBombPouch = true;
                    break;
                }
            }

            Console.WriteLine(isBombPouch
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");

            Console.WriteLine(bombEffect.Count == 0
                ? "Bomb Effects: empty"
                : $"Bomb Effects: {string.Join(", ", bombEffect)}");
            Console.WriteLine(bombCasings.Count == 0
                ? "Bomb Casings: empty"
                : $"Bomb Casings: {string.Join(", ", bombCasings)}");

            foreach (var bomb in bombs.OrderBy(b => b.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value[1]}");
            }
        }
    }
}
