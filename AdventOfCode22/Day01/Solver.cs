namespace AdventOfCode22.Day01
{
    public class Solver : AdventSolver
    {
        private List<List<int>> Digest()
        {
            List<List<int>> values = new();
            values.Add(new List<int>());

            foreach (string s in puzzleInput)
            {
                if (s.Length > 0)
                {
                    values.Last().Add(int.Parse(s));
                }
                else
                {
                    values.Add(new List<int>());
                }
            }

            return values;
        }

        public List<int> GetTotals()
        {
            List<int> values = new();
            foreach (List<int> lst in Digest())
            {
                int v = 0;
                foreach (int i in lst)
                {
                    v += i;
                }
                values.Add(v);
            }

            return values;
        }

        public override string GetPuzzleOutput1()
        {
            int biggest = 0;
            foreach(int i in GetTotals())
            {
                if(i > biggest)
                {
                    biggest = i;
                }
            }

            return biggest.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            List<int> totals = GetTotals();
            totals.Sort();
            totals.Reverse();
            int top3 = 0;
            top3 += totals[0];
            top3 += totals[1];
            top3 += totals[2];
            return top3.ToString();
        }

        protected override string GetFolderName()
        {
            return "Day01";
        }
    }
}