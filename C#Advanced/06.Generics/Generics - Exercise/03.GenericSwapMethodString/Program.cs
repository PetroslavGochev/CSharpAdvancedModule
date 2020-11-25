using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < number; i++)
            {
                string text = Console.ReadLine();
                box.list.Add(text);
            }
            var data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            box.GenericMethod(data[0], data[1]);
            Console.WriteLine(box);
        }
    }
}
