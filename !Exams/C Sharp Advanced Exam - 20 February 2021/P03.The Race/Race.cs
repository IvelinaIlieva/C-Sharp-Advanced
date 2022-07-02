using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public List<Racer> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Race(string name, int capacity)
        {
            Data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }
        public int Count => Data.Count;

        public void Add(Racer Racer)
        {
            if (Count < Capacity)
            {
                Data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            if (Data.Any(r => r.Name == name))
            {
                Racer racer = Data.First(r => r.Name == name);
                return Data.Remove(racer);
            }
            return false;
        }

        public Racer GetOldestRacer() => Data.OrderByDescending(r => r.Age).First();
        public Racer GetRacer(string name) => Data.First(r => r.Name == name);
        public Racer GetFastestRacer() => Data.OrderByDescending(r => r.Car.Speed).First();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in Data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
