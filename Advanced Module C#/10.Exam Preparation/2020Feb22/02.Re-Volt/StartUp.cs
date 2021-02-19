using System;

namespace _02.Re_Volt
{
    class StartUp
    {
        private const string WON = "Player won!";
        private const string LOST = "Player lost!";

        private static char[,] matrix;
        private static int playerRow = 0;
        private static int playerCol = 0;
        private static int trapRow = -1;
        private static int trapCol = -1;

        private static int numberOfRows;
        private static int numberOfCommands;
        static void Main(string[] args)
        {
            numberOfRows = int.Parse(Console.ReadLine());
            numberOfCommands = int.Parse(Console.ReadLine());
            CreateMatrix();
            Console.WriteLine(ReceiveCommandFromConsoleAndReturnResult());
            PrintMatrix();
        }
        private static void CreateMatrix()
        {
            matrix = new char[numberOfRows, numberOfRows];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(data[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if(data[col] == 'T')
                    {
                        trapRow = row;
                        trapCol = col;
                    }
                    matrix[row, col] = data[col];
                }
            }
        }
        private static string ReceiveCommandFromConsoleAndReturnResult()
        {
            for (int i = 1; i <= numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                bool finish = false;
                matrix[playerRow, playerCol] = '-';
                if(command == "down")
                {
                    if(!(playerRow + 1 == trapRow && playerCol == trapCol))
                    {
                        finish = Down();
                    }
                }
                else if( command == "right")
                {
                    if (!(playerRow == trapRow && playerCol + 1 == trapCol))
                    {
                        finish = Right();
                    }
                }
                else if(command == "up")
                {
                    if (!(playerRow - 1 == trapRow && playerCol == trapCol))
                    {
                        finish = Up();
                    }
                }
                else if(command == "left")
                {
                    if (!(playerRow  == trapRow && playerCol - 1== trapCol))
                    {
                        finish = Left();
                    }
                }
                matrix[playerRow, playerCol] = 'f';
                if (finish)
                {
                    return WON;
                }
            }
            return LOST;
        }

        private static bool Down()
        {
            playerRow++;
            if (IsOutOfTheRange())
            {
                playerRow = 0;
            }
            if (matrix[playerRow, playerCol] == 'B')
            {
                playerRow++;
                if (IsOutOfTheRange())
                {
                    playerRow = 0;
                }
                if(matrix[playerRow,playerCol] == 'B')
                {
                    playerRow++;
                }
            }
            return (IsFinal());    
        }

        private static bool Right()
        {
            playerCol++;
            if (IsOutOfTheRange())
            {
                playerCol = 0;
            }
            if (matrix[playerRow, playerCol] == 'B')
            {
                playerCol++;
                if (IsOutOfTheRange())
                {
                    playerCol = 0;
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerCol++;
                }
            }
            return (IsFinal());
        }
        private static bool Left()
        {
            playerCol--;
            if (IsOutOfTheRange())
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            if (matrix[playerRow, playerCol] == 'B')
            {
                playerCol--;
                if (IsOutOfTheRange())
                {
                    playerCol = matrix.GetLength(1) - 1;
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerCol--;
                }
            }
            return (IsFinal());
        }
        private static bool Up()
        {
            playerRow--;
            if (IsOutOfTheRange())
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            if (matrix[playerRow, playerCol] == 'B')
            {
                playerRow--;
                if (IsOutOfTheRange())
                {
                    playerRow = matrix.GetLength(0) - 1;
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow--;
                }
            }
            return (IsFinal());
        }

        private static bool IsFinal()
            => matrix[playerRow, playerCol] == 'F';
        private static bool IsOutOfTheRange()
            =>
            playerRow < 0 || playerRow >= matrix.GetLength(0) ||
            playerCol < 0 || playerCol >= matrix.GetLength(1);
            
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
