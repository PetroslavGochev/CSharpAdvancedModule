using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            char[][] matrix = new char[number][];
            var command = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int coals = 0;
            List<int> coordinates = new List<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[row] = new char[matrix.GetLength(0)];
                for (int column = 0; column < matrix.GetLength(0); column++)
                {
                    if (data[column] == 'c')
                    {
                        coals++;
                    }
                    if(data[column] == 's')
                    {
                        coordinates.Add(row);
                        coordinates.Add(column);
                    }
                    matrix[row][column] = data[column];
                }
            }
            MinerDirection(matrix, command, coordinates,coals);
         }
        static void MinerDirection (char[][] matrix,string[] command,List<int> coordinates,int coals)
        {
            int row = coordinates[0];
            int col = coordinates[1];
            for (int i = 0; i < command.Length; i++)
            {
                var direction = command[i];
                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    return;
                }
                if (direction == "up")
                {
                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1][col] == 'c')
                        {
                            matrix[row - 1][col] = '*';
                            coals--;
                        }
                        else if (matrix[row - 1][col] == 'e')
                        {
                            Console.WriteLine($"Game over! ({row - 1}, {col})");
                            return;
                        }
                        row--;
                    }                  
                }
                else if (direction == "down")
                {
                    if (row + 1 < matrix.GetLength(0))
                    {
                        if (matrix[row + 1][col] == 'c')
                        {
                            matrix[row + 1][col] = '*';
                            coals--;
                        }
                        else if (matrix[row + 1][col] == 'e')
                        {
                            Console.WriteLine($"Game over! ({row + 1}, {col + 1})");
                            return;
                        }
                        row++;
                    }
                    
                }
                else if(direction == "left")
                {
                    if (col - 1 >= 0)
                    {
                        if (matrix[row][col - 1] == 'c')
                        {
                            matrix[row][col - 1] = '*';
                            coals--;
                        }
                        else if (matrix[row][col - 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({row}, {col - 1})");
                            return;
                        }
                        col--;
                    }
                }
                else if(direction == "right")
                {
                    if (col + 1 < matrix.GetLength(0))
                    {
                        if (matrix[row][col + 1] == 'c')
                        {
                            matrix[row][col + 1] = '*';
                            coals--;
                        }
                        else if (matrix[row][col + 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({row}, {col + 1})");
                            return;
                        }
                        col++;
                    }
                }
                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    return;
                }
            }
            Console.WriteLine($"{coals} coals left. ({row}, {col})");
        }
    }
}
