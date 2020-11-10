using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
             int row = int.Parse(number[0]);
            int col = int.Parse(number[1]);
            char[][] matrix = new char[row][];
            FillMatrix(matrix, col);
            string command = Console.ReadLine();
            string[] coordinates = GetCoordinates(matrix).Split();
            Action(matrix, coordinates, command,col);

        }
        static void FillMatrix(char[][] matrix,int col)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                matrix[row] = new char[col];
                for (int column = 0; column < col; column++)
                {
                    matrix[row][column] = data[column];
                }
            }
        }
        static string GetCoordinates(char[][] matrix)
        {
            string coordinates = string.Empty;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row].Contains('P'))
                {
                    coordinates = $"{row} {Array.IndexOf(matrix[row], 'P')}";
                    break;
                }
            }
            return coordinates;
        }
        static void Action(char[][]matrix,string[] coordinates,string command,int maxCol)
        {
            int row = int.Parse(coordinates[0]);
            int col = int.Parse(coordinates[1]);
            for (int i = 0; i < command.Length; i++)
            {
                char direction = command[i];
                bool isWin = false;
                if (direction == 'L')
                {
                    if(col - 1 >= 0 && matrix[row][col-1] != 'B')
                    {
                        matrix[row][col - 1] = 'P';
                        matrix[row][col] = '.';
                        col--;
                    }
                    else if(col - 1 < 0)
                    {
                        matrix[row][col] = '.';
                        isWin = true;
                    }
                    else if(matrix[row][col-1] == 'B')
                    {
                        col--;
                    }
                }
                else if (direction == 'R')
                {
                    if (col + 1 < maxCol && matrix[row][col + 1] != 'B')
                    {
                        matrix[row][col + 1] = 'P';
                        matrix[row][col] = '.';
                        col++;
                    }
                    else if(col + 1 >= maxCol)
                    {
                        matrix[row][col] = '.';
                        isWin = true;
                    }
                    else if (matrix[row][col + 1] == 'B')
                    {
                        col++;
                    }
                }
                else if (direction == 'U')
                {
                    if (row - 1 >= 0 && matrix[row-1][col] != 'B')
                    {
                        matrix[row-1][col] = 'P';
                        matrix[row][col] = '.';
                        row--;
                    }
                    else if(row - 1 < 0 )
                    {
                        matrix[row][col] = '.';
                        isWin = true;
                    }
                    else if (matrix[row-1][col] == 'B')
                    {
                        row--;
                    }
                }
                else if (direction == 'D')
                {
                    if (row + 1 < matrix.GetLength(0) && matrix[row + 1][col] != 'B')
                    {
                        matrix[row + 1][col] = 'P';
                        matrix[row][col] = '.';
                        row++;
                    }
                    else if (row + 1 >= matrix.GetLength(0))
                    {
                        matrix[row][col] = '.';
                        isWin = true;
                    }
                    else if (matrix[row+1][col] == 'B')
                    {
                        row++;
                    }
                }
                RabbitMove(matrix,maxCol);
                if (isWin)
                {
                    Console.WriteLine(Result(matrix));
                    Console.WriteLine($"won: {row} {col}");
                    return;
                }
                if(matrix[row][col] == 'B')
                {
                    Console.WriteLine(Result(matrix));
                    Console.WriteLine($"dead: {row} {col}");
                    return;
                }
            }
        }
        static void RabbitMove(char[][] matrix,int maxCol)
        {
           Queue<int> coord = new Queue<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < maxCol; col++)
                {
                    if(matrix[row][col] == 'B')
                    {
                        coord.Enqueue(row);
                        coord.Enqueue(col);
                    }
                }
            }
            while(coord.Count > 0)
            {
                int row = coord.Dequeue();
                int col = coord.Dequeue();
                if(row-1 >= 0)
                {
                    matrix[row - 1][col] = 'B'; 
                }
                if(row+1 < matrix.GetLength(0))
                {
                    matrix[row + 1][col] = 'B';
                }
                if(col+1 < maxCol)
                {
                    matrix[row][col + 1] = 'B';
                }
                if(col-1 >= 0)
                {
                    matrix[row][col - 1] = 'B';
                }
            }
        }
        static string Result(char[][] matrix)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in matrix)
            {
                result.AppendLine(string.Join("", item));
            }
            return result.ToString().Trim();
        }
    }
}
