using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[][] matrix = new int[number][];
            for (int row = 0; row < number; row++)
            {
                var data = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();
                matrix[row] = new int[number];
                for (int column = 0; column < number; column++)
                {
                    matrix[row][column] = data[column];
                }
            }
            int lefSum = 0;
            int rightSUm = 0;
            for (int row = 0; row < number; row++)
            {
                lefSum += matrix[row][row];
                rightSUm += matrix[matrix[row].Length- 1- row][row];
            }
            Console.WriteLine(Math.Abs(lefSum - rightSUm));

        }
    }
}
