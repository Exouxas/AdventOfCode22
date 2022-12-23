using System.Linq;

namespace AdventOfCode22.Day11
{
    public class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            List<Monkey> monkeys = GenerateMonkeys();



            return "";
        }

        public override string GetPuzzleOutput2()
        {



            return "";
        }

        private List<Monkey> GenerateMonkeys()
        {
            List<Monkey> monkeys = new();

            int i = 0;
            while(i < puzzleInput.Length)
            {
                string[] preItems = puzzleInput[i + 1].Split("items: ")[1].Split(", ");
                int[] items = new int[preItems.Length];
                for(int j = 0; j < preItems.Length; j++)
                {
                    items[j] = int.Parse(preItems[j]);
                }

                Monkey monkey = new(
                    items,
                    puzzleInput[i + 2].Split("new = ")[1],
                    int.Parse(puzzleInput[i + 3].Split("divisible by ")[1]),
                    int.Parse(puzzleInput[i + 4].Split("to monkey ")[1]),
                    int.Parse(puzzleInput[i + 5].Split("to monkey ")[1])
                    );

                monkeys.Add(monkey);
                i += 7;
            }

            return monkeys;
        }

        protected override string GetFolderName()
        {
            return "Day11";
        }
    }
}