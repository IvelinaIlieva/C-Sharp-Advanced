using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public Catalog(string name, int neededRenovators, string project)
        {
            Renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }
        public int Count => Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (NeededRenovators > Count)
            {
                if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                {
                    return "Invalid renovator's information.";
                }

                if (renovator.Rate>350)
                {
                    return "Invalid renovator's rate.";
                }

                Renovators.Add(renovator);

                return $"Successfully added {renovator.Name} to the catalog.";
            }

            return "Renovators are no more needed.";
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(r=>r.Name == name))
            {
                Renovators.RemoveAll(r => r.Name == name);
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
           return Renovators.RemoveAll(r => r.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.Any(r=>r.Name == name))
            {
                Renovator renovator = Renovators.First(r => r.Name == name);
                renovator.Hired = true;
            }

            return Renovators.FirstOrDefault(r => r.Name == name);
        }

        public List<Renovator> PayRenovators(int days) => Renovators.FindAll(r => r.Days >= days);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in Renovators.Where(r=>r.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
