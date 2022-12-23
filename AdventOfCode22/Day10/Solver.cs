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
            int x = 0;
            int aaa = 0;
            int cycle = 0;
            string output = "\n";

            foreach (string line in puzzleInput)
            {
                string[] parts = line.Split(' ');

                cycle++;
                aaa = (cycle - 1) % 40;
                if (aaa >= x & aaa < x + 3)
                {
                    output += "#";
                }
                else
                {
                    output += " ";
                }

                if (cycle  % 40 == 0)
                {
                    output += "\n";
                }

                if (parts.Length == 2)
                {
                    cycle++;
                    aaa = (cycle - 1) % 40;
                    if (aaa >= x & aaa < x + 3)
                    {
                        output += "#";
                    }
                    else
                    {
                        output += " ";
                    }


                    if (cycle % 40 == 0)
                    {
                        output += "\n";
                    }

                    x += int.Parse(parts[1]);
                }
            }


            return output;
        }

        protected override string GetFolderName()
        {
            return "Day10";
        }
    }
}