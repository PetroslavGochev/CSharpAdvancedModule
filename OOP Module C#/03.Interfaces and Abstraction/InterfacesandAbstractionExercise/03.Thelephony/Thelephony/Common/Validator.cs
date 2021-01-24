using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thelephony.Common
{
    public static class Validator
    {
        public const string INVALID_NUMBER = "Invalid number!";
        public static bool IsNumberIsValid(string number) => number.All(Char.IsDigit);
        public static bool IsUrlIsValid(string url) => !url.Any(char.IsDigit);
    }
}
