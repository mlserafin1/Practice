using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuessingGame.BLL
{
    public class GameManager
    {
        private int _theAnswer;
        public GuessResult ProcessGuess(int guess)
        {
            if (!IsValid(guess)) //can also be written as if(IsValid(guess) == false)
            {
                return GuessResult.Invalid;
            }
            if (_theAnswer == guess)
            {
                return GuessResult.Victory;
            }
            else if (_theAnswer > guess)
            {
                return GuessResult.Lower;
            }
            else
            {
                return GuessResult.Higher;
            }
        }
        public bool IsValid(int guess)
        {
            bool result = false;
            if(guess >=1 && guess < 21)
            {
                result = true;
                
            }
            return result;
        }
        public int CreateRandomAnswer()
        {
            Random r = new Random();
            return r.Next(1, 21);
        }
        public void Start()
        {
            _theAnswer = CreateRandomAnswer();
        }

        public void Start(int answer)
        {
            _theAnswer = answer;
        }
    }
}
