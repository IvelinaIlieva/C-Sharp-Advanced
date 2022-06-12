using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => Drones.Count;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }

            if (Capacity == 0)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            Capacity--;
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);

            if (drone != default)
            {
                Capacity++;
                return Drones.Remove(drone);
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int counter = 0;

            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Brand == brand)
                {
                    counter++;
                    Drones.Remove(Drones[i]);
                    i--;
                }
            }
            Capacity += counter;
            return counter;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);

            if (drone != default)
            {
                drone.Available = false;
                return drone;
            }
            else
            {
                return null;
            }
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> newList = new List<Drone>();

            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Range >= range)
                {
                    Drones[i].Available = false;
                    newList.Add(Drones[i]);
                }
            }

            return newList;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in Drones.Where(drone => drone.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
