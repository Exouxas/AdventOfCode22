using System.Linq;

namespace AdventOfCode22.Day08
{
    public class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            int sum = 0;

            List<List<int>> map = MakeMap();
            List<List<bool>> visible = new();
            foreach(List<int> row in map)
            {
                List<bool> list = new();

                for(int i = 0; i < row.Count; i++)
                {
                    list.Add(false);
                }

                visible.Add(list);
            }

            SetVisible(map, visible);


            map = RotateMap(map);
            visible = RotateMap(visible);
            SetVisible(map, visible);

            map = RotateMap(map);
            visible = RotateMap(visible);
            SetVisible(map, visible);

            map = RotateMap(map);
            visible = RotateMap(visible);
            SetVisible(map, visible);

            foreach(List<bool> row in visible)
            {
                foreach(bool b in row)
                {
                    if (b) { sum++; }
                }
            }

            return "" + sum;
        }


        public override string GetPuzzleOutput2()
        {
            List<List<int>> map = MakeMap();

            int highestScore = 0;

            for(int row = 0; row < map.Count; row++)
            {
                for(int col = 0; col < map[0].Count; col++)
                {
                    int house = map[row][col];

                    int treesUp = row;
                    int treesDown = map.Count - row - 1;
                    int treesLeft = col;
                    int treesRight = map[row].Count - col - 1;


                    // Check up
                    int sumUp = 0;
                    for (int i = 1; i <= treesUp; i++)
                    {
                        int check = map[row - i][col];

                        sumUp++;
                        if (check >= house)
                        {
                            break;
                        }
                    }

                    // Check down
                    int sumDown = 0;
                    for (int i = 1; i <= treesDown; i++)
                    {
                        int check = map[row + i][col];

                        sumDown++;
                        if (check >= house)
                        {
                            break;
                        }
                    }

                    // Check left
                    int sumLeft = 0;
                    for (int i = 1; i <= treesLeft; i++)
                    {
                        int check = map[row][col - i];

                        sumLeft++;
                        if (check >= house)
                        {
                            break;
                        }
                    }

                    // Check right
                    int sumRight = 0;
                    for (int i = 1; i <= treesRight; i++)
                    {
                        int check = map[row][col + i];

                        sumRight++;
                        if (check >= house)
                        {
                            break;
                        }
                    }


                    int score = sumUp * sumDown * sumLeft * sumRight;

                    if(score > highestScore)
                    {
                        highestScore = score;
                    }
                }
            }

            return "" + highestScore;
        }

        private void SetVisible(List<List<int>> map, List<List<bool>> visible)
        {
            for(int row = 0; row < map.Count; row++)
            {
                int highest = -1;
                for(int i = 0; i < map[row].Count; i++)
                {
                    int height = map[row][i];
                    if (height > highest)
                    {
                        visible[row][i] = true;
                        highest = height;
                    }
                }
            }
        }

        private List<List<T>> RotateMap<T>(List<List<T>> map)
        {
            List<List<T>> newMap = new();


            foreach(T tree in map[0])
            {
                newMap.Add(new List<T> { tree });
            }

            for(int i = 1; i < map.Count; i++)
            {
                for(int row = 0; row < newMap.Count; row++)
                {
                    newMap[row].Insert(0, map[i][row]);
                }
            }

            return newMap;
        }

        private List<List<T>> FlipMap<T>(List<List<T>> map)
        {
            List<List<T>> newMap = new();

            foreach (List<T> row in map)
            {
                List<T> newRow = new();

                foreach(T i in row)
                {
                    newRow.Insert(0, i);
                }

                newMap.Add(newRow);
            }

            return newMap;
        }

        private List<List<int>> MakeMap()
        {
            List<List<int>> rv = new();

            foreach (string s in puzzleInput)
            {
                List<int> row = new();

                foreach(char c in s)
                {
                    row.Add(int.Parse("" + c));
                }

                rv.Add(row);
            }

            return rv;
        }

        protected override string GetFolderName()
        {
            return "Day08";
        }
    }
}