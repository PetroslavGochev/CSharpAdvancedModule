using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            string data = Console.ReadLine();
            return data;
        }
    }
}
