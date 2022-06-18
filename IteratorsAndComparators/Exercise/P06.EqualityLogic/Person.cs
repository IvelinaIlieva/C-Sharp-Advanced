using System;
using System.Collections.Generic;
using System.Text;

namespace P06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                return this.Age.CompareTo(other.Age);
            }
            return result;
        }

        public override bool Equals(object? obj)
        {
            Person other = obj as Person;
            if (other == null)
            {
                return false;
            }
            return this.Name.Equals(other.Name) && this.Age.Equals(other.Age);
        }

        public override int GetHashCode() => HashCode.Combine(this.Name, this.Age);
    }
}
