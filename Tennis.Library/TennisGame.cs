/* Library to Tennis application:
 * class Player - model of player, which iclude Name and 3-dimention-Score.
 * constructor: Player(string name)
 * methods: Name() - to get Name.
 * *        Score(int dim-index) - to get Score by index.
 *          UpScore(int dim-index, int value) - to up score by index. Only positive. No error, but no result too.
 *          DownScore(int dim-index, int value) - to down score by index. Only positive. No error, but no result too.
 * class TennisGame - model of game.
 * poles: two Players, winner (name of Player), Advantage (by player number), result (2-dim-array: player_number, score),
 *        current_set, left/right sides (class Player too).
 * constructor: TennisGame(string player1_name, string player2_name)
 * methods: 
 *          Getters: 
 *                  Player_1(), Player_2(), LeftSide(), RightSide(), Advantage(), Winner(), Ball().
 *          Other:
 *                  SetAdvantage(ind player_number), ClearAdvantage(), ChangeSides(), ChangeBall(),
 *                  CheckWinner() - write player name to winner,
 *                  UpRound(Player player) - all game logic, upscore.
 */

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
            result = new int[,] { { 0,0,0,0,0},{0,0,0,0,0} };
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
        public string Winner() { return winner; }
        public int Ball() { return ball; }

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
        
        public void ChangeBall()
        {
            if (ball == 1) { ball = 2; } //Player number
            else { ball = 1; }
        }
        public void ClearAdvantage() { advantage = "Nothing"; }
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
                        //Clear GAME
                        if ( (Advantage() == Player_1().Name()) || (Player_2().Score(0) < 40))
                        {
                            Player_1().UpScore(1, 1);
                            Player_1().DownScore(0, 100); //To down to Zero. Bad design(
                            Player_2().DownScore(0, 100);
                            if (result[0, current_set] < 5)
                            {
                                //Up RESULT and go NEXT GAME 
                                result[0, current_set]++;
                                ClearAdvantage();
                                ChangeBall();
                            }
                            else
                            {
                                //Up RESULT and go NEXT SET
                                result[0, current_set]++;
                                current_set++;
                                Player_1().UpScore(2, 1);
                                Player_2().DownScore(1, 100); //To down to Zero. Bad design(
                                Player_1().DownScore(1, 100);
                                ClearAdvantage();
                                ChangeBall();
                                ChangeSides();
                            }
                        }
                        //NOT CLEAR GAME 40/40
                        string str = Advantage();
                        string str2 = "Nothing";
                        bool r = str.Equals(str2, StringComparison.OrdinalIgnoreCase);
                        if ( (r) && (Player_2().Score(0) == 40))
                        {
                            SetAdvantage(1);
                        }
                        //NOT CLEAR GAME 40/AD - for another player
                        if (Advantage() == Player_2().Name())
                        {
                            ClearAdvantage();
                        }
                    }
                    else /*The same to another player. 
                          * Yes, I can remove this, but it will increase the difficulty,
                          * and in the current conditions it is not required, I think */
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
                                ChangeBall();
                            }
                            else
                            {
                                result[1, current_set]++;
                                current_set++;
                                Player_2().UpScore(2, 1);
                                Player_2().DownScore(1, 100); //To down to Zero. Bad design(
                                Player_1().DownScore(1, 100);
                                ClearAdvantage();
                                ChangeBall();
                                ChangeSides();
                            }
                        }
                        string str = Advantage();
                        string str2 = "Nothing";
                        bool r = str.Equals(str2, StringComparison.OrdinalIgnoreCase);
                        if ((r) && (Player_1().Score(0) == 40))
                        {
                            SetAdvantage(2);
                        }
                        if (Advantage() == Player_1().Name())
                        {
                            ClearAdvantage();
                        }
                    }
                    break;
                default:
                    break;
            }
            CheckWinner();
        }

        public void CheckWinner()
        {
            if(Player_1().Score(2) == 3) { winner = Player_1().Name(); return; }
            if(Player_2().Score(2) == 3) { winner = Player_2().Name(); return; }
        }
    }
}
