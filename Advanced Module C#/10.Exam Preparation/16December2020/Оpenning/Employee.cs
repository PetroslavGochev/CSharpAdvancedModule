namespace BakeryOpenning
{
    public class Employee
    {

        public Employee(string name,int age,string country)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"Employee: {this.Name}, {this.Age} ({this.Country})";
        }
    }
}
