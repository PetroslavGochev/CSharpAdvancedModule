using System;
using System.Collections.Generic;

namespace _07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 0;
            char[,] matrix = new char[number, number];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = data[column];
                }
            }
            if (number < 3)
            {
                Console.WriteLine(counter);
                return;
            }       
            while (true)
            {
                List<int> coord = new List<int>();
                GetIndex(matrix,coord);
                if(coord.Count == 0)
                {
                    break;
                }
                else
                {
                    int row = coord[0];
                    int col = coord[1];
                    matrix[row, col] = '0';
                    counter++;
                }
            }           
            Console.WriteLine(counter);

        }
        static void GetIndex(char[,] matrix,List<int> coord)
        {
            int maxHit = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int hit = 0;
                    if(matrix[row,col] != 'K')
                    {
                        continue;
                    }
                    if (row - 1 >= 0 && col - 2 >= 0)
                    {
                        if (matrix[row - 1, col - 2] == 'K')
                        {
                            hit++;
                        }
                    }
                    if (row - 1 >= 0 && col + 2 < matrix.GetLength(1))
                    {
                        if (matrix[row - 1, col + 2] == 'K')
                        {
                            hit++;
                        }
                    }
                    if (row - 2 >= 0 && col - 1 >= 0)
                    {
                        if (matrix[row - 2, col - 1] == 'K')
                        {
                            hit++;
                        }
                    }
                    if (row - 2 >= 0 && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row - 2, col + 1] == 'K')
                        {
                            hit++;
                        }
                    }
                    if (row + 1 < matrix.GetLength(0) && col - 2 >= 0)
                    {
                        if (matrix[row + 1, col - 2] == 'K')
                        {
                            hit++;
                        }
                    }
                    if (row + 1 < matrix.GetLength(0) && col + 2 < matrix.GetLength(1))
                    {
                        if (matrix[row + 1, col + 2] == 'K')
                        {
                            hit++;
                        }
                    }
                    if (row + 2 < matrix.GetLength(0) && col - 1 >= 0)
                    {
                        if (matrix[row + 2, col - 1] == 'K')
                        {
                            hit++;
                        }
                    }
                    if (row + 2 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row + 2, col + 1] == 'K')
                        {
                            hit++;
                        }
                    }
                    if(hit > maxHit)
                    {
                        coord.Clear();
                        maxHit = hit;
                        hit = 0;
                        coord.Add(row);
                        coord.Add(col);
                    }
                }           
            }
        }
    }
}

