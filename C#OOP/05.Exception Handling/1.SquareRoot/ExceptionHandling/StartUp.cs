using System;

namespace ExceptionHandling
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if(number < 0)
                {
                    throw new FormatException();
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
