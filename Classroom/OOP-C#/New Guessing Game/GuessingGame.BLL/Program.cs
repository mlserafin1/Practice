using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.BLL;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow flow = new GameFlow();
            flow.PlayGame();
        }
    }
}
