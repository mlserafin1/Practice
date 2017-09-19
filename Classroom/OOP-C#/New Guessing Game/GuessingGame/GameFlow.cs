using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.BLL;

namespace GuessingGame
{
    public class GameFlow
    {
        public void PlayGame()
        {
            GameManager manager = new GameManager();
            manager.Start();


            int playerGuess;
            string playerInput;

            GuessResult result = GuessResult.Invalid;

            do
            {
                // get player input
                Console.Write("Enter your guess (1-20): ");
                playerInput = Console.ReadLine();

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    result = manager.ProcessGuess(playerGuess);
                    switch (result)
                    {

                        case GuessResult.Lower:
                            Console.WriteLine("Your guess was too low!");
                            break;
                        case GuessResult.Higher:
                            Console.WriteLine("Your guess was too High!");
                            break;
                        case GuessResult.Victory:
                            Console.WriteLine($"{playerGuess} was the number.  You Win!");
                            break;
                        case GuessResult.Invalid:
                            Console.WriteLine("Your guess was invalid!");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("That wasn't a number!");
                }

            } while (result != GuessResult.Victory);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
