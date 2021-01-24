using MilitaryElite.Contacts;

namespace MilitaryElite.Models
{
    public class Private : Soldier,IPrivate
    {
        public Private(string firstName, string lastName, int id,decimal salary)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }
        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}";
        }
    }
}
