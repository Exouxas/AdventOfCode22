using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Day02
{
    internal class RPSGame
    {
        public int Points
        {
            get 
            {
                int points = 0;

                switch (hand)
                {
                    case Hand.Rock:
                        points = 1;
                        break;
                    case Hand.Paper:
                        points = 2;
                        break;
                    case Hand.Scissors:
                        points = 3;
                        break;
                }

                if(opponent == hand)
                {
                    points += 3;
                }
                else
                {
                    if (hand == Hand.Rock & opponent == Hand.Scissors) { points += 6; }
                    if (hand == Hand.Paper & opponent == Hand.Rock) { points += 6; }
                    if (hand == Hand.Scissors & opponent == Hand.Paper) { points += 6; }
                }


                return points; 
            }
        }

        public Hand opponent;
        public Hand hand;

        public RPSGame(Hand opponent, Hand hand) 
        { 
            this.opponent = opponent;
            this.hand = hand;
        }
    }

    public enum Hand
    {
        Rock,
        Paper,
        Scissors
    }
}
