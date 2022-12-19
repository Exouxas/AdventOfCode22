using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day07
{
    internal class Navigator
    {
        public Directory Root { get; }
        public Directory CurrentDirectory { get; set; }
        public List<Directory> IterableDirectories { get; }
        public long UsedSpace = 0;

        public Navigator(Directory root)
        {
            this.Root = root;
            this.CurrentDirectory = root;

            IterableDirectories = new List<Directory>();
            IterableDirectories.Add(root);
        }

        public void CD(string path)
        {
            switch (path)
            {
                case "..":
                    CurrentDirectory = CurrentDirectory.Parent;
                    break;

                case "/":
                    CurrentDirectory = Root;
                    break;

                default:
                    foreach (IStoreable store in CurrentDirectory.Items)
                    {
                        if (store.Name.Equals(path) & store is Directory)
                        {
                            CurrentDirectory = (Directory)store;
                        }
                    }
                    break;
            }
        }

        public void MKDIR(string path)
        {
            Directory dir = new Directory(path);
            CurrentDirectory.Add(dir);
            IterableDirectories.Add(dir);
        }

        public void AddFile(string name, int size)
        {
            CurrentDirectory.Add(new File(name, size));
            UsedSpace += size;
        }
    }
}
