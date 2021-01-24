using PizzaCalories.Core;
using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            try
            {
                engine.Run();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
