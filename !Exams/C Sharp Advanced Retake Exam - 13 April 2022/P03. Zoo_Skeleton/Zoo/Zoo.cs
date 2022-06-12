using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Capacity == 0)
            {
                return "The zoo is full.";
            }
            
            Animals.Add(animal);
            this.Capacity--;
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;

            for (var index = 0; index < Animals.Count; index++)
            {
                Animal animal = Animals[index];
                if (animal.Species == species)
                {
                    Animals.Remove(animal);
                    count++;
                    index--;
                }
            }

            Capacity += count;
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.FindAll(animal => animal.Diet == diet);
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.First(animal => animal.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.Count(animal => animal.Length >= minimumLength && animal.Length <= maximumLength);

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
