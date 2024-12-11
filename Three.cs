using System.Text.RegularExpressions;

namespace AoC24
{
    internal class Three : ISolver
    {
        public void solve()
        {
            int total = 0;
            var fileContent = File.ReadAllText("project_inputs/input_three.txt");


            string pattern = @"mul\(\d+,\d+\)";
            string numberPattern = @"\d+,\d+";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(fileContent);

            foreach (Match match in matches)
            {
                Regex regexNumber = new Regex(numberPattern);
                Match matchNumber = regexNumber.Match(match.Value);
                var numbers = matchNumber.Value.Split(',').Select(x => int.Parse(x));
                total += numbers.Aggregate((curr, number) => curr * number);
            }
            Console.WriteLine("Total is: " + total);
        }


        public void solveSecondPart()
        {
            int total = 0;
            var fileContent = File.ReadAllText("project_inputs/input_three.txt");

            string pattern = @"mul\(\d+,\d+\)|do\(\)|don\'t\(\)";
            string numberPattern = @"\d+,\d+";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(fileContent);
            bool dont = false;
            foreach (Match match in matches)
            {

                if (match.Value.Contains("don't"))
                {
                    dont = true;
                    continue;
                }
                else if (match.Value.Contains("do"))
                {
                    dont = false;
                    continue;
                }
                else if (dont)
                {
                    continue;
                }
                Regex regexNumber = new Regex(numberPattern);
                Match matchNumber = regexNumber.Match(match.Value);
                var numbers = matchNumber.Value.Split(',').Select(x => int.Parse(x));
                total += numbers.Aggregate((curr, number) => curr * number);
            }
            Console.WriteLine("Total is: " + total);
        }
    }
}