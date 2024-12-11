namespace AoC24
{
    internal class Two : ISolver

    {
        public void solve()
        {
            string firstOrSecond = "first";
            int safeReports = 0;
            var lines = File.ReadAllLines("project_inputs/input_two.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));

            if (firstOrSecond.Equals("first"))
            {
                foreach (var line in lines)
                {
                    var reports = line.Split(' ').Select(s => Convert.ToInt32(s)).ToList();
                    bool isDecreasing = reports.Zip(reports.Skip(1), (a, b) => a > b).All(x => x);
                    bool isIncreasing = reports.Zip(reports.Skip(1), (a, b) => a < b).All(x => x);

                    if (!isIncreasing && !isDecreasing)
                        continue;

                    bool isOk = reports.Zip(reports.Skip(1), (a, b) => Math.Abs(a - b)).All(diff => diff >= 1 && diff <= 3);
                    if (!isOk)
                        continue;

                    safeReports++;

                }

                Console.WriteLine("Number of safe reports: " + safeReports);
            }
            else
            {
                foreach (var line in lines)
                {
                    var reports = line.Split(' ').Select(s => Convert.ToInt32(s)).ToList();
                    var prevValue = reports[0];
                    for (int i = 0; i < reports.Count; i++)
                    {
                        bool isDecreasing = reports.Zip(reports.Skip(1), (a, b) => a > b).All(x => x);
                        bool isIncreasing = reports.Zip(reports.Skip(1), (a, b) => a < b).All(x => x);

                        if (!isIncreasing || !isDecreasing)
                            continue;
                        bool isOk = reports.Zip(reports.Skip(1), (a, b) => Math.Abs(a - b)).All(diff => diff >= 1 && diff <= 3);
                        if (isOk)
                        {
                            safeReports++;
                            continue;
                        }

                    }

                }

            }



        }

        public void solveSecondPart()
        {
            throw new NotImplementedException();
        }
    }
}
