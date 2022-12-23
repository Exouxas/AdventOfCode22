using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day09
{
    internal class Navigator
    {
        public Position HeadPos { get; set; }
        public Position TailPos { get; set; }

        public Dictionary<Position, bool> Visited { get; }


        public Navigator()
        {
            HeadPos = new(0, 0);
            TailPos = new(0, 0);
            Visited = new Dictionary<Position, bool>();
            Visited.Add(TailPos, true);
        }

        public void Move(int x, int y)
        {
            Move(new Position(x, y));
        }

        public void Move(Position pos)
        {
            HeadPos += pos;

            while (!IsTouching(HeadPos, TailPos))
            {
                FixTail();
            }
        }

        public void MoveTo(Position pos)
        {
            HeadPos = pos;

            while(!IsTouching(HeadPos, TailPos))
            {
                FixTail();
            }
        }

        private void FixTail()
        {
            Position dist = Distance(HeadPos, TailPos);

            if (dist.X == 0)
            {
                // Move straight Vertical
                TailPos -= new Position(0, dist.Y / Math.Abs(dist.Y));
            }
            else if (dist.Y == 0)
            {
                // Move straight Horizontal
                TailPos -= new Position(dist.X / Math.Abs(dist.X), 0);
            }
            else
            {
                // Move diagonal
                TailPos -= new Position(dist.X / Math.Abs(dist.X), dist.Y / Math.Abs(dist.Y));
            }

            if (!Visited.ContainsKey(TailPos))
            {
                Visited.Add(TailPos, true);
            }
        }

        private void FixTailBU()
        {
            Position dist = Distance(HeadPos, TailPos);

            if (dist.X == 0)
            {
                // Move straight Vertical
                TailPos -= new Position(0, dist.Y / Math.Abs(dist.Y));
            }
            else if (dist.Y == 0)
            {
                // Move straight Horizontal
                TailPos -= new Position(dist.X / Math.Abs(dist.X), 0);
            }
            else
            {
                // Move diagonal
                TailPos -= new Position(dist.X / Math.Abs(dist.X), dist.Y / Math.Abs(dist.Y));
            }

            if (!Visited.ContainsKey(TailPos))
            {
                Visited.Add(TailPos, true);
            }
        }

        private bool IsTouching(Position p1, Position p2)
        {
            Position dist = Distance(p1, p2);


            return Math.Abs(dist.X) <= 1 & Math.Abs(dist.Y) <= 1;
        }

        private Position Distance(Position p1, Position p2)
        {
            return new Position(p2.X - p1.X, p2.Y - p1.Y);
        }
    }
}
