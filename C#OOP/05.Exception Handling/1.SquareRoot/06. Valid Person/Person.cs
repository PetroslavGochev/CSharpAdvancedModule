using System;

namespace _06._Valid_Person
{
    public class Person
    {
        private const string INVALID_FIRST_NAME = "The first name cannot be null or empty";
        private const string INVALID_LAST_NAME = "The last name cannot be null or empty";
        private const string INVALID_AGE = "Age should be in the range [0 . . . 120]";
        private const int MAXIMUM_AGE = 120;
        private const int MINIMUM_AGE = 0;
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName,string lastName,int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(INVALID_FIRST_NAME);
                }
                this.firstName = value;
            }
        }
        public string  LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(INVALID_LAST_NAME);
                }
                this.lastName = value;
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
                if (value < MINIMUM_AGE || value > MAXIMUM_AGE)
                {
                    throw new ArgumentOutOfRangeException(INVALID_AGE);
                }
                this.age = value;
            }
        }
    }
}
