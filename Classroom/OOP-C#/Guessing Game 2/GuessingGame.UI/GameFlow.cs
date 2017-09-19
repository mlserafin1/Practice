﻿using GuessingGame.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.UI
{
    public class GameFlow
    {
        GameManager _manager;

        public void PlayGame()
        {
            CreateGameManagerInstance();
            ConsoleOutput.DisplayTitle();

            GuessResult result;
            int guess;

            do
            {
                guess = ConsoleInput.GetGuessFromUser();
                result = _manager.ProcessGuess(guess);
                ConsoleOutput.DisplayGuessMessage(result);
            } while (result != GuessResult.Victory);
        }

        private void CreateGameManagerInstance()
        {
            _manager = new GameManager();
            _manager.Start();
        }
    }
}
