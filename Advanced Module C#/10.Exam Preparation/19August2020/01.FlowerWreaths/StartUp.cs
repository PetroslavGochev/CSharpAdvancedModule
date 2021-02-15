using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class StartUp
    {
        private const int WREATH_SUM = 15;
        private const int NEEDED_WREATH = 5;
        private static int NUMBER_OF_WREATH = 0;
        private static int TOTALSUM_OF_REST = 0;
        private static Stack<int> lillies = new Stack<int>();
        private static Queue<int> roses = new Queue<int>();
        static void Main(string[] args)
        {
            int[] listOfLillies = ReadArrayFromConsole();
            int[] listOfRoses = ReadArrayFromConsole();
            foreach (var l in listOfLillies)
            {
                lillies.Push(l);
            }
            foreach (var r in listOfRoses)
            {
                roses.Enqueue(r);
            }
            CraftFlowers();
            RestOfCollectFlowers();
            Console.WriteLine(ReturnResult());

        }
        private static int[] ReadArrayFromConsole() =>
            Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        private static void CraftFlowers()
        {
            while(lillies.Count != 0 && roses.Count != 0)
            {
                int sumOfFlowers = lillies.Pop() + roses.Dequeue();
                if (sumOfFlowers < WREATH_SUM)
                {
                    TOTALSUM_OF_REST += sumOfFlowers;
                    continue;
                }
                else if (sumOfFlowers > WREATH_SUM)
                {
                    while(sumOfFlowers > WREATH_SUM)
                    {
                        sumOfFlowers -= 2;
                    }               
                }
                if(sumOfFlowers == WREATH_SUM)
                {
                    NUMBER_OF_WREATH++;
                    continue;
                }
                TOTALSUM_OF_REST += sumOfFlowers;             
            }
        }

        private static void RestOfCollectFlowers() =>
            NUMBER_OF_WREATH += TOTALSUM_OF_REST / WREATH_SUM;

        private static string ReturnResult() =>
            NUMBER_OF_WREATH >= NEEDED_WREATH ?
            $"You made it, you are going to the competition with { NUMBER_OF_WREATH} wreaths!" :
            $"You didn't make it, you need {NEEDED_WREATH - NUMBER_OF_WREATH} wreaths more!";
        
    }
}
