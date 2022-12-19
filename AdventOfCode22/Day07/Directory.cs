using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day07
{
    internal class Directory : IStoreable
    {
        public string Name { get; }
        public List<IStoreable> Items { get; }
        public Directory Parent { get; set; }
        public int Size
        {
            get
            {
                int sum = 0;
                foreach(IStoreable item in Items)
                {
                    sum += item.Size;
                }

                return sum;
            }
        }

        public Directory(string name) 
        {
            Name = name;
            Items = new List<IStoreable>();
        }

        public void Add(IStoreable item)
        {
            Items.Add(item);
            item.Parent = this;
        }
    }
}
