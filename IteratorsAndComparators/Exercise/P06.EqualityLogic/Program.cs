using System;
using System.Collections.Generic;

namespace P06.EqualityLogic
{
    public class Program
    {
        static void Main()
        {
            HashSet<Person> hashSetPerson = new HashSet<Person>();
            SortedSet<Person> sortedSetPerson = new SortedSet<Person>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] personArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);

                hashSetPerson.Add(person);
                sortedSetPerson.Add(person);
            }

            Console.WriteLine(hashSetPerson.Count);
            Console.WriteLine(sortedSetPerson.Count);
        }
    }
}
