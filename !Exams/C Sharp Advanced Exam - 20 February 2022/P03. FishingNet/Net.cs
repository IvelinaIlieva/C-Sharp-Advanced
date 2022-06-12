using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; private set; }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count => Fish.Count;
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " " || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Capacity == 0)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            Capacity--;

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (Fish.Any(fish => fish.Weight == weight))
            {
                Fish fish = Fish.First(fish => fish.Weight == weight);
                return Fish.Remove(fish);
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(fish => fish.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(fish => fish.Weight).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in Fish.OrderByDescending(fish => fish.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
