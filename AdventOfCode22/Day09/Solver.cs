using System.Linq;

namespace AdventOfCode22.Day09
{
    public class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            Navigator nav = new Navigator();

            foreach(string s in puzzleInput)
            {
                string[] split = s.Split(' ');
                string direction = split[0];
                int length = int.Parse(split[1]);

                switch (direction)
                {
                    case "U":
                        nav.Move(0, -length);
                        break;

                    case "D":
                        nav.Move(0, length);
                        break;

                    case "L":
                        nav.Move(-length, 0);
                        break;

                    case "R":
                        nav.Move(length, 0);
                        break;
                }
            }

            return "" + nav.Visited.Count;
        }


        public override string GetPuzzleOutput2()
        {
            int tailLength = 9;

            List<Navigator> nav = new();
            for(int i = 0; i < tailLength; i++)
            {
                nav.Add(new Navigator());
            }

            foreach (string s in puzzleInput)
            {
                string[] split = s.Split(' ');
                string direction = split[0];
                int length = int.Parse(split[1]);
                for(int n = 0; n < length; n++){
                    switch (direction)
                    {
                        case "U":
                            nav[0].Move(0, -1);
                            break;

                        case "D":
                            nav[0].Move(0, 1);
                            break;

                        case "L":
                            nav[0].Move(-1, 0);
                            break;

                        case "R":
                            nav[0].Move(1, 0);
                            break;
                    }

                    for (int i = 1; i < tailLength; i++)
                    {
                        nav[i].MoveTo(nav[i - 1].TailPos);
                    }
                }
                

                //Console.WriteLine(s + ":");
                //List<List<char>> ropeGrid = DrawNavs(nav);
                //List<List<char>> vGrid = DrawVisited(nav.Last().Visited);

            }

            return "" + nav.Last().Visited.Count;
        }

        private List<List<char>> DrawVisited(Dictionary<Position, bool> visited)
        {
            // Figure out the scale
            int left = 0;
            int right = 0;
            int up = 0;
            int down = 0;

            foreach(Position pos in visited.Keys)
            {
                if (pos.X < -left) { left = -pos.X; }
                if (pos.X > right) { right = pos.X; }
                if (pos.Y < -up) { up= -pos.Y; }
                if (pos.Y > down) { down = pos.Y; }
            }

            int width = left + right + 1;
            int height = up + down + 1;

            // Make a grid
            List<List<char>> grid = new();
            for (int row = 0; row < height; row++)
            {
                List<char> toDraw = new();
                for (int col = 0; col < width; col++)
                {
                    toDraw.Add('.');
                }
                grid.Add(toDraw);
            }

            foreach(Position pos in visited.Keys)
            {
                grid[pos.Y + up][pos.X + left] = '#';
            }

            // Draw based on list
            Console.WriteLine();
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Console.Write(grid[row][col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            return grid;
        }

        private List<List<char>> DrawNavs(List<Navigator> nav)
        {
            // Figure out the scale
            int left = 0;
            int right = 0;
            int up = 0;
            int down = 0;

            foreach (Navigator n in nav)
            {
                if (n.HeadPos.X < -left)
                {
                    left = -n.HeadPos.X;
                }
                if (n.TailPos.X < -left)
                {
                    left = -n.TailPos.X;
                }

                if (n.HeadPos.X > right)
                {
                    right = n.HeadPos.X;
                }
                if (n.TailPos.X > right)
                {
                    right = n.TailPos.X;
                }

                if (n.HeadPos.Y < -up)
                {
                    up = -n.HeadPos.Y;
                }
                if (n.TailPos.Y < -up)
                {
                    up = -n.TailPos.Y;
                }

                if (n.HeadPos.Y > down)
                {
                    down = n.HeadPos.Y;
                }
                if (n.TailPos.Y > down)
                {
                    down = n.TailPos.Y;
                }
            }

            int width = left + right + 1;
            int height = up + down + 1;

            // Make a grid
            List<List<char>> grid = new();
            for (int row = 0; row < height; row++)
            {
                List<char> toDraw = new();
                for (int col = 0; col < width; col++)
                {
                    toDraw.Add('.');
                }
                grid.Add(toDraw);
            }

            // Add navigators
            for (int i = nav.Count - 1; i >= 0; i--)
            {
                grid[nav[i].TailPos.Y + up][nav[i].TailPos.X + left] = (i + 1).ToString()[0];
            }
            grid[nav[0].HeadPos.Y + up][nav[0].HeadPos.X + left] = 'H';

            // Draw based on list
            Console.WriteLine();
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Console.Write(grid[row][col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            return grid;
        }

        protected override string GetFolderName()
        {
            return "Day09";
        }
    }
}