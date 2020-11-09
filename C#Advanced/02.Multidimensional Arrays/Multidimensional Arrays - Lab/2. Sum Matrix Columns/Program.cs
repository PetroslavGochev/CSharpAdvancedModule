using System;
using System.Linq;
using System.Security.Cryptography;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = data[column];
                }
            }
           
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                int totalSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    totalSum += matrix[row, column];
                }
                Console.WriteLine(totalSum);
            }
        }
    }
}
