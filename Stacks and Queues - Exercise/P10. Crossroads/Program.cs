using System;
using System.Collections.Generic;


namespace P10._Crossroads
{
    internal class Program
    {
        static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int countOfPassedCars = 0;

            Queue<string> cars = new Queue<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                if (cmd == "green")
                {
                    int greenSec = greenLight;

                    while (cars.Count > 0 && greenSec > 0)
                    {
                        string currCar = cars.Peek();

                        if (currCar.Length <= greenSec)
                        {
                            cars.Dequeue();
                            countOfPassedCars++;
                            greenSec -= currCar.Length;
                        }
                        else
                        {
                            if (currCar.Length <= greenSec + freeWindow)
                            {
                                cars.Dequeue();
                                countOfPassedCars++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");
                                char currChar = (char)currCar.ToCharArray().GetValue(greenSec + freeWindow);
                                Console.WriteLine($"{currCar} was hit at {currChar}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    string car = cmd;
                    cars.Enqueue(car);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countOfPassedCars} total cars passed the crossroads.");
        }
    }
}
