using System.Linq;

namespace AdventOfCode22.Day07
{
    public class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            Navigator nav = BuildFilesystem();

            long sum = 0;

            foreach(Directory dir in nav.IterableDirectories)
            {
                int size = dir.Size;
                if (size <= 100000)
                {
                    sum += size;
                }
            }

            return "" + sum;
        }

        public override string GetPuzzleOutput2()
        {
            Navigator nav = BuildFilesystem();

            long maxSpace = 70000000;
            long neededSpace = 30000000;
            long usedSpace = nav.UsedSpace;
            long availableSpace = maxSpace - usedSpace;
            long toRemove = neededSpace - availableSpace;

            long bestFit = maxSpace;
            foreach(Directory dir in nav.IterableDirectories)
            {
                int size = dir.Size;
                if(size >= toRemove & size < bestFit)
                {
                    bestFit = size;
                }
            }

            return "" + bestFit;
        }

        private Navigator BuildFilesystem()
        {
            Navigator nav = new Navigator(new Directory("/"));

            foreach(string line in puzzleInput)
            {
                string[] parts = line.Split(' ');
                switch(parts[0])
                {
                    case "$":
                        if (parts[1].Equals("cd"))
                        {
                            nav.CD(parts[2]);
                        }
                        break;

                    case "dir":
                        nav.MKDIR(parts[1]);
                        break;

                    default:
                        nav.AddFile(parts[1], int.Parse(parts[0]));
                        break;
                }
            }

            return nav;
        }

        protected override string GetFolderName()
        {
            return "Day07";
        }
    }
}