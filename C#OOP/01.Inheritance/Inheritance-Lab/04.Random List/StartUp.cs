using System;
using System.Linq;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rand = new RandomList() { "pesho", "gosho", "veso" };
            Console.WriteLine(rand.RandomString());
            Console.WriteLine(string.Join(" ", rand));
        }
    }
}
