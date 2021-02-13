using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Library
{
    public class Player
    {
        private string name;
        private int score, score1, score3;
        public Player(string name_arg)
        {
            name = name_arg;
        }

        public string Name()
        {
            return name;
        }
        
        public int Score()
        {
            return score;
        }

        public void UpScore(int modifier)
        {
            if (modifier < 0) { return; }
            score += modifier;
        }

        public void DownScore(int modifier)
        {
            if (modifier < 0) { return; }

            int temp_result = score - modifier;
            if (temp_result < 0) 
            {
                score = 0;
                return;
            }
            score = temp_result;
        }
    }
    public class TennisGame
    {
        private string v1;
        private string v2;

        public TennisGame(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
