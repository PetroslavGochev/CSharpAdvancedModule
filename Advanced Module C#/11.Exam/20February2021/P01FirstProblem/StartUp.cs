using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class Program
    {
        static void Main()
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> leftWarrior = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                Stack<int> trojanWarrior = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (trojanWarrior.Any() && plates.Any())
                {
                    int warrior = trojanWarrior.Pop();
                    int plate = plates.Peek();

                    if (warrior > plate)
                    {
                        plates.Dequeue();
                        warrior -= plate;

                        trojanWarrior.Push(warrior);
                    }
                    else if (warrior < plate)
                    {
                        plate -= warrior;
                        ChangeFirstElementFromQueue(plates, plate);
                    }
                    else if (warrior == plate)
                    {
                        plates.Dequeue();
                    }
                }

                if (plates.Count < 1)
                {
                    leftWarrior = trojanWarrior;
                    break;
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", leftWarrior)}");
            }
        }

        private static void ChangeFirstElementFromQueue(Queue<int> plates, int plate)
        {
            var list = plates.ToArray();
            list[0] = plate;
            plates.Clear();

            for (int j = 0; j < list.Length; j++)
            {
                plates.Enqueue(list[j]);
            }
        }
    }
}