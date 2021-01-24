using MilitaryElite.Contacts;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string firstName,string lastName,int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public string FirstName { get; }

        public string LastName { get; }

        public int Id { get; }
        public override string ToString() => $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
       
    }
}
