using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheGardenProblem
{
    class StartUp
    {
        private static Dictionary<char, int> harvest = new Dictionary<char, int>()
        {
            {'C',0},
            {'P',0},
            {'L',0}
        };
        private static int moleCount = 0;
        private static int row;
        private static int col;
        private static string direction;
        private static char[][] matrix;
        
        static void Main(string[] args)
        {
            CreateMatrix();
            ReceiveCommandFromConsole();
            PrintMatrix();
            PrintHarvestAndHarmed();
        }

        private static void ReceiveCommandFromConsole()
        {
            string command = string.Empty;
            while((command = Console.ReadLine())!= "End of Harvest")
            {
                string[] dataArgs = command
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();
                row = int.Parse(dataArgs[1]);
                col = int.Parse(dataArgs[2]);
                try
                {             
                    if (dataArgs[0] == "Harvest")
                    {
                        Harvest();
                    }
                    else if (dataArgs[0] == "Mole")
                    {
                        direction = dataArgs[3];
                        Mole();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }             
            }
        }

        private static void Harvest()
        {
            if(matrix[row][col] != ' ')
            {
                harvest[matrix[row][col]]++;
                matrix[row][col] = ' ';
            }
        }

        private static void Mole()
        {
            while (true)
            {
                try
                {
                    if (matrix[row][col] != ' ')
                    {
                        moleCount++;
                        matrix[row][col] = ' ';
                    }
                    if (direction == "up")
                    {
                        row -= 2;
                    }
                    else if (direction == "down")
                    {
                        row += 2;
                    }
                    else if (direction == "left")
                    {
                        col -= 2;
                    }
                    else if (direction == "right")
                    {
                        col += 2;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
          
        }

        private static void CreateMatrix()
        {
            int numberOfRow = int.Parse(Console.ReadLine());
            matrix = new char[numberOfRow][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[row] = new char[data.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = data[col];
                }
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void PrintHarvestAndHarmed()
        {
            Console.WriteLine($"Carrots: {harvest['C']}");
            Console.WriteLine($"Potatoes: {harvest['P']}");
            Console.WriteLine($"Lettuce: {harvest['L']}");
            Console.WriteLine($"Harmed vegetables: {moleCount}");
        }
    }
}
