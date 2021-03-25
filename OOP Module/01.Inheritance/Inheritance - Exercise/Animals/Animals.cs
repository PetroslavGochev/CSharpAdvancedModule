using System;
using System.Collections.Generic;
using System.Text;

namespace Animals

{
    public class Animals : IProduceSound
    {
        private string name;
        private int age;
        private string gender;
        public Animals(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (ValidateStringInput(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (ValidateStringInput(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (ValidateStringInput(value) || !ValidateGenderInput(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }
        private bool ValidateStringInput(string s) => string.IsNullOrWhiteSpace(s);

        private bool ValidateGenderInput(string s) => (s == "Female" ? true : false) || (s == "Male" ? true : false);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(ProduceSound());
            return sb.ToString();
        }
    }
}

