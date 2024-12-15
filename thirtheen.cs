
using AoC24;

internal class Thirtheen : ISolver
{
    public void solve()
    {


        var lines = File.ReadAllLines("project_inputs/13.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
        double ax = 0, ay = 0, C1 = 0;
        double bx = 0, by = 0, C2 = 0;
        double totalTokens = 0;
        var numberOfValidCoordinates = 0;
        foreach (var line in lines)
        {

            if (line.StartsWith("Button A"))
            {
                var axStartIndex = line.IndexOf("X") + 2;
                var axEndIndex = line.IndexOf(",");

                var ayStartIndex = line.IndexOf("Y") + 2;
                ax = double.Parse(line.Substring(axStartIndex, axEndIndex - axStartIndex));
                ay = double.Parse(line.Substring(ayStartIndex));
                continue;
            }
            else if (line.StartsWith("Button B"))
            {
                var bxStartIndex = line.IndexOf("X") + 2;
                var bxEndIndex = line.IndexOf(",");

                var byStartIndex = line.IndexOf("Y") + 2;
                bx = double.Parse(line.Substring(bxStartIndex, bxEndIndex - bxStartIndex));
                by = double.Parse(line.Substring(byStartIndex));
                continue;
            }
            else if (line.StartsWith("Prize:"))
            {
                var C1StartIndex = line.IndexOf("X") + 2;
                var C1EndIndex = line.IndexOf(",");
                var C2StartIndex = line.IndexOf("Y") + 2;

                C1 = double.Parse(line.Substring(C1StartIndex, C1EndIndex - C1StartIndex)) + 10000000000000;
                C2 = double.Parse(line.Substring(C2StartIndex)) + 10000000000000;
            }


            Console.WriteLine($"Found these variables: ax: {ax}, ay: {ay}, bx: {bx}, by: {by}, C1: {C1}, C2: {C2}");

            //find determinant
            var det = Math.Abs((ax * by) - (ay * bx));
            if (det == 0)
            {
                Console.WriteLine("Determinant is 0, no solution");
                continue;
            }

            var dx = Math.Abs((C1 * by) - (C2 * bx));
            var dy = Math.Abs((C1 * ay) - (C2 * ax));

            var ansx = dx / det;
            var ansy = dy / det;
            if (ansx != Math.Floor(ansx) || ansy != Math.Floor(ansy))
            {
                Console.WriteLine("Cant reach the exact coordinates with this combination");
                continue;
            }

            totalTokens += (ansx * 3) + (ansy * 1);
            numberOfValidCoordinates++;
            Console.WriteLine($"X: {ansx}, Y: {ansy}");
        }

        Console.WriteLine($"Number of valid coordinates: {numberOfValidCoordinates}. Number of tokens: {totalTokens.ToString("0")}");
        // int ax = 94, ay = 34, C1 = 8400;
        // int bx = 22, by = 67, C2 = 5400;

        // //Find determinant 
        // var det = (ax * by) - (bx * ay);

        // //calc dx and dy
        // var dx = (C1 * by) - (C2 * bx);
        // var dy = (C1 * ay) - (C2 * ax);

        // var ansx = dx / det;
        // var ansy = dy / det;
        // Console.WriteLine($"X: {ansx}, Y: {ansy}");
    }

    public void solveSecondPart()
    {
        throw new NotImplementedException();
    }
}
