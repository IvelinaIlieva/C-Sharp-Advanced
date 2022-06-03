using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<string> tiresInfoList = new List<string>();

            string cmdTires;
            while ((cmdTires = Console.ReadLine()) != "No more tires")
            {
                string tiresInfo = cmdTires;

                tiresInfoList.Add(tiresInfo);
            }

            List<string> enginesInfoList = new List<string>();

            string cmdEngine;
            while ((cmdEngine = Console.ReadLine()) != "Engines done")
            {
                string engineInfo = cmdEngine;
                enginesInfoList.Add(engineInfo);
            }

            List<Car> allCars = new List<Car>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car currentCar = GetCurrentCar(carInfo, enginesInfoList, tiresInfoList);

                allCars.Add(currentCar);
            }

            Predicate<Car> isSpecial = car => car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(t => t.Pressure) >= 9 && car.Tires.Sum(t => t.Pressure) <= 10;

            List<Car> specialCars = allCars.Where(c => isSpecial(c)).ToList();
            specialCars.ForEach(car => car.Drive(20));

            Print(specialCars);
        }

        private static void Print(List<Car> specialCars)
        {
            foreach (var car in specialCars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }

        private static Car GetCurrentCar(string[] carInfo, List<string> engines, List<string> tiresList)
        {
            string make = carInfo[0];
            string model = carInfo[1];
            int year = int.Parse(carInfo[2]);
            double fuelQuantity = double.Parse(carInfo[3]);
            double fuelConsumption = double.Parse(carInfo[4]);
            int engineIndex = int.Parse(carInfo[5]);
            int tireIndex = int.Parse(carInfo[6]);

            Engine engine = GetTheEngine(engineIndex, engines);

            Tire[] tires = GetTheTires(tireIndex, tiresList);

            Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

            return car;
        }

        private static Tire[] GetTheTires(int tireIndex, List<string> tiresList)
        {
            string[] tiresInfo = tiresList[tireIndex].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Tire[] tires = new Tire[4]
            {
                new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1])),
                new Tire(int.Parse(tiresInfo[2]), double.Parse(tiresInfo[3])),
                new Tire(int.Parse(tiresInfo[4]), double.Parse(tiresInfo[5])),
                new Tire(int.Parse(tiresInfo[6]), double.Parse(tiresInfo[7]))
            };

            return tires;
        }

        private static Engine GetTheEngine(int engineIndex, List<string> engines)
        {
            string engine = engines[engineIndex];
            int horsePower = int.Parse(engine.Split()[0]);
            double cubicCapacity = double.Parse(engine.Split()[1]);

            Engine currEngine = new Engine(horsePower, cubicCapacity);

            return currEngine;
        }
    }
}
