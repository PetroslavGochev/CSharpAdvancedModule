using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SeashellTreasure
{
    class StartUp
    {
        private const string COLLECTION = "Collected seashells: {0} -> ";
        private const string STOLEN = "Stolen seashells: {0}";
        private const string FINISH = "Sunset";

        private static List<char> collect = new List<char>();
        private static List<char> stolen = new List<char>();
        private static char[][] matrix;
        private static string[] command;
        private static int row;
        private static int column;
        private static string direction;
        static void Main(string[] args)
        {
            CreateMatrix();
            ReceiveCommandFromConsole();
            PrintCollectionAndSteal();
            PrintMatrix();
        }
        private static void PrintCollectionAndSteal()
        {
            Console.Write(String.Format(COLLECTION, collect.Count));
            if(collect.Count > 0)
            {
                Console.WriteLine(string.Join(", ", collect));
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine(String.Format(STOLEN, stolen.Count));
        }
        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
        private static void CreateMatrix()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            matrix = new char[numberOfRows][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                matrix[row] = new char[data.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = char.Parse(data[col]);
                }
            }
        }

        private static void ReceiveCommandFromConsole()
        {
            string data = string.Empty;
            while ((data = Console.ReadLine()) != FINISH)
            {
                command = data
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
                row = int.Parse(command[1]);
                column = int.Parse(command[2]);
                try
                {
                    if (IsCommandCollect())
                    {
                        Collect();
                    }
                    else
                    {
                        direction = command[3];
                        Steal();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
               
            }
        }

        private static void Collect()
        {
            if (matrix[row][column] != '-')
            {
                collect.Add(matrix[row][column]);
                matrix[row][column] = '-';
            }
        }

        private static void Steal()
        {
            for (int i = 0; i <= 3; i++)
            {
                if (matrix[row][column] != '-')
                {
                    stolen.Add(matrix[row][column]);
                    matrix[row][column] = '-';
                }
                if (direction == "up")
                {
                    row--;
                }
                else if (direction == "down")
                {
                    row++;
                }
                else if (direction == "left")
                {
                    column--;
                }
                else if (direction == "right")
                {
                    column++;
                }
            }            
        }
        private static bool IsCommandCollect()
            => command[0] == "Collect";
    }
}
