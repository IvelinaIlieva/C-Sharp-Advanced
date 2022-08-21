namespace Parking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Data = new List<Car>();
        }
        public List<Car> Data { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                Data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = Data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (car != null)
            {
                Data.Remove(car);
                return true;
            }
            return false;
        }

        public Car GetLatestCar() 
            => Data.OrderByDescending(c=>c.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model) 
            => Data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (Car car in Data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
