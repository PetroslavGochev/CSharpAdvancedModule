using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ExelFunction
{
    class StartUp
    {
        private static string[] command;
        private static List<string> firstRow = new List<string>();
        private static string[][] matrix;
        static void Main(string[] args)
        {
            CreateMatrix();
            ReceiveCommand();

        }

        private static void ReceiveCommand()
        {
            command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (command[0] == "filter")
            {
                FilterResultInMatrix();
            }
            else if (command[0] == "hide")
            {
                HideResultInMatrix();
            }
            else if (command[0] == "sort")
            {
                SortByColumn();
            }
        }
        private static void SortByColumn()
        {
            string filterByCol = command[1];
            int col = firstRow.FindIndex(x => x.Contains(filterByCol));
            List<string> sortedColumn = new List<string>();
            PrintRow(firstRow.ToArray());
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                sortedColumn.Add(matrix[row][col]);
            }
            sortedColumn = sortedColumn.OrderBy(x => x).ToList();
            for (int i = 0; i < sortedColumn.Count; i++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row][col] == sortedColumn[i])
                    {
                        PrintRow(matrix[row]);
                    }
                }
            }
        }
        private static void HideResultInMatrix()
        {
            string filterByCol = command[1];
            int col = firstRow.FindIndex(x => x.Contains(filterByCol));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                List<string> matrixRow = matrix[row].ToList();
                matrixRow.RemoveAt(col);
                PrintRow(matrixRow.ToArray());
            }
        }
        private static void FilterResultInMatrix()
        {
            string filterByCol = command[1];
            string filterValue = command[2];
            int col = firstRow.FindIndex(x => x.Contains(filterByCol));
            PrintRow(firstRow.ToArray());
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row][col] == filterValue)
                {
                    PrintRow(matrix[row]);
                }
            }
        }
        private static void PrintRow(string[] row)
            => Console.WriteLine(string.Join(" | ", row));
        private static void CreateMatrix()
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            matrix = new string[numberOfRows][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                matrix[row] = new string[data.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (row == 0)
                    {
                        firstRow.Add(data[col]);
                    }
                    matrix[row][col] = data[col];
                }
            }
        }
    }
}