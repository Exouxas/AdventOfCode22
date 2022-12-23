using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day11
{
    internal class Monkey
    {
        public int[] Items { get; set; }
        public string Operation { get; set; }
        public int Divisible { get; set; }
        public int TrueThrow { get; set; }
        public int FalseThrow { get; set; }

        public Monkey(int[] Items, string Operation, int Divisible, int TrueThrow, int FalseThrow) 
        {
            this.Items = Items;
            this.Operation = Operation;
            this.Divisible = Divisible;
            this.TrueThrow = TrueThrow;
            this.FalseThrow = FalseThrow;
        }

        public int Op(int worry)
        {
            string[] parts = Operation.Split(" ");

            int p1;
            int p2;

            if (parts[0].Equals("old"))
            {
                p1 = worry;
            }
            else
            {
                p1 = int.Parse(parts[0]);
            }

            if (parts[2].Equals("old"))
            {
                p2 = worry;
            }
            else
            {
                p2 = int.Parse(parts[2]);
            }


            switch (parts[1])
            {
                case "+":
                    return p1 + p2;
                case "-":
                    return p1 - p2;
                case "*":
                    return p1 * p2;
                case "/":
                    return p1 / p2;
                default:
                    throw(new Exception("Fuq"));
            }
        }
    }
}
