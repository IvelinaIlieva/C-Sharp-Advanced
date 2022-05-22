using System;
using System.Collections.Generic;

namespace P8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCarsToPass = int.Parse(Console.ReadLine());

            Queue<string> waitingCars = new Queue<string>();

            int passedCars = 0;

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                if (cmd == "green")
                {
                    for (int i = 0; i < countOfCarsToPass; i++)
                    {
                        if (waitingCars.Count>0)
                        {
                            Console.WriteLine($"{waitingCars.Dequeue()} passed!");
                            passedCars++;
                        }
                    }
                }
                else
                {
                    string car = cmd;
                    waitingCars.Enqueue(car);
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
