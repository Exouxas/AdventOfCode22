using AdventOfCode22;
using System;

namespace AdventOfCode22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdventSolver solver = new Day07.Solver();
            Console.WriteLine("Part 1: " + solver.GetPuzzleOutput1());
            Console.WriteLine("Part 2: " + solver.GetPuzzleOutput2());
        }
    }
}