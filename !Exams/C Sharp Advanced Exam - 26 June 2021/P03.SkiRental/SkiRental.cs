using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        private string name;
        private int capacity;


        public List<Ski> Data
        {
            get => data;
            set => data = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public SkiRental(string name, int capacity)
        {
            this.Data = new List<Ski>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public int Count => Data.Count;

        public void Add(Ski ski)
        {
            if (Count < capacity)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (Data.Any(s => s.Manufacturer == manufacturer && s.Model == model))
            {
               Ski ski = Data.First(s => s.Manufacturer == manufacturer && s.Model == model);
               return Data.Remove(ski);
            }
            return false;
        }

        public Ski GetNewestSki() => Data.OrderByDescending(s => s.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model) =>
            Data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in Data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
