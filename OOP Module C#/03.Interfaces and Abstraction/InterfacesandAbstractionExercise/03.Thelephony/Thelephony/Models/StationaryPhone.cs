using System;
using System.Collections.Generic;
using System.Text;
using Thelephony.Contracts;
using Thelephony.Common;

namespace Thelephony.Models
{
    public class StationaryPhone : ICall
    {
        private const string MESSAGE = "Dialing... {0}";
        public void Calling(string number)
        {
            if (Validator.IsNumberIsValid(number))
            {
                Console.WriteLine(string.Format(MESSAGE, number));
            }
            else
            {
                Console.WriteLine(Validator.INVALID_NUMBER);
            }
        }
    }
}
