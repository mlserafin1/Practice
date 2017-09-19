using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class ConsoleIO
    {
        public void Splash()
        {
            Console.WriteLine(@"           







                                       

                                        

                                                

                                                Welcome to Battleship!

                                              Press any key to continue.");
            Console.ReadKey();
        }

        public string PlayerOneName()
        {
            string name;
            Console.Clear();
            Console.WriteLine("Player 1, enter your name: ");
            name = Console.ReadLine();
            return name;
        }

        public string PlayerTwoName()
        {
            string name;
            Console.Clear();
            Console.WriteLine("Player 2, enter your name: ");
            name = Console.ReadLine();
            return name;
        }



        public void DisplayShipSettingPrompt(string str)
        {
            string name = str;
            Console.Clear();
            Console.WriteLine($"{name}, set your ships. \nEnter a coordinate (ex. B10) for the starting point of the ship.");
            Console.WriteLine("Destroyer = 2 slots, Submarine = 3, Cruiser = 3, Battleship = 4, Carrier = 5.");
            
        }
        
    } 
}
