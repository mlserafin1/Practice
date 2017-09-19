using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.BLL;
using NUnit.Framework;

namespace GuessingGame.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        [Test]
        public void InvalidGuessTest()
        {
            GameManager gameInstance = new GameManager();
            gameInstance.Start();

            GuessResult actual = gameInstance.ProcessGuess(152);
            Assert.AreEqual(GuessResult.Invalid, actual);
        }

        [Test]
        public void VictoryGuessTest()
        {
            GameManager gameInstance = new GameManager();
            gameInstance.Start(2);

            GuessResult actual = gameInstance.ProcessGuess(2);
            Assert.AreEqual(GuessResult.Victory, actual);
        }

        [Test]
        public void HigherGuessTest()
        {
            GameManager gameInstance = new GameManager();
            gameInstance.Start(2);

            GuessResult actual = gameInstance.ProcessGuess(8);
            Assert.AreEqual(GuessResult.Higher, actual);
        }

        [Test]
        public void LowerGuessTest()
        {
            GameManager gameInstance = new GameManager();
            gameInstance.Start(8);

            GuessResult actual = gameInstance.ProcessGuess(2);
            Assert.AreEqual(GuessResult.Lower, actual);
        }
    }
}

