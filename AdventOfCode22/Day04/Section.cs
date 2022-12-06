using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day04
{
    internal class Section
    {
        public readonly int start;
        public readonly int stop;
        public readonly int[] range;

        public Section(int start, int stop)
        {
            this.start = start;
            this.stop = stop;
            int[] values = new int[stop - start + 1];
            for(int i = 0; i < values.Length; i++)
            {
                values[i] = start + i;
            }
            this.range = values;
        }

        public bool Contains(Section s)
        {
            return start <= s.start && stop >= s.stop;
        }

        public override string ToString()
        {
            return $"{start}-{stop}";
        }
    }
}
