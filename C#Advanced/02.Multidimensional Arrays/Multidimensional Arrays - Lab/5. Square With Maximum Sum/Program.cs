using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
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
                var data = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = data[column];
                }
            }
            int maxSum = 0;
            int maxRow = -1;
            int maxCol = -1;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                
                for (int column = 0; column < matrix.GetLength(1)-1; column++)
                {
                   int sum = matrix[row, column] + matrix[row + 1,column] + matrix[row, column + 1]+ matrix[row + 1, column+1];
                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = column;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxRow,maxCol]} {matrix[maxRow,maxCol+1]}");
            Console.WriteLine($"{matrix[maxRow+1,maxCol]} {matrix[maxRow+1,maxCol+1]}");
            Console.WriteLine(maxSum);
        }
    }
}
