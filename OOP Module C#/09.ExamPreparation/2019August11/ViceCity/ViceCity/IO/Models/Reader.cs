using System;
using ViceCity.IO.Contracts;

namespace ViceCity.IO.Models
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
