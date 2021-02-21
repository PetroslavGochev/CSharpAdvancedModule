namespace TheRace
{
   public  class Car
    {
        public Car(string name,int speed)
        {
            this.Name = name;
            this.Speed = speed;
        }
        public string Name { get; set; }
        public int Speed { get; set; }
    }
}
