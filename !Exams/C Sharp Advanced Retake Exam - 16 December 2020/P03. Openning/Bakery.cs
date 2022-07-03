using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            this.Data = new List<Employee>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public List<Employee> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Data.Count;

        public void Add(Employee employee)
        {
            if (this.Capacity > this.Count)
            {
                this.Data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (this.Data.Any(e => e.Name == name))
            {
                Employee employee = this.Data.First(e => e.Name == name);
                this.Data.Remove(employee);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee() => this.Data.OrderByDescending(e => e.Age).First();
        public Employee GetEmployee(string name) => this.Data.First(e => e.Name == name);
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.Data)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
