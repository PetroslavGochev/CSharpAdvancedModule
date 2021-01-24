using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster sm = new SoulMaster("Strawberry", 40);
            SoulMaster sm2 = new SoulMaster("MrHappY", 40);
            Console.WriteLine(sm);
            Console.WriteLine(sm2);
        }
    }
}