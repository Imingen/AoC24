using AoC24;

internal class One : ISolver
{
    public void solve()
    {

        var lines = File.ReadAllLines("input_one.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
        List<int> listOne = new List<int>();
        List<int> listTwo = new List<int>();
        foreach (var line in lines)
        {
            var splitLines = line.Split("   ");
            listOne.Add(int.Parse(splitLines[0]));
            listTwo.Add(int.Parse(splitLines[1]));
        }

        var total = 0;

        listOne.Sort();
        listTwo.Sort();

        for (int i = 0; i < listOne.Count; i++)
        {
            var diff = Math.Abs(listOne[i] - listTwo[i]);
            total += diff;
        }
        Console.WriteLine("Diff is: " + total);


        var result = listOne.ToDictionary(
            number => number,
            number => listTwo.Count(n => n == number));


        var total2 = 0;
        foreach (var item in result)
        {
            var ja = item.Key * item.Value;
            total2 += ja;
        }

        Console.WriteLine("Total is: " + total2);
    }

    public void solveSecondPart()
    {
        throw new NotImplementedException();
    }
}