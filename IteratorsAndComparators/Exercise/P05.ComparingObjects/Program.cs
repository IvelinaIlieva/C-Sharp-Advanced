using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    public class Program
    {
        static void Main()
        {
            List<Person> personList = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                string town = personArgs[2];

                personList.Add(new Person(name, age, town));
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            int matches = 0;
            int notMatch = 0;

            foreach (var person in personList)
            {
                int result = personList[index].CompareTo(person);

                if (result == 0)
                {
                    matches++;
                }
                else
                {
                    notMatch++;
                }
            }

            Console.WriteLine(matches == 1 ? "No matches" : $"{matches} {notMatch} {personList.Count}");
        }
    }
}
