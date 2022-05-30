using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Filter_By_Age
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }


    internal class Program
    {
        static void Main()
        {
            List<Person> people = ReadPeople();

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);

            string format = Console.ReadLine();

            Action<Person> printer = CreatePrinter(format);

            PrintFilteredPeople(people, filter, printer);
        }

        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            foreach (var person in people.Where(p => filter(p) == true))
            {
                printer(person);
            }
        }

        private static Action<Person> CreatePrinter(string format)
        {
            if (format == "name")
            {
                return person => Console.WriteLine($"{person.Name}");
            }
            else if (format == "age")
            {
                return person => Console.WriteLine($"{person.Age}");
            }
            else if (format == "name age")
            {
                return person => Console.WriteLine($"{person.Name} - {person.Age}");
            }
            return null;
        }

        private static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if (condition == "younger")
            {
                return x => x.Age < ageThreshold;
            }
            else if (condition == "older")
            {
                return x => x.Age >= ageThreshold;
            }
            return null;
        }

        private static List<Person> ReadPeople()
        {
            int count = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                people.Add(new Person(name, age));
            }

            return people;
        }
    }
}
