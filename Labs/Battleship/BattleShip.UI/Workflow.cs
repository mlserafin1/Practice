using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Workflow
    {
        public void Run()
        {
            string playAgainString;
            bool playAgain = true;
            while (playAgain)
            {
                ConsoleIO output = new ConsoleIO();
                output.Splash();

                Player playerOne = new Player();
                Player playerTwo = new Player();

                playerOne.PopulateBoard();
                playerTwo.PopulateBoard();


                playerOne.Name = output.PlayerOneName();
                playerTwo.Name = output.PlayerTwoName();

                Console.Clear();

                Board p1board = new Board();
                Board p2board = new Board();

                playerOne.SetShips(playerOne, p1board);

                Console.Clear();
                playerTwo.SetShips(playerTwo, p2board);
                Console.Clear();
                int whoseTurn;
                Random rnd = new Random();
                whoseTurn = rnd.Next(1, 3);

                while (!playerOne.victoryCheck && !playerTwo.victoryCheck)
                {

                    if (whoseTurn == 1)
                    {
                        playerOne.ShootIt(playerOne, p2board); //pass in enemy board
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        
                        whoseTurn = 2;
                    }
                    else if (whoseTurn == 2)
                    {
                        playerTwo.ShootIt(playerTwo, p1board); //pass in enemy board
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        
                        whoseTurn = 1;
                    }

                }
                
                Console.WriteLine("Do you want to play again? (Yes = Y, No = N) ");
                playAgainString = Console.ReadLine();
                if (playAgainString == "Y" || playAgainString == "y")
                {
                    Console.Clear();
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }
            }
        }
    }
}
