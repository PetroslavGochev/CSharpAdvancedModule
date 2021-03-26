using System;
using ViceCity.IO.Contracts;

namespace ViceCity.IO.Models
{
    public class Writer : IWriter
    {
        public void Write(string line)
        {
            Console.Write(line);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
