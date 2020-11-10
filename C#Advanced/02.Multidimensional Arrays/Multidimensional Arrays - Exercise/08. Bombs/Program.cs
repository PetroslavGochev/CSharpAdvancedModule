using System;
using System.Linq;
using System.Text;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[,] matrix = new int[number, number];
            FillMatrix(matrix);
            string[] bomb = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bomb(matrix, bomb);
            PrintResult(matrix);


        }
        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = data[column];
                }
            }
        }
        static void Bomb(int[,] matrix, string[] bombCoord)
        {
            for (int i = 0; i < bombCoord.Length; i++)
            {
                var coord = bombCoord[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (matrix[coord[0], coord[1]] <= 0)
                {
                    continue;
                }
                for (int row = coord[0] - 1; row <= coord[0] + 1; row++)
                {
                    for (int col = coord[1] - 1; col <= coord[1] + 1; col++)
                    {
                        if(row == coord[0] && col == coord[1])
                        {
                            continue;
                        }
                        if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                        {
                            if (matrix[row, col] > 0)
                            {
                                matrix[row, col] -= matrix[coord[0], coord[1]];
                            }
                        }
                    }
                }
                matrix[coord[0], coord[1]] = 0;
            }                
        }
        static void PrintResult(int[,] matrix)
        {
            StringBuilder result = new StringBuilder();
            int alive = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row,col] > 0)
                    {
                        alive++;
                        sum += matrix[row, col];
                    }
                }
            }
            result.AppendLine($"Alive cells: {alive}");
            result.AppendLine($"Sum: {sum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result.Append($"{matrix[row, col]} ");
                }
                result.AppendLine();
            }
            Console.WriteLine(result.ToString().Trim());
        }
    }

}

