using System;

namespace _01.GenericBoxofString
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string text = Console.ReadLine();
                Box<string> box = new Box<string>();
                box.value = text;
                Console.WriteLine(box);
            }
        }
    }
}
