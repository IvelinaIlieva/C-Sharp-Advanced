using System;
using System.Collections.Generic;

namespace P07._Parking_Lot
{
    internal class Program
    {
        static void Main()
        {
            HashSet<string> cars = new HashSet<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] parkInfo = cmd.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = parkInfo[0];
                string carNumber = parkInfo[1];

                switch (cmdType)
                {
                    case "IN":
                        cars.Add(carNumber);
                        break;
                    case "OUT":
                        cars.Remove(carNumber);
                        break;
                }
            }

            Console.WriteLine(cars.Count > 0 
                                            ? string.Join("\n", cars) 
                                            : "Parking Lot is Empty");
        }
    }
}
