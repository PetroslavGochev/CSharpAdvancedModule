using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var newEq = new EqualityScale<int>(5,6);
            Console.WriteLine(newEq.AreEqual());
        }
    }
}
