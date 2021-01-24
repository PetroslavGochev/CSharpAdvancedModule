using System;

namespace _02.GenericBoxofInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                int integers = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>();
                box.value = integers;
                Console.WriteLine(box);
            }
        }
    }
}
