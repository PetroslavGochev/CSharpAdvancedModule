using System;
using System.Linq;

namespace _02.Garden
{
    class StartUp
    {
        private const string INVALID_COORDINATES = "Invalid coordinates.";
        private const string COMMAND = "Bloom Bloom Plow";
        private static int[,] matrix;
        private static int row = 0;
        private static int column = 0;
        static void Main(string[] args)
        {
            ReceiveCoordAndCreateMatrix();
            ReceiveCoordForFlowers();
            PrintMatrix();
        }
        private static void PrintMatrix()
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[rows, col]} ");
                }
                Console.WriteLine();
            }
        }
        private static void ReceiveCoordAndCreateMatrix()
        {
            int[] coordArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            matrix = new int[coordArgs[0], coordArgs[1]];
        }

        private static void ReceiveCoordForFlowers()
        {
            string data = string.Empty;
            while ((data = Console.ReadLine()) != COMMAND)
            {
                try
                {
                    int[] coord = data
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                    row = coord[0];
                    column = coord[1];
                    int check = matrix[row, column];
                    PlantedFlowers();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine(INVALID_COORDINATES);
                }
            }
        }
        private static void PlantedFlowers()
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(rows == row || col == column)
                    {
                        matrix[rows, col]++;
                    }
                }
            }
        }
    }
}