using System;
using System.Linq;

namespace P02SecondProblem
{
    class StartUp
    {
        private const string DRAW = "It's a draw! Player One has {0} ships left. Player Two has {1} ships left.";
        private const string FIRST_WIN = "Player One has won the game! {0} ships have been sunk in the battle.";
        private const string SECOND_WIN = "Player Two has won the game! {0} ships have been sunk in the battle.";

        private static int startedShip;
        private static string[,] matrix;
        private static int row = 0;
        private static int col = 0;
        private static string[] command;
        private static int teamOne = 0;
        private static int teamTwo = 0;
        static void Main(string[] args)
        {
            CreateMatrix();
            War();
            teamOne = 0;
            teamTwo = 0;
            if (CheckPlayers())
            {
                Console.WriteLine(String.Format(DRAW, teamOne, teamTwo));
            }
            else if(teamOne == 0)
            {
                int countOfRestShip = startedShip - teamTwo;
                Console.WriteLine(String.Format(SECOND_WIN, countOfRestShip));
            }
            else if(teamTwo == 0)
            {
                int countOfRestShip = startedShip - teamOne;
                Console.WriteLine(String.Format(FIRST_WIN, countOfRestShip));
            }
            
        }
        private static void War()
        {
            for (int i = 0; i < command.Length; i++)
            {
                string[] rowCol = command[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                row = int.Parse(rowCol[0]);
                col = int.Parse(rowCol[1]);
                try
                {
                    if(matrix[row,col] == ">")
                    {
                        matrix[row, col] = "X";
                    }
                    else if(matrix[row,col] == "<")
                    {
                        matrix[row, col] = "X";
                    }
                    else if(matrix[row,col] == "#")
                    {
                        matrix[row, col] = "X";
                        HitMina();
                    }
                    if (!CheckPlayers())
                    {
                        break;
                    }
                    teamOne = 0;
                    teamTwo = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    continue;                 
                }
                    
            }
        }
        private static bool CheckPlayers()
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if(matrix[rows,cols] == "<")
                    {
                        teamOne++;
                    }
                    else if(matrix[rows,cols] == ">")
                    {
                        teamTwo++;
                    }
                }
            }
            if (teamOne > 0 && teamTwo > 0)
            {
                return true;
            }
            return false;
        }
        private static void HitMina()
        {
            if(IsValid(row - 1, col - 1))
            {
                matrix[row - 1, col - 1] = "X";
            }
            if (IsValid(row - 1, col))
            {
                matrix[row - 1, col] = "X";
            }
            if (IsValid(row - 1, col+1))
            {
                matrix[row - 1, col+1] = "X";
            }
            if (IsValid(row , col - 1))
            {
                matrix[row , col - 1] = "X";
            }
            if (IsValid(row, col + 1))
            {
                matrix[row, col + 1] = "X";
            }
            if (IsValid(row + 1, col - 1))
            {
                matrix[row + 1, col - 1] = "X";
            }
            if (IsValid(row + 1, col))
            {
                matrix[row + 1, col] = "X";
            }
            if (IsValid(row + 1, col + 1))
            {
                matrix[row + 1, col + 1] = "X";
            }


        }

        private static bool IsValid(int row, int col)
            => row >= 0 && row < matrix.GetLength(0) &&
            col >= 0 && col < matrix.GetLength(1);


        private static void CreateMatrix()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            command = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            matrix = new string[numberOfRows, numberOfRows];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var data = ReturnArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if(data[column] == "<" || data[column] == ">")
                    {
                        startedShip++;
                    }
                    matrix[rows, column] = data[column];
                }
            }
        }

        private static string[] ReturnArray()
            => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
}