using System;
using System.Numerics;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            long[][] matrix = new long[number][];
            for (int row = 0; row < number; row++)
            {
                matrix[row] = new long[row+1];
                matrix[row][0] = 1;
                matrix[row][matrix[row].Length - 1] = 1;
                for (int column = 0; column < row+1; column++)
                {
                    if (row > 1 && column < matrix[row].Length-2)
                    {
                        matrix[row][column+1] = matrix[row - 1][column] + matrix[row-1][column+1];
                    }
                    Console.Write($"{matrix[row][column]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
