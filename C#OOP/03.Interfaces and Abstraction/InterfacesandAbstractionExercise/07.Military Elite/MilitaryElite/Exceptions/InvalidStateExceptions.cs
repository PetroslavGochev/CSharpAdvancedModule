using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateExceptions : Exception
    {
        private const string MESSAGE = "Invalid mission state!";
        public InvalidStateExceptions()
            :base(MESSAGE)
        {

        }
        public InvalidStateExceptions(string message)
            :base(message)
        {

        }
    }
}
