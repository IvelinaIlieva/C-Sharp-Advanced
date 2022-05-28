using System;
using System.Collections.Generic;

namespace P06._Wardrobe
{
    internal class Program
    {
        static void Main()
        {
            int inputCount = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < inputCount; i++)
            {
                string[] colorInfo = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = colorInfo[0];
                string[] clothes = colorInfo[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (string cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color][cloth] = 0;
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] searchedDress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = searchedDress[0];
            string searchedCloth = searchedDress[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var (cloth, count) in color.Value)
                {
                    if (searchedColor == color.Key && searchedCloth == cloth)
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {cloth} - {count}");
                }
            }
        }
    }
}
