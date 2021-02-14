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
        public int[,] result = new int[1,5];
        public int current_set;
        private string winner;
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
            result = new int[,] { { 0,0,0,0,0},{0,0,0,0,0 } };
            leftSide = player_1;
            rightSide = player_2;
            advantage = "Nothing";
            winner = "Nothing";
            current_set = 0;
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
        public void ClearAdvantage()
        {
            advantage = "Nothing";            
        }
        public void UpRound(Player player)
        {
            switch(player.Score(0))
            {
                case 0:
                    player.UpScore(0, 15);
                    break;
                case 15:
                    player.UpScore(0, 15);
                    break;
                case 30:
                    player.UpScore(0, 10);
                    break;
                case 40:
                    if (player.Name() == Player_1().Name())
                    {
                        if ( (Advantage() == Player_1().Name()) || (Player_2().Score(0) < 40))
                        {
                            Player_1().UpScore(1, 1);
                            Player_1().DownScore(0, 100); //To down to Zero. Bad design(
                            Player_2().DownScore(0, 100);
                            if (result[0, current_set] < 5)
                            {
                                result[0, current_set]++;
                                ClearAdvantage();
                            }
                            else
                            {
                                result[0, current_set]++;
                                current_set++;
                                Player_1().UpScore(2, 1);
                                Player_2().DownScore(1, 100); //To down to Zero. Bad design(
                                Player_1().DownScore(1, 100);
                                ClearAdvantage();
                            }
                        }
                        if (Advantage() == Player_2().Name())
                        {
                            ClearAdvantage();
                        }
                        string str = Advantage();
                        string str2 = "Nothing";
                        bool r = str.Equals(str2, StringComparison.OrdinalIgnoreCase);
                        if ( (r) && (Player_2().Score(0) == 40))
                        {
                            SetAdvantage(1);
                        }
                    }
                    else
                    {
                        if ( (Advantage() == Player_2().Name()) || (Player_1().Score(0) < 40) )
                        {
                            Player_2().UpScore(1, 1);
                            Player_2().DownScore(0, 100); //To down to Zero. Bad design(
                            Player_1().DownScore(0, 100);
                            if (result[1, current_set] < 5)
                            {
                                result[1, current_set]++;
                                ClearAdvantage();
                            }
                            else
                            {
                                result[1, current_set]++;
                                current_set++;
                                Player_2().UpScore(2, 1);
                                Player_2().DownScore(1, 100); //To down to Zero. Bad design(
                                Player_1().DownScore(1, 100);
                                ClearAdvantage();
                            }
                        }
                        if (Advantage() == Player_1().Name())
                        {
                            ClearAdvantage();
                        }
                        string str = Advantage();
                        string str2 = "Nothing";
                        bool r = str.Equals(str2, StringComparison.OrdinalIgnoreCase);
                        if ((r) && (Player_1().Score(0) == 40))
                        {
                            SetAdvantage(2);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
