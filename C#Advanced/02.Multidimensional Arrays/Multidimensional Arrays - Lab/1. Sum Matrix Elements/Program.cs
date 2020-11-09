using System;
using System.Dynamic;
using System.Linq;

namespace _1._Sum_Matrix_Elements
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
            int totalSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] data = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                totalSum += data.Sum();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row,column] = data[column];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(totalSum);
            
        }
    }
}
