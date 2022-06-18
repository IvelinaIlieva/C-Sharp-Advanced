using System;
using System.Collections.Generic;
using System.Text;

namespace P05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }

        public string Town { get => town; set => town = value; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);

                if (result == 0)
                {
                    return this.Town.CompareTo(other.Town);
                }
            }
            return result;
        }
    }
}
