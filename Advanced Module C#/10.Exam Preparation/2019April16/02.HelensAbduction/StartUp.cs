using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HelensAbduction
{
    class StartUp
    {
        private const string PARIS_DIED = "Paris died at {0};{1}.";
        private const string PARIS_SAVE_HELENA = "Paris has successfully abducted Helen! Energy left: {0}";

        private static bool IsFindHelena = false;
        private static int energy = 0;
        private static int parisRow = 0;
        private static int parisCol = 0;
        private static char[][] matrix;
        private static string direction = string.Empty;
        private static int enemyRow;
        private static int enemyCol;
        static void Main(string[] args)
        {
            ReceiveDataAndCreateMatrix();
            Console.WriteLine(ReceiveDirection());
            PrintMatrix();
        }
        private static void ReceiveDataAndCreateMatrix()
        {
            energy = int.Parse(Console.ReadLine());
            int numberOfRow = int.Parse(Console.ReadLine());
            matrix = new char[numberOfRow][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine();
                matrix[row] = new char[data.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (data[col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                    matrix[row][col] = data[col];
                }
            }
        }

        private static string ReceiveDirection()
        {
            while (energy > 0 && !IsFindHelena)
            {
                string[] command =
                    Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                direction = command[0];
                enemyRow = int.Parse(command[1]);
                enemyCol = int.Parse(command[2]);
                matrix[enemyRow][enemyCol] = 'S';
                energy--;
                try
                {
                    matrix[parisRow][parisCol] = '-';
                    if (direction == "up")
                    {
                        CheckIndexIsOutOfTheRange(parisRow - 1, parisCol);
                        parisRow--;
                    }
                    else if (direction == "down")
                    {
                        CheckIndexIsOutOfTheRange(parisRow + 1, parisCol);
                        parisRow++;
                    }
                    else if (direction == "left")
                    {
                        CheckIndexIsOutOfTheRange(parisRow, parisCol - 1);
                        parisCol--;
                    }
                    else if (direction == "right")
                    {
                        CheckIndexIsOutOfTheRange(parisRow, parisCol + 1);
                        parisCol++;
                    }
                    Movement();
                }
                catch (IndexOutOfRangeException)
                {
                    matrix[parisRow][parisCol] = 'P';
                    continue;
                }
            }
            if (IsFindHelena)
            {
                matrix[parisRow][parisCol] = '-';
                return String.Format(PARIS_SAVE_HELENA, energy);
            }
            else
            {
                matrix[parisRow][parisCol] = 'X';
                return String.Format(PARIS_DIED, parisRow, parisCol);
            }
        }

        private static char CheckIndexIsOutOfTheRange(int row, int col)
            => matrix[row][col];

        private static void Movement()
        {
            if (matrix[parisRow][parisCol] == 'S')
            {
                energy -= 2;
            }
            else if (matrix[parisRow][parisCol] == 'H')
            {
                IsFindHelena = true;
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
