using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.Employees.Count();

        public ICollection<Employee> Employees { get; set; }

        public void Add(Employee employee)
        {
            if(this.Employees.Count < this.Capacity)
            {
                this.Employees.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            foreach (var e in this.Employees)
            {
                if(e.Name == name)
                {
                    RemoveEmployee(e);
                    return true;
                }
            }
            return false;
           
        }
        private void RemoveEmployee(Employee employee) => this.Employees.Remove(employee);

        public Employee GetOldestEmployee()
        {
            int age = this.Employees.Max(x => x.Age);
            return this.Employees.Where(x => x.Age == age).FirstOrDefault();
        }

        public Employee GetEmployee(string name) => this.Employees.Where(x => x.Name == name).FirstOrDefault();


        public string Report()
        {
            StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var e in this.Employees)
            {
                sb.AppendLine(e.ToString());
            }
            return sb.ToString().TrimEnd();
        }



    }
}
