

using System.Data;
using System.Runtime.CompilerServices;
using AoC24;
using Microsoft.VisualBasic;

internal class Fourteen : ISolver
{
    public void solve()
    {
        var lines = File.ReadAllLines("project_inputs/14.txt").Where(line => !string.IsNullOrWhiteSpace(line));
        int rows = 103, cols = 101;
        var grid = instantiateGrid(rows, cols);
        Console.WriteLine("Initial grid state: ");
        printGridState(grid);
        Console.WriteLine("-----");
        var bots = initiBots(lines);
        updateGridWithBots(grid, bots);
        printGridState(grid);

        var seconds = 10000;
        var second = 0;
        while (second < seconds)
        {
            foreach (var bot in bots)
            {
                bot.updatePos(rows, cols);
            }
            grid = instantiateGrid(rows, cols);
            updateGridWithBots(grid, bots);
            if (checkForTree(grid))
            {
                printGridState(grid);
                Console.WriteLine($"Second: {second}");
                break;
            }
            second++;
        }
        var answer = finaleUpdate(grid);
        printGridState(grid);
        Console.WriteLine($"Final answer: {answer}");

    }

    public void solveSecondPart()
    {
        throw new NotImplementedException();
    }


    private bool checkForTree(char[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (i > 1 && (i < grid.GetLength(0) - 1) && j > 1 && (j < grid.GetLength(1) - 1))
                {
                    var up = grid[i - 1, j];
                    var down = grid[i + 1, j];
                    var left = grid[i, j - 1];
                    var right = grid[i, j + 1];
                    var upright = grid[i + 1, j - 1];
                    var upleft = grid[i - 1, j - 1];
                    var downleft = grid[i - 1, j + 1];
                    var downright = grid[i + 1, j + 1];

                    if (char.IsDigit(up) && char.IsDigit(down) && char.IsDigit(left) && char.IsDigit(right) && char.IsDigit(upright) && char.IsDigit(downright)
                    && char.IsDigit(upleft) && char.IsDigit(downleft))
                        return true;
                }
            }
        }
        return false;
    }
    private List<Bot> initiBots(IEnumerable<string> botLines)
    {
        var bots = new List<Bot>();
        foreach (var botLine in botLines)
        {
            if (string.IsNullOrWhiteSpace(botLine))
                continue;
            var posIndex = botLine.IndexOf("p");
            var velIndex = botLine.IndexOf("v");

            var positions = botLine.Substring(posIndex + 2, velIndex - 2).Split(",");
            var velocities = botLine.Substring(velIndex + 2).Split(",");
            var px = int.Parse(positions[0]);
            var py = int.Parse(positions[1]);
            var vx = int.Parse(velocities[0]);
            var vy = int.Parse(velocities[1]);

            Bot bot = new Bot(px, py, vx, vy);
            bots.Add(bot);
        }
        return bots;
    }
    private char[,] instantiateGrid(int rows, int cols)
    {
        char[,] grid = new char[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = '.';
            }
        }
        return grid;
    }

    private char[,] updateGridWithBots(char[,] grid, List<Bot> bots)
    {
        foreach (Bot bot in bots)
        {
            if (grid[bot.pY, bot.pX].Equals('.'))
                grid[bot.pY, bot.pX] = '1';
            else
                grid[bot.pY, bot.pX] = (char)(int.Parse(grid[bot.pY, bot.pX].ToString()) + '0' + 1);
        }

        return grid;
    }


    private int finaleUpdate(char[,] grid)
    {
        var midy = (grid.GetLength(0) - 1) / 2;
        var midx = (grid.GetLength(1) - 1) / 2;
        int q1 = 0, q2 = 0, q3 = 0, Q4 = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (i == midy || j == midx)
                {
                    grid[i, j] = ' ';
                    continue;
                }
                char c = grid[i, j];
                if (char.IsDigit(c))
                {
                    if (i < midy && j < midx) q1 += int.Parse(c.ToString());
                    else if (i < midy && j > midx) q2 += int.Parse(c.ToString());
                    else if (i > midy && j < midx) q3 += int.Parse(c.ToString());
                    else if (i > midy && j > midx) Q4 += int.Parse(c.ToString());
                }

            }
        }

        return q1 * q2 * q3 * Q4;
    }
    private void printGridState(char[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----");
    }


}

internal class Bot
{
    public int pX;
    public int pY;
    public int vX;
    public int vY;

    public Bot(int pX, int pY, int vX, int vY)
    {
        this.pX = pX;
        this.pY = pY;
        this.vX = vX;
        this.vY = vY;
    }

    public void updatePos(int row, int col)
    {
        this.pX = (this.pX + this.vX + col) % col;
        this.pY = (this.pY + this.vY + row) % row;

        // if (this.pX > col)
        // {
        //     this.pX = (this.pX - col);
        //     this.pY++;
        // }
        // if (this.pX < 0)
        // {
        //     this.pX = this.pX - col;
        //     this.pY--;
        // }
        // if (this.pY > row)
        // {
        //     this.pY = (this.pY - row);
        //     this.vX++;
        // }
        // if (this.pY < 0)
        // {
        //     this.pY = this.pY - row;
        //     this.pX--;
        // }

    }

}