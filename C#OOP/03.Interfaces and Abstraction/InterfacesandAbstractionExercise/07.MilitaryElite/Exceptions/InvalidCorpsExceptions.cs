using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsExceptions : Exception
    {
        private const string MESSAGE = "Invalid corps!";
        public InvalidCorpsExceptions()
            : base(MESSAGE)
        {

        }
        public InvalidCorpsExceptions(string message)
            : base(message)
        {

        }
    }
}
