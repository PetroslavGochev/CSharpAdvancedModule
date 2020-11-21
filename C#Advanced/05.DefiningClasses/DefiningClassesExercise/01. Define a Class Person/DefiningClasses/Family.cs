using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{

    public class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }

        private List<Person> Members { get; set; }
       
        public void AddMember(Person member)
        {
            Members.Add(member);
        }
        public Person GetOldestMember(Family members)
        {
            var  age = members.Members.Select(x => x.Age).Max();
            var name = members.Members.Where(x => x.Age == age).Select(x => x.Name).ToList()[0];
            Person old = new Person(name,age);
            return old;
        }
    }
}
