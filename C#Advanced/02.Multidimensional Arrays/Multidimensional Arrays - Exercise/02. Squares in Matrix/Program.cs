using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
           string[,] matrix = new string[input[0], input[1]];
            for (int row = 0; row < input[0]; row++)
            {
                var data = Console.ReadLine().Split();
                for (int column = 0; column < input[1]; column++)
                {
                    matrix[row, column] = data[column];
                }
            }
            int counter = 0;
            for (int row = 0; row < input[0] -1 ; row++)
            {
                for (int column = 0; column < input[1] - 1; column++)
                {
                    if (matrix[row,column] == matrix[row,column+1] && matrix[row+1,column] == matrix[row + 1, column + 1])
                    {
                        if(matrix[row, column] == matrix[row + 1, column])
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
