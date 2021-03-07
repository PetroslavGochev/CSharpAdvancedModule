using System;
using System.Linq;

namespace _02.TronRacers
{
    class StartUp
    {
        private static int firstRow;
        private static int firstCol;
        private static int secondRow;
        private static int secondCol;
        private static char[][] matrix;
        static void Main(string[] args)
        {
            CreateMatrix();
            ReceiveCommand();
        }

        private static void ReceiveCommand()
        {
            try
            {
                while (true)
                {
                    string[] command = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
                    string firstPlayer = command[0];
                    string secondPlayer = command[1];
                    PlayerAction('f', firstPlayer);
                    PlayerAction('s', secondPlayer);
                }
            }
            catch (IndexOutOfRangeException)
            {
                PrintMatrix();
            }


        }
        private static void PlayerAction(char player, string command)
        {
            if (command == "down")
            {
                if (player == 'f')
                {
                    firstRow = DownDirection(player, firstRow, firstCol);
                }
                else
                {
                    secondRow = DownDirection(player, secondRow, secondCol);
                }
            }
            else if (command == "up")
            {
                if (player == 'f')
                {
                    firstRow = UpDirection(player, firstRow, firstCol);
                }
                else
                {
                    secondRow = UpDirection(player, secondRow, secondCol);
                }
            }
            else if (command == "left")
            {
                if (player == 'f')
                {
                    firstCol = LeftDirection(player, firstRow, firstCol);
                }
                else
                {
                    secondCol = LeftDirection(player, secondRow, secondCol);
                }
            }
            else if (command == "right")
            {
                if (player == 'f')
                {
                    firstCol = RightDirection(player, firstRow, firstCol);
                }
                else
                {
                    secondCol = RightDirection(player, secondRow, secondCol);
                }
            }

        }
        private static int DownDirection(char player, int row, int col)
        {
            row++;
            if (IsOutOfTheRange(row, col))
            {
                row = 0;
            }
            if (matrix[row][col] == '*')
            {
                matrix[row][col] = player;
            }
            else
            {
                matrix[row][col] = 'x';
                matrix[-1][col] = 'E';
            }
            return row;
        }
        private static int UpDirection(char player, int row, int col)
        {
            row--;
            if (IsOutOfTheRange(row, col))
            {
                row = matrix.GetLength(0) - 1;
            }
            if (matrix[row][col] == '*')
            {
                matrix[row][col] = player;
            }
            else
            {
                matrix[row][col] = 'x';
                matrix[-1][col] = 'E';
            }
            return row;
        }
        private static int LeftDirection(char player, int row, int col)
        {
            col--;
            if (IsOutOfTheRange(row, col))
            {
                col = matrix[row].Length - 1;
            }
            if (matrix[row][col] == '*')
            {
                matrix[row][col] = player;
            }
            else
            {
                matrix[row][col] = 'x';
                matrix[-1][col] = 'E';
            }
            return col;
        }
        private static int RightDirection(char player, int row, int col)
        {
            col++;
            if (IsOutOfTheRange(row, col))
            {
                col = 0;
            }
            if (matrix[row][col] == '*')
            {
                matrix[row][col] = player;
            }
            else
            {
                matrix[row][col] = 'x';
                matrix[-1][col] = 'E';
            }
            return col;
        }

        private static bool IsOutOfTheRange(int row, int col)
            => row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix[row].Length;
        private static void CreateMatrix()
        {
            int numberOfRow = int.Parse(Console.ReadLine());
            matrix = new char[numberOfRow][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                matrix[row] = new char[data.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (data[col] == 'f')
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    else if (data[col] == 's')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                    matrix[row][col] = data[col];
                }
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
