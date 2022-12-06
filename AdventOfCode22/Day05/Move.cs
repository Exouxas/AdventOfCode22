using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day05
{
    internal class Move
    {
        public readonly int from;
        public readonly int to;
        public readonly int amount;

        public Move(string s)
        {
            string[] parts = s.Split(' ');
            amount = int.Parse(parts[1]);
            from = int.Parse(parts[3]) - 1;
            to = int.Parse(parts[5]) - 1;
        }
    }
}
