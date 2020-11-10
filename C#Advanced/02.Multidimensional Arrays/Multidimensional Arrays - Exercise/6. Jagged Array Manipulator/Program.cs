using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double[][] matrix = new double[number][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = new double[data.Length];
                for (int column = 0; column < data.Length; column++)
                {
                    matrix[row][column] = data[column];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int column = 0; column < matrix[row].Length; column++)
                    {
                        matrix[row][column] *= 2;
                        matrix[row + 1][column] *= 2;
                    }
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }
            string command = string.Empty;
            while((command = Console.ReadLine()) != "End")
            {
                var input = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(input[1]);
                int column = int.Parse(input[2]);
                if(input[0] == "Add")
                { 
                    if(row>=0 && row < matrix.GetLength(0))
                    {
                        if(matrix[row].Length > column && column >= 0)
                        {
                            matrix[row][column] += int.Parse(input[3]);
                        }
                    }
                }
                else if (input[0] == "Subtract")
                {
                    if (row >= 0 && row < matrix.GetLength(0))
                    {
                        if (matrix[row].Length > column && column >= 0)
                        {
                            matrix[row][column] -= int.Parse(input[3]);
                        }
                    }
                }
            }
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }
    }
}
