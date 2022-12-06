using System.Linq;

namespace AdventOfCode22.Day03
{
    public class Solver : AdventSolver
    {
        private List<string[]> GetSacks()
        {
            List<string[]> sacks = new List<string[]>();

            foreach(string s in puzzleInput)
            {
                string first = s.Substring(0, s.Length / 2);
                string last = s.Substring(s.Length / 2);
                sacks.Add(new string[] { first, last });
            }

            return sacks;
        }

        public override string GetPuzzleOutput1()
        {
            int sum = 0;
            foreach(string[] sack in GetSacks())
            {
                List<char> chars = new List<char>();
                foreach(char c in sack[0])
                {
                    if (!chars.Contains(c))
                    {
                        chars.Add(c);
                    }
                }

                foreach(char c in sack[1])
                {
                    if (chars.Contains(c))
                    {
                        sum += PointScore(c);
                        break;
                    }
                }
            }

            return sum.ToString();
        }

        private int PointScore(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return 1 + c - 'a';
            }
            else
            {
                return 27 + c - 'A';
            }
        }

        public override string GetPuzzleOutput2()
        {
            int sum = 0;
            for (int i = 0; i < puzzleInput.Length; i += 3)
            {
                List<char> unique = new();
                foreach (char c in puzzleInput[i])
                {
                    if (!unique.Contains(c))
                    {
                        unique.Add(c);
                    }
                }

                for(int n = 0; n < 2; n++)
                {
                    List<char> newList = new();
                    foreach(char c1 in unique)
                    {
                        foreach(char c2 in puzzleInput[i + n + 1])
                        {
                            if(c1 == c2)
                            {
                                if (!newList.Contains(c1))
                                {
                                    newList.Add(c1);
                                }
                            }
                        }
                    }
                    unique = newList;
                }

                if(unique.Count > 1) 
                { 
                    Console.WriteLine("Fuck, it's " + unique.Count);
                }
                else
                {
                    sum += PointScore(unique.First());
                }
            }


            return sum.ToString();
        }

        protected override string GetFolderName()
        {
            return "Day03";
        }
    }
}