using System;
using System.Collections.Generic;

namespace P05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> cities = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 1; i <= count; i++)
            {
                string[] cityInfo = Console.ReadLine().Split();

                string continent = cityInfo[0];
                string country = cityInfo[1];
                string city = cityInfo[2];

                if (!cities.ContainsKey(continent))
                {
                    cities[continent] = new Dictionary<string, List<string>>();
                }

                if (!cities[continent].ContainsKey(country))
                {
                    cities[continent][country] = new List<string>();
                }

                cities[continent][country].Add(city);
            }

            foreach (string continent in cities.Keys)
            {
                Console.WriteLine($"{continent}:");

                foreach (var (country, cityList) in cities[continent])
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", cityList)}");
                }
            }
        }
    }
}
