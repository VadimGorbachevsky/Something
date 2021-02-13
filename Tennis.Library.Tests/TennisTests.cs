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
        [Test]
        public void CreatePlayerName()
        {
            Player player = new Player("Name");
            Assert.IsTrue(player.Name() == "Name");
        }
        [Test]
        public void CreatePlayerScore()
        {
            Player player = new Player("Name");
            Assert.IsTrue(player.Score() == 0);
        }

        [Test]
        public void UpPlayerScoreOne()
        {
            //mb use by one point, and game logic (10-15 score in game class)
            Player player = new Player("Name");
            player.UpScore(1);
            Assert.IsTrue(player.Score() == 1);
        }
        [Test]
        public void UpPlayerScoreMany()
        {
            Player player = new Player("Name");
            player.UpScore(12);
            Assert.IsTrue(player.Score() == 12);
        }

        [Test]
        public void UpPlayerScoreDaun()
        {
            Player player = new Player("Name");
            player.UpScore(12);
            player.UpScore(-1);
            Assert.IsTrue(player.Score() == 12);
        }
        public void UpPlayerScoreZero()
        {
            Player player = new Player("Name");
            player.UpScore(12);
            player.UpScore(0);
            Assert.IsTrue(player.Score() == 12);
        }

        //Convert to Game-logic
        [Test]
        public void PlayerScoreСeiling()
        {

            Player player = new Player("Name");
            player.UpScore();
            player.UpScore();
            player.UpScore();
            player.UpScore();
            Assert.IsTrue(player.Score() == 40);
        }

        //Convert to Game-logic too
        [Test]
        public void PlayerAdvantageOn()
        {
            Player player = new Player("Name");
            player.UpScore();
            player.UpScore();
            player.UpScore();
            Assert.IsTrue(player.Score() == 40);
            player.UpScore();
            Assert.IsTrue(player.Score() == 40);
        }

        [Test]
        public void PlayerScoreСeiling()
        {
            TennisGame game = new TennisGame();
            //In progress
            //game.PlayerFirst()
            //game.PlayerSecond.Score()
            //game.SideLaft()
            //game.sideRight()
            //Assert.IsTrue(player.Score() == 40);
        }


    }
}
