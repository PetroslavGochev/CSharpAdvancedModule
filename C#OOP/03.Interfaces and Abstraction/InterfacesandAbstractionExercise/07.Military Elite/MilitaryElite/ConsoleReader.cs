using MilitaryElite.IO.Contracts;
using System;

namespace MilitaryElite
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}