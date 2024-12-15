

using System.Collections;

namespace AoC24
{
    internal class Twelve : ISolver
    {
        public void solve()
        {
            char[,] grid = new char[4, 4]
            {
                { 'A', 'A', 'A', 'A' },
                { 'B', 'B', 'C', 'D' },
                { 'B', 'B', 'C', 'C' },
                { 'E', 'E', 'E', 'C' }
            };

            bool[,] visited = new bool[4, 4];



        }

        private void DFS(int row, int col, int[,] grid, bool[,] visited)
        {
            Stack stack = new Stack();
            stack.Push(new Tuple<int, int>(row, col));

            while (stack.Count > 0)
            {
                Tuple<int, int> curr = (Tuple<int, int>)stack.Peek();
                stack.Pop();
            }

        }

        public void solveSecondPart()
        {
            throw new NotImplementedException();
        }
    }
}
