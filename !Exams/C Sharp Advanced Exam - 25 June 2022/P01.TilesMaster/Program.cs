using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int[]> places = new Dictionary<string, int[]>
           {
               {"Countertop", new[] {60, 0}},
               {"Floor", new[] {0, 0}},
               {"Oven", new[] {50, 0}},
               {"Sink", new[] {40, 0}},
               {"Wall", new[] {70, 0}}
           };

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currentWhite = whiteTiles.Pop();
                int currentGrey = greyTiles.Dequeue();

                if (currentWhite == currentGrey)
                {
                    int sum = currentWhite + currentGrey;
                    
                    if (places.Any(p => p.Value[0] == sum))
                    {
                        places.First(p => p.Value[0] == sum).Value[1]++;
                    }
                    else
                    {
                        places["Floor"][1]++;
                    }
                }
                else
                {
                    whiteTiles.Push(currentWhite / 2);
                    greyTiles.Enqueue(currentGrey);
                }
            }

            Console.WriteLine(whiteTiles.Count == 0
                ? "White tiles left: none"
                : $"White tiles left: {string.Join(", ", whiteTiles)}");

            Console.WriteLine(greyTiles.Count == 0
                ? "Grey tiles left: none"
                : $"Grey tiles left: {string.Join(", ", greyTiles)}");

            foreach (var place in places.OrderByDescending(p => p.Value[1]).ThenBy(p => p.Key))
            {
                if (place.Value[1]>0)
                {
                    Console.WriteLine($"{place.Key}: {place.Value[1]}");
                }
            }
        }
    }
}
