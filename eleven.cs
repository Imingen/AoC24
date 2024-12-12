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

            MemoryStream memoryStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memoryStream);
            streamWriter.Write(mainStones);
            streamWriter.Flush();
            memoryStream.Position = 0;

            while (start < stop)
            {
                memoryStream.Position = 0;
                StreamReader streamReader = new StreamReader(memoryStream);
                MemoryStream newMemoryStream = new MemoryStream();
                StreamWriter newWriter = new StreamWriter(newMemoryStream);

                StringBuilder currentStone = new StringBuilder();

                while (streamReader.Peek() >= 0)
                {
                    char c = (char)streamReader.Read();
                    if (c == ' ')
                    {
                        processStones(currentStone, newWriter);
                        currentStone.Clear();
                    }
                    else
                    {
                        currentStone.Append(c);
                    }
                }

                if (currentStone.Length > 0)
                {
                    processStones(currentStone, newWriter);
                }
                newWriter.Flush();
                memoryStream.Dispose();
                memoryStream = newMemoryStream;
                start++;
            }

            memoryStream.Position = 0;
            StreamReader finalReader = new StreamReader(memoryStream);
            var finalStones = finalReader.ReadToEnd();
            finalStones = finalStones.Remove(finalStones.Length - 1, 1);
            var numberOfStones = finalStones.Split(" ").Length;

            Console.WriteLine($"Number of stones = {numberOfStones}");

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