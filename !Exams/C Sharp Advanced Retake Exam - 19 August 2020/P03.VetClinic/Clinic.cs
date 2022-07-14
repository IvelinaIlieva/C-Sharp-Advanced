using System.Linq;

namespace VetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Clinic
    {
        public List<Pet> Data { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;

        public Clinic(int capacity)
        {
            Data = new List<Pet>();
            Capacity = capacity;
        }

        public void Add(Pet pet)
        {
            if (Capacity > Count)
            {
                Data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet petToRemove = Data.FirstOrDefault(p => p.Name == name);

            if (petToRemove != null)
            {
                Data.Remove(petToRemove);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            return Data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return Data.OrderByDescending(p => p.Age).First();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in Data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
