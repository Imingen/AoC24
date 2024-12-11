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
                var stones = mainStones.Split(' ');
                StringBuilder tmpStoneString = new StringBuilder();
                foreach (var stone in stones)
                {
                    if (stone.Equals("0"))
                    {
                        tmpStoneString.Append("1 ");
                    }
                    else if (stone.Length % 2 == 0)
                    {

                    }
                }

                start++;
            }


        }

        public void solveSecondPart()
        {
            throw new NotImplementedException();
        }
    }
}