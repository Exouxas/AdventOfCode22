using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day07
{
    internal class File : IStoreable
    {
        public string Name { get; }
        public int Size { get; }
        public Directory Parent { get; set; }

        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
