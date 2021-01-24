using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        public Person(string name,int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public string Name { get; set; }
        public  int Age { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"Name: {this.Name}, Age: {this.Age}");
            return str.ToString();
        }
    }
}
