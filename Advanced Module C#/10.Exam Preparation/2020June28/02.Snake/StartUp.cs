using System;

namespace _02.Snake
{
    class StartUp
    {
        private const int NEEDED_FOOD = 10;
        private const string GAME_OVER = "Game over!";
        private static int snakeRow = 0;
        private static int snakeCol = 0;
        private static int firstRow = -1;
        private static int firstCol = -1;
        private static int secondRow = -1;
        private static int secondCol = -1;
        private static char[,] matrix;
        private static int food = 0;
        static void Main(string[] args)
        {
            ReadAndCreateMatrix();
            try
            {
                ReceiveDirectionFromConsole();
                Console.WriteLine(ReturnResult());
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(GAME_OVER);              
            }
            finally
            {
                Console.WriteLine($"Food eaten: {food}");
                PrintMatrix();
            }
        }

        private static string ReturnResult()
        {
            if(food == NEEDED_FOOD)
            {
                return $"You won! You fed the snake.";
            }
            return GAME_OVER;
        }
        private static void ReadAndCreateMatrix()
        {
            int matrixArgs = int.Parse(Console.ReadLine());
            matrix = new char[matrixArgs, matrixArgs];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(data[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if(data[col] == 'B' && firstCol < 0)
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    else if(data[col] == 'B')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                    matrix[row, col] = data[col];
                }
            }
        }

        private static void ReceiveDirectionFromConsole()
        {
            while(food < NEEDED_FOOD)
            {
                string direction = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';
                if (direction == "down") DownDirection();
                else if (direction == "up") UpDirection();
                else if (direction == "left") LeftDirection();
                else if (direction == "right") RightDirection();
            }
        }
        private static void DownDirection()
        {
            snakeRow++;
            if(snakeRow == firstRow && snakeCol == firstCol)
            {
                snakeRow = secondRow;
                snakeCol = secondCol;
                matrix[firstRow, firstCol] = '.';
                matrix[snakeRow, snakeCol] = 'S';
            }
            else if(snakeRow == secondRow && snakeCol == secondCol)
            {
                snakeRow = firstRow;
                snakeCol = firstCol;
                matrix[secondRow, secondCol] = '.';
                matrix[snakeRow, snakeCol] = 'S';
            }
            else if(matrix[snakeRow,snakeCol] == '*')
            {
                food++;
                matrix[snakeRow, snakeCol] = 'S';
            }
            else
            {
                matrix[snakeRow, snakeCol] = 'S';
            }
        }

        private static void UpDirection()
        {
            snakeRow--;
            if (snakeRow == firstRow && snakeCol == firstCol)
            {
                snakeRow = secondRow;
                snakeCol = secondCol;
                matrix[firstRow, firstCol] = '.';
                matrix[snakeRow, snakeCol] = 'S';
            }
            else if (snakeRow == secondRow && snakeCol == secondCol)
            {
                snakeRow = firstRow;
                snakeCol = firstCol;
                matrix[secondRow, secondCol] = '.';
                matrix[snakeRow, snakeCol] = 'S';
            }
            else if (matrix[snakeRow, snakeCol] == '*')
            {
                food++;
                matrix[snakeRow, snakeCol] = 'S';
            }
            else
            {
                matrix[snakeRow, snakeCol] = 'S';
            }
        }
        private static void LeftDirection()
        {
            snakeCol--;
            if (snakeRow == firstRow && snakeCol == firstCol)
            {
                snakeRow = secondRow;
                snakeCol = secondCol;
                matrix[firstRow, firstCol] = '.';
                matrix[snakeRow, snakeCol] = 'S';
            }
            else if (snakeRow == secondRow && snakeCol == secondCol)
            {
                snakeRow = firstRow;
                snakeCol = firstCol;
                matrix[secondRow, secondCol] = '.';
                matrix[snakeRow, snakeCol] = 'S';
            }
            else if (matrix[snakeRow, snakeCol] == '*')
            {
                food++;
                matrix[snakeRow, snakeCol] = 'S';
            }
            else
            {
                matrix[snakeRow, snakeCol] = 'S';
            }
        }
        private static void RightDirection()
        {
            snakeCol++;
            if (snakeRow == firstRow && snakeCol == firstCol)
            {
                snakeRow = secondRow;
                snakeCol = secondCol;
                matrix[firstRow, firstCol] = '.';
                matrix[snakeRow, snakeCol] = 'S';
            }
            else if (snakeRow == secondRow && snakeCol == secondCol)
            {
                snakeRow = firstRow;
                snakeCol = firstCol;
                matrix[secondRow, secondCol] = '.';
                matrix[snakeRow, snakeCol] = 'S';
            }
            else if (matrix[snakeRow, snakeCol] == '*')
            {
                food++;
                matrix[snakeRow, snakeCol] = 'S';
            }
            else
            {
                matrix[snakeRow, snakeCol] = 'S';
            }
        }
        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
