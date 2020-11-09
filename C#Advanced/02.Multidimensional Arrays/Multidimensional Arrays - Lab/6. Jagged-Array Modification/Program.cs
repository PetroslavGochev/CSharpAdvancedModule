using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int[,] matrix = new int[number, number];
            for (int row = 0; row < number; row++)
            {
                var data = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int column = 0; column < number; column++)
                {
                    matrix[row, column] = data[column];
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();
                int row = int.Parse(data[1]);
                int column = int.Parse(data[2]);
                int value = int.Parse(data[3]);
                if (row >= matrix.GetLength(0) || row < 0 || column >= matrix.GetLength(1) || column < 0)
                {
                    Console.WriteLine($"Invalid coordinates");
                    continue;
                }
                if (data[0] == "Add")
                {
                    matrix[row, column] += value;
                }
                else if (data[0] == "Subtract")
                {
                    matrix[row, column] -= value;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }
                Console.WriteLine();
            }

        }
        }
    }

