using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            char[,] matrix = new char[number, number];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = data[column];
                }
            }
            char symbol= char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if(symbol == matrix[row, column])
                    {
                        Console.WriteLine($"({row}, {column})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}
