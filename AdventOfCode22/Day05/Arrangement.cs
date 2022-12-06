using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day05
{
    internal class Arrangement
    {
        List<List<char>> cargoSlots;

        public Arrangement(List<string> list)
        {
            cargoSlots = new();

            list.Reverse();
            foreach(string s in list)
            {
                int i = 0;
                for (int slot = 1; slot < s.Length; slot += 4)
                {
                    if(i == cargoSlots.Count)
                    {
                        cargoSlots.Add(new List<char>());
                    }

                    if(s[slot] != ' ')
                    {
                        cargoSlots[i].Add(s[slot]);
                    }

                    i++;
                }
            }
        }

        public void MakeMove(Move move)
        {
            for(int i = 0; i < move.amount; i++)
            {
                cargoSlots[move.to].Add(cargoSlots[move.from].Last());
                cargoSlots[move.from].RemoveAt(cargoSlots[move.from].Count - 1);
            }
        }

        public void MultiMove(Move move)
        {
            for(int i = move.amount; i > 0; i--)
            {
                cargoSlots[move.to].Add(cargoSlots[move.from][cargoSlots[move.from].Count - i]);
            }
            for (int i = 0; i < move.amount; i++)
            {
                cargoSlots[move.from].RemoveAt(cargoSlots[move.from].Count - 1);
            }
        }

        public string GetTops()
        {
            StringBuilder sb = new StringBuilder();

            foreach(List<char> list in cargoSlots)
            {
                sb.Append(list.Last());
            }

            return sb.ToString();
        }
    }
}
