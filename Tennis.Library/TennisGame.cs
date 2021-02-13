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
        private int[] score = new int[2];
        public Player(string name_arg)
        {
            name = name_arg;
            score = new int[] { 0, 0, 0};
        }

        public string Name()
        {
            return name;
        }
        
        public int Score(int ind)
        {
            if ((ind < 0) || (ind > 2)) { return 0; }
            return score[ind];
        }

        public void UpScore(int ind, int modifier)
        {
            if ((ind < 0) || (ind > 2)) { return; }
            if (modifier < 0) { return; }
            score[ind] += modifier;
        }

        public void DownScore(int ind, int modifier)
        {
            if ((ind < 0) || (ind > 2)) { return; }
            if (modifier < 0) { return; }

            int temp_result = score[ind] - modifier;
            if (temp_result < 0) 
            {
                score[ind] = 0;
                return;
            }
            score[ind] = temp_result;
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
