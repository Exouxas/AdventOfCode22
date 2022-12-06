using System.Linq;

namespace AdventOfCode22.Day06
{
    public class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            int ans = 0;

            for(int i = 0; i < puzzleInput[0].Length - 4; i++)
            {
                List<char> unique= new List<char>();

                for(int n = 0; n < 4; n++)
                {
                    if (!unique.Contains(puzzleInput[0][i + n]))
                    {
                        unique.Add(puzzleInput[0][i + n]);
                    }
                }


                if (unique.Count == 4)
                {
                    ans = i + 4;
                    return ans.ToString();
                }
            }

            return ans.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            int ans = 0;
            int amt = 14;

            for (int i = 0; i < puzzleInput[0].Length - amt; i++)
            {
                List<char> unique = new List<char>();

                for (int n = 0; n < amt; n++)
                {
                    if (!unique.Contains(puzzleInput[0][i + n]))
                    {
                        unique.Add(puzzleInput[0][i + n]);
                    }
                }


                if (unique.Count == amt)
                {
                    ans = i + amt;
                    return ans.ToString();
                }
            }

            return ans.ToString();
        }

        protected override string GetFolderName()
        {
            return "Day06";
        }
    }
}