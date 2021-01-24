using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration.Contract
{
    public interface IBirthday
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
