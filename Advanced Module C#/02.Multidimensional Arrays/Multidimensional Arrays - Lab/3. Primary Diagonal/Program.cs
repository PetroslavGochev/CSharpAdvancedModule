using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[,] matrix = new int[number,number];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] data = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = data[column];
                }
            }
            int totalSum = 0;
            for (int i = 0; i < number; i++)
            {
                totalSum += matrix[i, i];
            }
            Console.WriteLine(totalSum);
        }
    }
}
