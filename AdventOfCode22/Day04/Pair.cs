using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day04
{
    internal class Pair
    {
        public readonly Section section1;
        public readonly Section section2;

        public Pair(string s)
        {
            string[] parts = s.Split(',');

            string[] part1 = parts[0].Split("-");
            string[] part2 = parts[1].Split("-");

            section1 = new Section(int.Parse(part1[0]), int.Parse(part1[1]));
            section2 = new Section(int.Parse(part2[0]), int.Parse(part2[1]));
        }

        public bool IsContained()
        {
            return section1.Contains(section2) || section2.Contains(section1);
        }

        public bool Overlaps()
        {
            bool test1 = section1.start >= section2.start && section1.start <= section2.stop;
            bool test2 = section1.stop >= section2.start && section1.stop <= section2.stop;

            return test1 || test2 || IsContained();
        }
    }
}
