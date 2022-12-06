namespace AdventOfCode22.Day05
{
    public class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            List<string> preArrangement = new List<string>();
            int start = 0;
            foreach (string s in puzzleInput)
            {
                start++;

                if (s.Equals(""))
                {
                    break;
                }

                preArrangement.Add(s);
            }

            preArrangement.RemoveAt(preArrangement.Count - 1);
            Arrangement a = new Arrangement(preArrangement);

            for(int i = start; i < puzzleInput.Length; i++)
            {
                a.MakeMove(new Move(puzzleInput[i]));
            }

            return a.GetTops();
        }

        public override string GetPuzzleOutput2()
        {
            List<string> preArrangement = new List<string>();
            int start = 0;
            foreach (string s in puzzleInput)
            {
                start++;

                if (s.Equals(""))
                {
                    break;
                }

                preArrangement.Add(s);
            }

            preArrangement.RemoveAt(preArrangement.Count - 1);
            Arrangement a = new Arrangement(preArrangement);

            for (int i = start; i < puzzleInput.Length; i++)
            {
                a.MultiMove(new Move(puzzleInput[i]));
            }

            return a.GetTops();
        }

        protected override string GetFolderName()
        {
            return "Day05";
        }
    }
}