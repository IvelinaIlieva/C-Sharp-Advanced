using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.TheFightForGondor
{
    internal class Program
    {
        static void Main()
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> orcPower = new Stack<int>();

            for (int i = 0; i < waves; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                foreach (var item in input)
                {
                    orcPower.Push(item);
                }

                if ((i + 1) % 3 == 0)
                {
                    int addPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(addPlate);
                }

                while (plates.Count > 0 && orcPower.Count > 0)
                {
                    int currentPlate = plates.Dequeue();
                    int currentOrcPower = orcPower.Pop();

                    if (currentOrcPower > currentPlate)
                    {
                        currentOrcPower -= currentPlate;
                        orcPower.Push(currentOrcPower);
                    }
                    else if (currentOrcPower < currentPlate)
                    {
                        currentPlate -= currentOrcPower;

                        List<int> newQ = new List<int>(plates);
                        newQ.Insert(0, currentPlate);

                        plates = new Queue<int>(newQ);
                    }
                }

                if (plates.Count == 0) break;
            }


            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcPower)}");
            }
        }
    }
}
