using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int row = 0; row < input[0]; row++)
            {
                var data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int column = 0; column < input[1]; column++)
                {
                    matrix[row, column] = data[column];
                }
            }
            int maxSum = int.MinValue;

            int maxRow = 0;
            int maxColumn = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {

                for (int column = 0; column < matrix.GetLength(1) - 2; column++)
                {
                    int sum = 0;
                    sum += matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2];
                    sum += matrix[row + 1, column] + matrix[row + 1, column + 1] + matrix[row + 1, column + 2];
                    sum += matrix[row + 2, column] + matrix[row + 2, column + 1] + matrix[row + 2, column + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxColumn = column;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            int lastRow = maxRow + 3;
            int lastColumn = maxColumn + 3;

            for (int row = maxRow; row < lastRow; row++)
            {
                for (int column = maxColumn; column < lastColumn; column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
