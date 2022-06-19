using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;


        public List<Car> Participants
        {
            get => participants;
            set => participants = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public int Laps
        {
            get => laps;
            set => laps = value;
        }

        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public int MaxHorsePower
        {
            get => maxHorsePower;
            set => maxHorsePower = value;
        }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Participants = new List<Car>();
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }

        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (Participants.Any(c => c.LicensePlate == car.LicensePlate) == false
                && Capacity > Count
                && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (Participants.Any(c => c.LicensePlate == licensePlate))
            {
                Participants.Remove(Participants.First(c => c.LicensePlate == licensePlate));
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
