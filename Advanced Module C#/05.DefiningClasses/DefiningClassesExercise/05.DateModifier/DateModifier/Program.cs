using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            DateModifier firstDate = new DateModifier(first);
            DateModifier secondDate = new DateModifier(second);
            Console.WriteLine(DateModifier.Difference(first, second));
        }
    }
}
