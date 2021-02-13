using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Library.Tests
{
    [TestFixture]
    public class TennisTests
    {
        //************
        //PLAYER TESTS
        //************

        [Test]
        public void CreatePlayerName()
        {
            Player player = new Player("Name");
            Assert.IsTrue(player.Name() == "Name");
        }

        // For FIRST SCORE
        [Test]
        public void CreatePlayerScore()
        {
            Player player = new Player("Name");
            Assert.IsTrue(player.Score(0) == 0);
        }

        [Test]
        public void UpPlayerScoreOne()
        {
            Player player = new Player("Name");
            player.UpScore(0, 1);
            Assert.IsTrue(player.Score(0) == 1);
        }
        [Test]
        public void UpPlayerScoreMany()
        {
            Player player = new Player("Name");
            player.UpScore(0, 12);
            Assert.IsTrue(player.Score(0) == 12);
        }

        [Test]
        public void UpPlayerScoreDaun()
        {
            Player player = new Player("Name");
            player.UpScore(0, 12);
            player.UpScore(0, -1);
            Assert.IsTrue(player.Score(0) == 12);
        }
        [Test]
        public void UpPlayerScoreZero()
        {
            Player player = new Player("Name");
            player.UpScore(0, 12);
            player.UpScore(0, 0);
            Assert.IsTrue(player.Score(0) == 12);
        }
        [Test]
        public void DawnPlayerScoreOne()
        {
            Player player = new Player("Name");
            player.UpScore(0, 2);
            player.DownScore(0, 1);
            Assert.IsTrue(player.Score(0) == 1);
        }
        [Test]
        public void DawnPlayerScoreMany()
        {
            Player player = new Player("Name");
            player.UpScore(0, 5);
            player.DownScore(0, 2);
            Assert.IsTrue(player.Score(0) == 3);
        }
        [Test]
        public void DawnPlayerScoreZero()
        {
            Player player = new Player("Name");
            player.UpScore(0, 5);
            player.DownScore(0, 0);
            Assert.IsTrue(player.Score(0) == 5);
        }
        [Test]
        public void DawnPlayerScoreToZero()
        {
            Player player = new Player("Name");
            player.UpScore(0, 5);
            player.DownScore(0, 5);
            Assert.IsTrue(player.Score(0) == 0);
        }
        [Test]
        public void DawnPlayerScoreToZeroOverflow()
        {
            Player player = new Player("Name");
            player.UpScore(0, 5);
            player.DownScore(0, 7);
            Assert.IsTrue(player.Score(0) == 0);
        }

        [Test]
        public void DownPlayerScoreUp()
        {
            Player player = new Player("Name");
            player.UpScore(0, 12);
            player.DownScore(0, -1);
            Assert.IsTrue(player.Score(0) == 12);
        }

        // For SECOND SCORE
        
        [Test]
        public void CreatePlayerScore2()
        {
            Player player = new Player("Name");
            Assert.IsTrue(player.Score(1) == 0);
        }

        [Test]
        public void UpPlayerScoreOne2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 1);
            Assert.IsTrue(player.Score(1) == 1);
        }
        [Test]
        public void UpPlayerScoreMany2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 12);
            Assert.IsTrue(player.Score(1) == 12);
        }

        [Test]
        public void UpPlayerScoreDaun2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 12);
            player.UpScore(1, -1);
            Assert.IsTrue(player.Score(1) == 12);
        }
        [Test]
        public void UpPlayerScoreZero2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 12);
            player.UpScore(1, 0);
            Assert.IsTrue(player.Score(1) == 12);
        }
        [Test]
        public void DawnPlayerScoreOne2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 2);
            player.DownScore(1, 1);
            Assert.IsTrue(player.Score(1) == 1);
        }
        [Test]
        public void DawnPlayerScoreMany2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 5);
            player.DownScore(1, 2);
            Assert.IsTrue(player.Score(1) == 3);
        }
        [Test]
        public void DawnPlayerScoreZero2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 5);
            player.DownScore(1, 0);
            Assert.IsTrue(player.Score(1) == 5);
        }
        [Test]
        public void DawnPlayerScoreToZero2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 5);
            player.DownScore(1, 5);
            Assert.IsTrue(player.Score(1) == 0);
        }
        [Test]
        public void DawnPlayerScoreToZeroOverflow2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 5);
            player.DownScore(1, 7);
            Assert.IsTrue(player.Score(1) == 0);
        }

        [Test]
        public void DownPlayerScoreUp2()
        {
            Player player = new Player("Name");
            player.UpScore(1, 12);
            player.DownScore(1, -1);
            Assert.IsTrue(player.Score(1) == 12);
        }

        // For Third SCORE

        [Test]
        public void CreatePlayerScore3()
        {
            Player player = new Player("Name");
            Assert.IsTrue(player.Score(2) == 0);
        }

        [Test]
        public void UpPlayerScoreOne3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 1);
            Assert.IsTrue(player.Score(2) == 1);
        }
        [Test]
        public void UpPlayerScoreMany3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 12);
            Assert.IsTrue(player.Score(2) == 12);
        }

        [Test]
        public void UpPlayerScoreDaun3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 12);
            player.UpScore(2, -1);
            Assert.IsTrue(player.Score(2) == 12);
        }
        [Test]
        public void UpPlayerScoreZero3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 12);
            player.UpScore(2, 0);
            Assert.IsTrue(player.Score(2) == 12);
        }
        [Test]
        public void DawnPlayerScoreOne3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 2);
            player.DownScore(2, 1);
            Assert.IsTrue(player.Score(2) == 1);
        }
        [Test]
        public void DawnPlayerScoreMany3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 5);
            player.DownScore(2, 2);
            Assert.IsTrue(player.Score(2) == 3);
        }
        [Test]
        public void DawnPlayerScoreZero3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 5);
            player.DownScore(2, 0);
            Assert.IsTrue(player.Score(2) == 5);
        }
        [Test]
        public void DawnPlayerScoreToZero3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 5);
            player.DownScore(2, 5);
            Assert.IsTrue(player.Score(2) == 0);
        }
        [Test]
        public void DawnPlayerScoreToZeroOverflow3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 5);
            player.DownScore(2, 7);
            Assert.IsTrue(player.Score(2) == 0);
        }

        [Test]
        public void DownPlayerScoreUp3()
        {
            Player player = new Player("Name");
            player.UpScore(2, 12);
            player.DownScore(2, -1);
            Assert.IsTrue(player.Score(2) == 12);
        }

        // For OUT OF RANGE SCORE

        [Test]
        public void CreatePlayerScoreOut()
        {
            Player player = new Player("Name");
            Assert.IsTrue(player.Score(12) == 0);
        }

        [Test]
        public void UpPlayerScoreOneOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 1);
            Assert.IsTrue(player.Score(12) == 0);
        }
        [Test]
        public void UpPlayerScoreManyOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 12);
            Assert.IsTrue(player.Score(12) == 0);
        }

        [Test]
        public void UpPlayerScoreDaunOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 12);
            player.UpScore(12, -1);
            Assert.IsTrue(player.Score(12) == 0);
        }
        [Test]
        public void UpPlayerScoreZeroOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 12);
            player.UpScore(12, 0);
            Assert.IsTrue(player.Score(12) == 0);
        }
        [Test]
        public void DawnPlayerScoreOneOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 2);
            player.DownScore(12, 1);
            Assert.IsTrue(player.Score(12) == 0);
        }
        [Test]
        public void DawnPlayerScoreManyOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 5);
            player.DownScore(12, 2);
            Assert.IsTrue(player.Score(12) == 0);
        }
        [Test]
        public void DawnPlayerScoreZeroOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 5);
            player.DownScore(12, 0);
            Assert.IsTrue(player.Score(12) == 0);
        }
        [Test]
        public void DawnPlayerScoreToZeroOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 5);
            player.DownScore(12, 5);
            Assert.IsTrue(player.Score(12) == 0);
        }
        [Test]
        public void DawnPlayerScoreToZeroOverflowOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 5);
            player.DownScore(12, 7);
            Assert.IsTrue(player.Score(12) == 0);
        }

        [Test]
        public void DownPlayerScoreUpOut()
        {
            Player player = new Player("Name");
            player.UpScore(12, 12);
            player.DownScore(12, -1);
            Assert.IsTrue(player.Score(12) == 0);
        }

        //************
        //GAME-LOGIC TESTS
        //************
        
        [Test]
        public void PlayersCorrectly()
        {
            TennisGame game = new TennisGame("Name_1", "Name_2");
            Assert.IsTrue(game.Player_1().Name() == "Name_1");
            Assert.IsTrue(game.Player_2().Name() == "Name_2");
        }
        public void PlayersDifferent()
        {
            TennisGame game = new TennisGame("Eman", "Eman");
            Assert.IsTrue(game.Player_1().Name() == "Eman_1");
            Assert.IsTrue(game.Player_2().Name() == "Eman_2");
        }
        [Test]
        public void BallOnFirst()
        {
            TennisGame game = new TennisGame("Name_1", "Name_2");
            Assert.IsTrue(game.Ball() == 1);
        }

        [Test]
        public void StartAdvantage()
        {
            TennisGame game = new TennisGame("Name_1", "Name_2");
            Assert.IsTrue(game.Advantage() == "Nothng");
            //We use player name or nothing to avoid creation third player
        }
        [Test]
        public void SetAdvantage()
        {
            TennisGame game = new TennisGame("Name_1", "Name_2");
            game.SetAdvantage(1);
            Assert.IsTrue(game.Advantage() == game.Player_1().Name());
        }

        [Test]
        public void StartLeftSide()
        {
            TennisGame game = new TennisGame("Name_1", "Name_2");
            Assert.IsTrue(game.LeftSide() == game.Player_1());            
        }
        [Test]
        public void StartRightSide()
        {
            TennisGame game = new TennisGame("Name_1", "Name_2");
            Assert.IsTrue(game.RightSide() == game.Player_2());            
        }
        [Test]
        public void ChangeSides()
        {
            TennisGame game = new TennisGame("Name_1", "Name_2");
            game.ChangeSides();
            Assert.IsTrue( (game.LeftSide() == game.Player_2()) && (game.RightSide() == game.Player_1()) ) ;            
        }
        public void ChangeBall()
        {
            TennisGame game = new TennisGame("Name_1", "Name_2");
            game.ChangeBall(2);
            Assert.IsTrue(game.Ball() == 2);
        }

    }
}
