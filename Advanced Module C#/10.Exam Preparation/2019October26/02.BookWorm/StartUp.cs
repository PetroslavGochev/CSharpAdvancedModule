using System;
using System.Text;

namespace _02.BookWorm
{
    class StartUp
    {
        private static StringBuilder initialString = new StringBuilder();
        private static char[,] matrix;
        private static int playerRow = 0;
        private static int playerCol = 0;
        static void Main(string[] args)
        {
            initialString.Append(Console.ReadLine());
            CreateMatrix();
            ReceiveCommandFromConsole();
            Console.WriteLine(initialString);
            PrintMatrix();
        }
        private static void ReceiveCommandFromConsole()
        {
            string command = string.Empty;
            while((command = Console.ReadLine()) != "end")
            {
                try
                {
                    matrix[playerRow, playerCol] = '-';
                    if(command == "down")
                    {
                        char check = matrix[playerRow + 1, playerCol];
                        playerRow++;
                    }
                    else if(command == "up")
                    {
                        char check = matrix[playerRow - 1, playerCol];
                        playerRow--;
                    }
                    else if(command == "left")
                    {
                        char check = matrix[playerRow , playerCol - 1];
                        playerCol--;
                    }
                    else if(command == "right")
                    {
                        char check = matrix[playerRow , playerCol + 1];
                        playerCol++;
                    }
                    Direction();
                }
                catch (IndexOutOfRangeException)
                {
                    initialString.Remove(initialString.Length - 1, 1);                  
                }
                matrix[playerRow, playerCol] = 'P';
            }
        }
        private static void Direction()
        {
            if(matrix[playerRow,playerCol] != '-')
            {
                initialString.Append(matrix[playerRow, playerCol]);
            }
        }
        private static void CreateMatrix()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            matrix = new char[numberOfRows,numberOfRows];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(data[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    matrix[row, col] = data[col];
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
