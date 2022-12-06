namespace AdventOfCode22.Day02
{
    public class Solver : AdventSolver
    {
        List<RPSGame> GetGames()
        {
            List<RPSGame> list = new();

            foreach(string s in puzzleInput)
            {
                string[] parts = s.Split(' ');
                Hand opponent = Hand.Rock;
                Hand hand = Hand.Rock;

                switch (parts[0])
                {
                    case "A":
                        opponent = Hand.Rock;
                        break;
                    case "B":
                        opponent = Hand.Paper;
                        break;
                    case "C":
                        opponent = Hand.Scissors;
                        break;
                }

                switch (parts[1])
                {
                    case "X":
                        hand = Hand.Rock;
                        break;
                    case "Y":
                        hand = Hand.Paper;
                        break;
                    case "Z":
                        hand = Hand.Scissors;
                        break;
                }


                list.Add(new RPSGame(opponent, hand));
            }

            return list;
        }

        List<RPSGame> GetGames2()
        {
            List<RPSGame> list = new();

            foreach (string s in puzzleInput)
            {
                string[] parts = s.Split(' ');
                Hand opponent = Hand.Rock;
                Hand hand = Hand.Rock;

                switch (parts[0])
                {
                    case "A":
                        opponent = Hand.Rock;
                        break;
                    case "B":
                        opponent = Hand.Paper;
                        break;
                    case "C":
                        opponent = Hand.Scissors;
                        break;
                }

                switch (parts[1])
                {
                    case "X":
                        switch (opponent)
                        {
                            case Hand.Rock:
                                hand = Hand.Scissors;
                                break;
                            case Hand.Paper:
                                hand = Hand.Rock;
                                break;
                            case Hand.Scissors:
                                hand = Hand.Paper;
                                break;
                        }
                        break;
                    case "Y":
                        hand = opponent;
                        break;
                    case "Z":
                        switch (opponent)
                        {
                            case Hand.Rock:
                                hand = Hand.Paper;
                                break;
                            case Hand.Paper:
                                hand = Hand.Scissors;
                                break;
                            case Hand.Scissors:
                                hand = Hand.Rock;
                                break;
                        }
                        break;
                }


                list.Add(new RPSGame(opponent, hand));
            }

            return list;
        }

        public override string GetPuzzleOutput1()
        {
            int sum = 0;
            foreach(RPSGame game in GetGames())
            {
                sum += game.Points;
            }
            return sum.ToString();
        }

        public override string GetPuzzleOutput2()
        {
            int sum = 0;
            foreach (RPSGame game in GetGames2())
            {
                sum += game.Points;
            }
            return sum.ToString();
        }

        protected override string GetFolderName()
        {
            return "Day02";
        }
    }
}