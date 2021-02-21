namespace TheRace
{
   public class Racer
    {
        public Racer(string name,int age,string country,Car car)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
            this.Car = car;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Country { get; set; }

        public Car Car { get; set; }

        public override string ToString()
        {
            return $"Racer: {this.Name}, {this.Age} ({this.Country})";
        }
    }
}
