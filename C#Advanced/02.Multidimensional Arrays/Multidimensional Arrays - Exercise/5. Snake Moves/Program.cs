using System;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var data = Console.ReadLine();
            char[][] matrix = new char[input[0]][];
            int startIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = new char[input[1]];
                for (int col = 0; col < input[1]; col++)
                {
                    if(row % 2 == 0)
                    {
                        matrix[row][col] = data[startIndex];
                        startIndex++;
                    }
                    else if(row % 2 != 0)
                    {
                        matrix[row][col] = data[startIndex];
                        startIndex++;
                    }
                    if(startIndex == data.Length)
                    {
                        startIndex = 0;
                    }
                }
                if(row % 2 != 0)
                {
                    Array.Reverse(matrix[row]);
                }
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
      
    }
}

