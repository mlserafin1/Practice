using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class GameManager
    {
        private int guess = 0;
        private WordRepository _wordRepo;
        private char[] _guessedLetters;
        private string _answer;

        public int NumberOfGuess
        {
            get => default(int);
            set
            {
            }
        }

        public string Display
        {
            get => default(string);
            set
            {
            }
        }

        public GuessResult GuessLetter(char w)
        {
            // string answer = "hello";
            // char[] display = {'h','e','l','l','o'};
            // string x = new string(display);
            // 

            if (_answer.Contains("w"))
            {
                //TODO: display reveal answer

                if (/*Display == answer*/)
                {
                    return GuessResult.Win;
                }
                else
                {
                    guess++;
                    return GuessResult.Correct;
                }
            }
            else
            {
                guess++;
                if (guess < 6)
                {
                    return GuessResult.Incorrect;
                }
                else
                {
                    return GuessResult.Lose;
                }
            }
        }

        public void StartNewGame()
        {
            throw new System.NotImplementedException();
        }

        public void StartNewGame(string word)
        {
            throw new System.NotImplementedException();
        }
    }
}