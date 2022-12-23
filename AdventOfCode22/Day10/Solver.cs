using System.Linq;

namespace AdventOfCode22.Day10
{
    public class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            int cycle = 0;
            int x = 1;
            int sum = 0;

            foreach(string line in puzzleInput)
            {
                string[] parts = line.Split(' ');

                cycle++;
                if (cycle == 20 || (cycle - 20) % 40 == 0)
                {
                    sum += x * cycle;
                }

                if (parts.Length == 2)
                {
                    cycle++;


                    if (cycle == 20 || (cycle - 20) % 40 == 0)
                    {
                        sum += x * cycle;
                    }

                    x += int.Parse(parts[1]);
                }
            }

            return "" + sum;
        }

        public override string GetPuzzleOutput2()
        {
            return "";
        }

        protected override string GetFolderName()
        {
            return "Day10";
        }
    }
}