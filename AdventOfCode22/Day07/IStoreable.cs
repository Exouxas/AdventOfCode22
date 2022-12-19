using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day07
{
    internal interface IStoreable
    {
        string Name { get; }
        int Size { get; }

        Directory Parent { get; set; }
    }
}
