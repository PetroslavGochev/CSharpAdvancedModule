using System;

namespace _06._Valid_Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person(string.Empty, "Todorov", -1); ;
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.WriteLine(aoore.Message);
            }
        }
    }
}
