namespace AdventOfCode22.Day04
{
    public class Solver : AdventSolver
    {
        private List<Pair> GetPairs()
        {
            List<Pair> pairs = new List<Pair>();
            foreach(string s in puzzleInput)
            {
                pairs.Add(new Pair(s));
            }

            return pairs;
        }

        public override string GetPuzzleOutput1()
        {
            int sum = 0;
            List<Pair> pairs = GetPairs();
            foreach(Pair pair in pairs)
            {
                if (pair.IsContained())
                {
                    sum++;
                }
            }

            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            int sum = 0;
            List<Pair> pairs = GetPairs();
            foreach (Pair pair in pairs)
            {
                if (pair.Overlaps())
                {
                    sum++;
                }
            }

            return sum.ToString();
        }

        protected override string GetFolderName()
        {
            return "Day04";
        }
    }
}