using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public abstract class AdventSolver
    {
        protected string[] puzzleInput;
        public AdventSolver()
        {
            puzzleInput = File.ReadAllLines("../../../" + GetFolderName() + "/PuzzleInput.txt");
        }

        protected abstract string GetFolderName();
        public abstract string GetPuzzleOutput1();
        public abstract string GetPuzzleOutput2();
    }
}
