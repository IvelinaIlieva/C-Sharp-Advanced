using System;
using System.Collections.Concurrent;
using System.Collections.Generic;


namespace P07._Truck_Tour
{
    internal class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            Queue<string> pompInfo = new Queue<string>();

            for (int i = 0; i < count; i++)
            {
                pompInfo.Enqueue(Console.ReadLine());
            }

            int startPosition = 0;

            while (true)
            {
                bool isCorrect = true;
                long currPetrol = 0;

                foreach (string pomp in pompInfo)
                {

                    int petrol = int.Parse(pomp.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
                    int distance = int.Parse(pomp.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

                    if (distance > petrol + currPetrol)
                    {
                        pompInfo.Enqueue(pompInfo.Dequeue()); 
                        startPosition++;
                        isCorrect = false;
                        break;
                    }

                    currPetrol += petrol - distance;
                }

                if (isCorrect)
                {
                    Console.WriteLine(startPosition);
                    break;
                }
            }
        }
    }
}
