using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupInput = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .Reverse()
                  .ToArray();
            int[] bottleInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int waters = 0;
            Stack<int> cup = new Stack<int>(cupInput);
            Stack<int> bottle = new Stack<int>(bottleInput);
            while(cup.Count > 0 && bottle.Count > 0)
            {
                if(cup.Peek() <= bottle.Peek())
                {
                    waters += bottle.Pop() - cup.Pop();
                }
                else
                {
                    cup.Push(cup.Pop() - bottle.Pop());
                }
            }
            if(cup.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottle)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cup)}");
            }
            Console.WriteLine($"Wasted litters of water: {waters}");
        }
    }
}
