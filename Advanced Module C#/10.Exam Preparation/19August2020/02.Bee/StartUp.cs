using System;

namespace _02.Bee
{
    class StartUp
    {
        private const int NEEDED_POLLINATE = 5;
        private static int POLLINATE = 0;
        private static int row = 0;
        private static int column = 0;
        private static char[,] matrix;
        static void Main(string[] args)
        {
            ReadMatrixFromConsole(int.Parse(Console.ReadLine()));
            try
            {
                ReadCommand();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The bee got lost!");
            }
            finally
            {
                Console.WriteLine(IsPollinateEnough());
                PrintMatrix();
            }
        }
        private static string IsPollinateEnough()
            => POLLINATE >= NEEDED_POLLINATE ?
            $"Great job, the bee managed to pollinate {POLLINATE} flowers!" :
            $"The bee couldn't pollinate the flowers, she needed {NEEDED_POLLINATE - POLLINATE} flowers more";

        private static void ReadMatrixFromConsole(int numberOfMatrix)
        {
            matrix = new char[numberOfMatrix, numberOfMatrix];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var data = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[rows, col] = data[col];
                    if (data[col] == 'B')
                    {
                        row = rows;
                        column = col;
                    }
                }
            }
        }

        private static void ReadCommand()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                matrix[row, column] = '.';
                if (command == "down") DownDirection();
                else if (command == "up") UpDirection();
                else if (command == "left") LeftDirection();
                else if (command == "right") RightDirection();
            }
        }
        private static void DownDirection()
        {
            while (true)
            {
                row++;
                if (matrix[row, column] == 'f')
                {
                    POLLINATE++;
                }
                else if (matrix[row, column] == 'O')
                {
                    matrix[row, column] = '.';
                    continue;
                }
                matrix[row, column] = 'B';
                break;
            }
        }
        private static void UpDirection()
        {
            while (true)
            {
                row--;
                if (matrix[row, column] == 'f')
                {
                    POLLINATE++;
                }
                else if (matrix[row, column] == 'O')
                {
                    matrix[row, column] = '.';
                    continue;
                }
                matrix[row, column] = 'B';;
                break;
            }
        }
        private static void LeftDirection()
        {
            while (true)
            {
                column--;
                if (matrix[row , column] == 'f')
                {
                    POLLINATE++;
                }
                else if (matrix[row, column] == 'O')
                {
                    matrix[row, column] = '.';
                    continue;
                }
                matrix[row, column] = 'B';
                break;
            }
        }
        private static void RightDirection()
        {
            while (true)
            {
                column++;
                if (matrix[row, column] == 'f')
                {
                    POLLINATE++;
                }
                else if (matrix[row, column] == 'O')
                {
                    matrix[row, column] = '.';
                    continue;
                }
                matrix[row, column] = 'B';
                break;
            }
        }
        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}
