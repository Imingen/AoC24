using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace AoC24
{
    internal class Eleven : ISolver
    {
        public void solve()
        {
            int start = 0;
            int stop = 25;
            var mainStones = "112 1110 163902 0 7656027 83039 9 74";
            while (start < stop)
            {
                var stones = mainStones.Split(" ");
                StringBuilder tmpStoneString = new StringBuilder();

                foreach (var stone in stones)
                {
                    try
                    {
                        if (stone.Equals("0"))
                        {
                            tmpStoneString.Append("1 ");
                        }
                        else if (stone.Length % 2 == 0)
                        {
                            var firstPart = long.Parse(stone.Substring(0, stone.Length / 2));
                            var secondPart = long.Parse(stone.Substring(stone.Length / 2));
                            tmpStoneString.Append(firstPart.ToString() + " " + secondPart.ToString() + " ");
                        }
                        else
                        {
                            var newStoneNumber = (long.Parse(stone) * 2024).ToString();
                            tmpStoneString.Append(newStoneNumber + " ");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        Console.WriteLine("...." + stone + "----");
                        break;
                    }

                }
                tmpStoneString.Remove(tmpStoneString.Length - 1, 1);
                mainStones = tmpStoneString.ToString();
                start++;
            }
            var numberOfStones = mainStones.Split(' ').Length;
            Console.WriteLine($"Number of stones = {numberOfStones}");


        }

        public void solveSecondPart()
        {
            int start = 0;
            int stop = 75;
            var mainStones = "112 1110 163902 0 7656027 83039 9 74";


            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, mainStones);


            while (start < stop)
            {
                using (FileStream inputStream = new FileStream(tempFile, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(inputStream))
                using (FileStream outputStream = new FileStream(tempFile + ".tmp", FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(outputStream))
                {

                    StringBuilder currentStone = new StringBuilder();

                    while (reader.Peek() >= 0)
                    {
                        char c = (char)reader.Read();
                        if (c == ' ')
                        {
                            processStones(currentStone, writer);
                            currentStone.Clear();
                        }
                        else
                        {
                            currentStone.Append(c);
                        }
                    }

                    if (currentStone.Length > 0)
                    {
                        processStones(currentStone, writer);
                    }
                }

                File.Delete(tempFile);
                File.Move(tempFile + ".tmp", tempFile);
                start++;
            }

            var finalStones = File.ReadAllText(tempFile);
            finalStones = finalStones.Remove(finalStones.Length - 1, 1);
            var numberOfStones = finalStones.Split(" ").Length;

            Console.WriteLine($"Number of stones = {numberOfStones}");

        }

        //this is when I give up and look at reddit for help
        public void solveWithHelpFromReddit()
        {
            int start = 0;
            int stop = 75;
            var mainStones = "112 1110 163902 0 7656027 83039 9 74";
            Console.WriteLine(mainStones);
            var stonesAsList = mainStones.Split(" ");
            var stones = stonesAsList.ToDictionary(n => n, n => new BigInteger(1));

            while (start < stop)
            {
                var newStones = new Dictionary<string, BigInteger>();
                foreach (var kvp in stones)
                {
                    string stone = kvp.Key.Trim();
                    if (stone.Equals("0"))
                    {
                        if (newStones.ContainsKey("1"))
                        {
                            newStones["1"] += kvp.Value;

                        }
                        else
                        {
                            newStones["1"] = kvp.Value;
                        }
                    }
                    else if (stone.Length % 2 == 0)
                    {
                        var firstPart = BigInteger.Parse(stone.Substring(0, stone.Length / 2)).ToString();
                        var secondPart = BigInteger.Parse(stone.Substring(stone.Length / 2)).ToString();
                        if (newStones.ContainsKey(firstPart))
                        {
                            newStones[firstPart] += kvp.Value;
                        }
                        else
                        {
                            newStones[firstPart] = kvp.Value;

                        }
                        if (newStones.ContainsKey(secondPart))
                        {
                            newStones[secondPart] += kvp.Value;
                        }
                        else
                        {
                            newStones[secondPart] = kvp.Value;
                        }


                    }
                    else
                    {
                        var k = (BigInteger.Parse(stone) * 2024).ToString();
                        if (newStones.ContainsKey(k))
                        {
                            newStones[k] += kvp.Value;
                        }
                        else
                        {
                            newStones[k] = kvp.Value;
                        }
                    }
                }
                stones = new Dictionary<string, BigInteger>(newStones);
                //Console.WriteLine($"After {start} blinks: {string.Join(" ", stones.Select(kvp => $"{kvp.Key}({kvp.Value})"))}");
                start++;
            }

            BigInteger sum = stones.Values.Aggregate(BigInteger.Zero, (sum, value) => sum + value);
            Console.WriteLine($"Number of stones: {sum}: should be 183620");
        }

        private void processStones(StringBuilder stone, StreamWriter writer)
        {
            string stonestr = stone.ToString();
            if (stonestr.Equals("0"))
            {
                writer.Write("1 ");
            }
            else if (stonestr.Length % 2 == 0)
            {
                var firstPart = long.Parse(stonestr.Substring(0, stonestr.Length / 2));
                var secondPart = long.Parse(stonestr.Substring(stonestr.Length / 2));
                writer.Write($"{firstPart} {secondPart} ");
            }
            else
            {
                var newStoneNumber = (BigInteger.Parse(stonestr.ToString()) * 2024).ToString();
                writer.Write($"{newStoneNumber} ");
            }
        }
    }
}