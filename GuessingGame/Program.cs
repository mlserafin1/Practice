using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess;
            string playerInput;
            int temp;
            int limit;
            string playerName;
            int count = 0;



            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter your name: ");
            playerName = Console.ReadLine();



            while(true)
            {
                Console.WriteLine($"{playerName}, choose your difficulty level (1-3): ");
                if (int.TryParse(Console.ReadLine(), out temp) && temp > 0 && temp < 4)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{playerName}, the number must be between 1 and 3!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


            int Difficulty(int x)
            {
                if (x == 1)
                {
                    limit = 5;
                    return 6;
                }
                else if (x == 2)
                {
                    limit = 20;
                    return 21;
                }
                else if (x == 3)
                {
                    limit = 50;
                    return 51;
                }
                else
                {
                    limit = 0;
                    return 0;
                }
            }

            Random r = new Random();
            theAnswer = r.Next(1, Difficulty(temp));

            Console.WriteLine("Press Q to quit at any time.");

            do
            {
                // get player input
                Console.Write($"{playerName}, enter your guess (1-{limit}): ");
                playerInput = Console.ReadLine();
                count++;
                if (playerInput == "Q" || playerInput == "q")
                {
                    break;
                }

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    if (playerGuess <= 0 || playerGuess > limit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{playerName}, your guess must be between 1 and {limit}.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (playerGuess == theAnswer && count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{theAnswer} was it! You guessed the answer on the first try!!!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else if (playerGuess == theAnswer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{theAnswer} was the number.  You Win!");
                        Console.WriteLine($"You guessed {count} time(s).");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            Console.WriteLine($"{playerName}, your guess was too High!");
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, your guess was too low!");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{playerName}, that wasn't a number!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (true);
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
