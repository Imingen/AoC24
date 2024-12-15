using System;
using System.Collections.Generic;

namespace AoC24
{
    internal class Test
    {
        static int rows = 5;
        static int cols = 5;
        static char[,] grid = {
        { 'R', 'R', 'R', 'R', 'I' },
        { 'I', 'C', 'C', 'F', 'F' },
        { 'R', 'I', 'C', 'C', 'F' },
        { 'V', 'V', 'R', 'C', 'C' },
        { 'V', 'V', 'R', 'C', 'J' }
    };
        static bool[,] visited = new bool[rows, cols];
        static int[] dRow = { -1, 1, 0, 0 };  // Up, Down, Left, Right
        static int[] dCol = { 0, 0, -1, 1 };  // Up, Down, Left, Right

        private void DFS(int row, int col, char targetChar)
        {
            // Stack for DFS
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((row, col));
            visited[row, col] = true;

            while (stack.Count > 0)
            {
                var (r, c) = stack.Pop();

                // Explore neighbors (up, down, left, right)
                for (int i = 0; i < 4; i++)
                {
                    int newRow = r + dRow[i];
                    int newCol = c + dCol[i];

                    // Check if within bounds and character matches
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols
                        && !visited[newRow, newCol] && grid[newRow, newCol] == targetChar)
                    {
                        visited[newRow, newCol] = true;
                        stack.Push((newRow, newCol));
                    }
                }

                // Visualize the current state of the grid
                PrintGrid();
                Console.WriteLine("Stack: " + string.Join(", ", stack));
                Console.WriteLine();
            }
        }

        private void PrintGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (visited[i, j])
                    {
                        // Change color for visited cells
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(grid[i, j] + " ");
                    }
                    else
                    {
                        // Keep default color for unvisited cells
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(grid[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }

            // Reset color after printing
            Console.ResetColor();
        }

        public void Run()
        {
            Console.WriteLine("Initial Grid:");
            PrintGrid();
            Console.WriteLine();

            // Run DFS starting from (0, 0) and target character 'R'
            DFS(0, 0, 'R');
        }
    }
}