using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[][] matrix = new string[input[0]][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                matrix[row] = new string[input[1]];
                for (int column = 0; column < input[1]; column++)
                {
                    matrix[row][column] = data[column];
                }
            }
            string command = string.Empty;
            while((command = Console.ReadLine()) != "END")
            {
                var data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(data[0] == "swap" && data.Length == 5)
                {
                    int row = int.Parse(data[1]);
                    int column = int.Parse(data[2]);
                    int rowSecond = int.Parse(data[3]);
                    int columnSecond = int.Parse(data[4]);
                    if(row>= 0 && row < input[0] && column>=0 && column < input[1]
                        && rowSecond >= 0 && rowSecond < input[0] && columnSecond >= 0 && columnSecond < input[1])
                    {
                        string temp = matrix[row][column];
                        matrix[row][column] = matrix[rowSecond][columnSecond];
                        matrix[rowSecond][columnSecond] = temp;
                        PrintMatrix(matrix);
                        continue;
                    }                
                }
                    Console.WriteLine("Invalid input!");              
            }
		}
        static void PrintMatrix(string[][] matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
