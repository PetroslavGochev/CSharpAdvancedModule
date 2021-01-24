using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Age.CompareTo(other.Age);
        }
        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            return person.Age == this.Age && person.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
            Age.GetHashCode();

        }
    }
}
