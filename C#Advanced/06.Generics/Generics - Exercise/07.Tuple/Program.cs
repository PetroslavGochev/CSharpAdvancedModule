using System;
using System.Collections.Generic;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Tuple<string, string> first = new Tuple<string, string>(input[0] + " " + input[1], input[2]);
            Console.WriteLine(first);


            input = Console.ReadLine().Split();
            Tuple<string, int> second = new Tuple<string, int>(input[0], int.Parse(input[1]));
            Console.WriteLine(second);


            input = Console.ReadLine().Split();
            Tuple<int, double> third = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(third);
        }
    }
}
