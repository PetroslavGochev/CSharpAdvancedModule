using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < number; i++)
            {
                int text = int.Parse(Console.ReadLine());
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
