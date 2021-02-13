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

        public string Name() { return name; }
        
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
        private string advantage;
        private int ball;
        Player player_1;
        Player player_2;
        Player leftSide;
        Player rightSide;

        public TennisGame(string name_1, string name_2)
        {
            if (name_1 == name_2)
            {
                player_1 = new Player(name_1 + "_1");
                player_2 = new Player(name_2 + "_2");
            }
            else
            {
                player_1 = new Player(name_1);
                player_2 = new Player(name_2);
            }
            advantage = "Nothng";
            leftSide  = player_1;
            rightSide = player_2;
            ball = 1;
        }

        public Player Player_1()  { return player_1; }
        public Player Player_2()  { return player_2; }
        public Player LeftSide()  { return leftSide; }
        public Player RightSide() { return rightSide; }
        public string Advantage() { return advantage; }

        public void ChangeSides()
        {
            Player buffer = leftSide;
            leftSide = rightSide;
            rightSide = buffer;
        }
        public void SetAdvantage(int player_number)
        {
            if (player_number == 1) { advantage = player_1.Name(); }
            if (player_number == 2) { advantage = player_2.Name(); }
        }
        public int Ball() { return ball; }
        public void ChangeBall(int player_number)
        {
            if ( (player_number == 1) || (player_number == 2 ) )
            {
                ball = player_number; 
            }
        }
    }
}
