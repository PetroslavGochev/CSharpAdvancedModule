using System;

namespace Selling
{
    class StartUp
    {
        private static int priceOfBakery = 50;

        private static decimal money = 0;
        private static int rowPosition = 0;
        private static int columnPosition = 0;
        private static int firstPillarRow = -1;
        private static int firstPillarColumn = -1;
        private static int secondPillarRow = -1;
        private static int secondPillarColumn = -1;
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            char[,] matrix = new char[numberOfRows, numberOfRows];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (data[column] == 'S')
                    {
                        rowPosition = row;
                        columnPosition = column;
                    }
                    if (data[column] == 'O' && firstPillarColumn < 0)
                    {
                        firstPillarRow = row;
                        firstPillarColumn = column;
                    }
                    if (data[column] == 'O' && firstPillarColumn >= 0)
                    {
                        secondPillarRow = row;
                        secondPillarColumn = column;
                    }
                    matrix[row, column] = data[column];
                }
            }
            try
            {
                while (money < priceOfBakery)
                {
                    string direction = Console.ReadLine();
                    if (direction == "down")
                    {
                        DownDirection(matrix);

                    }
                    else if (direction == "right")
                    {
                        RightDirection(matrix);
                    }
                    else if (direction == "left")
                    {
                        LefttDirection(matrix);
                    }
                    else if (direction == "up")
                    {
                        UpDirection(matrix);
                    }
                }
                Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            finally
            {
                Console.WriteLine($"Star power collected: {money}");
                PritnMatrix(matrix);
            }
        }
        private static void DownDirection(char[,] matrix)
        {
            matrix[rowPosition, columnPosition] = '-';
            if (matrix[rowPosition + 1, columnPosition] == '-')
            {
                matrix[rowPosition + 1, columnPosition] = 'S';
                rowPosition++;
            }
            else if (matrix[rowPosition + 1, columnPosition] == 'O')
            {
                matrix[rowPosition + 1, columnPosition] = '-';
                if (rowPosition + 1 == firstPillarRow && columnPosition == firstPillarColumn)
                {
                    matrix[secondPillarRow, secondPillarColumn] = 'S';
                    rowPosition = secondPillarRow;
                    columnPosition = secondPillarColumn;
                }
                else
                {
                    matrix[firstPillarRow, secondPillarColumn] = 'S';
                    rowPosition = firstPillarRow;
                    columnPosition = secondPillarColumn;
                }
            }
            else
            {
                money += decimal.Parse(matrix[rowPosition + 1, columnPosition].ToString());
                matrix[rowPosition + 1, columnPosition] = 'S';
                rowPosition++;
            }
        }
        private static void UpDirection(char[,] matrix)
        {
            matrix[rowPosition, columnPosition] = '-';
            if (matrix[rowPosition - 1, columnPosition] == '-')
            {
                matrix[rowPosition - 1, columnPosition] = 'S';
                rowPosition--;
            }
            else if (matrix[rowPosition - 1, columnPosition] == 'O')
            {
                matrix[rowPosition - 1, columnPosition] = '-';
                if (rowPosition - 1 == firstPillarRow && columnPosition == firstPillarColumn)
                {
                    matrix[secondPillarRow, secondPillarColumn] = 'S';
                    rowPosition = secondPillarRow;
                    columnPosition = secondPillarColumn;
                }
                else
                {
                    matrix[firstPillarRow, secondPillarColumn] = 'S';
                    rowPosition = firstPillarRow;
                    columnPosition = secondPillarColumn;
                }
            }
            else
            {
                money += decimal.Parse(matrix[rowPosition - 1, columnPosition].ToString());
                matrix[rowPosition - 1, columnPosition] = 'S';
                rowPosition--;
            }
        }
        private static void RightDirection(char[,] matrix)
        {
            matrix[rowPosition, columnPosition] = '-';
            if (matrix[rowPosition, columnPosition + 1] == '-')
            {
                matrix[rowPosition, columnPosition + 1] = 'S';
                columnPosition++;
            }
            else if (matrix[rowPosition, columnPosition + 1] == 'O')
            {
                matrix[rowPosition, columnPosition + 1] = '-';
                if (rowPosition == firstPillarRow && columnPosition + 1 == firstPillarColumn)
                {
                    matrix[secondPillarRow, secondPillarColumn] = 'S';
                    rowPosition = secondPillarRow;
                    columnPosition = secondPillarColumn;
                }
                else
                {
                    matrix[firstPillarRow, secondPillarColumn] = 'S';
                    rowPosition = firstPillarRow;
                    columnPosition = secondPillarColumn;
                }
            }
            else
            {
                money += decimal.Parse(matrix[rowPosition, columnPosition + 1].ToString());
                matrix[rowPosition, columnPosition + 1] = 'S';
                columnPosition++;
            }
        }
        private static void LefttDirection(char[,] matrix)
        {
            matrix[rowPosition, columnPosition] = '-';
            if (matrix[rowPosition, columnPosition - 1] == '-')
            {
                matrix[rowPosition, columnPosition - 1] = 'S';
                columnPosition--;
            }
            else if (matrix[rowPosition, columnPosition - 1] == 'O')
            {
                matrix[rowPosition, columnPosition - 1] = '-';
                if (rowPosition == firstPillarRow && columnPosition - 1 == firstPillarColumn)
                {
                    matrix[secondPillarRow, secondPillarColumn] = 'S';
                    rowPosition = secondPillarRow;
                    columnPosition = secondPillarColumn;
                }
                else
                {
                    matrix[firstPillarRow, secondPillarColumn] = 'S';
                    rowPosition = firstPillarRow;
                    columnPosition = secondPillarColumn;
                }
            }
            else
            {
                money += decimal.Parse(matrix[rowPosition, columnPosition - 1].ToString());
                matrix[rowPosition, columnPosition - 1] = 'S';
                columnPosition--;
            }
        }
        private static void PritnMatrix(char[,] matrix)
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