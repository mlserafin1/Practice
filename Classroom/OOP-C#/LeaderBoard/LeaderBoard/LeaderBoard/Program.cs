using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBoard.Data;
using LeaderBoard.Models;

namespace LeaderBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayersRepository repo;
            try
            {
                repo = new PlayersRepository(@"C: \Users\dell\Desktop\GuildWork\manning-serafin-individual-work\Classroom\LeaderBoard\LeaderBoard\Players.txt");
            
                Player player;     // could do Player player = new Player(), but you dont need to create the new player until later.
                do
                {
                    player = new Player();    //need to make a new player, otherwise, it just overwrites the pointer
                    Console.WriteLine("Enter your name: ");
                    player.Name = Console.ReadLine();
                    if (player.Name == "q")
                    {
                        break;
                    }

                    Console.WriteLine("Enter your score: ");
                    player.Score = int.Parse(Console.ReadLine());

                    repo.CreatePlayer(player);
                } while (player.Name != "q");
            
            

                foreach (var allPlayer in repo.GetAllPlayers())
                {
                    Console.WriteLine($"{allPlayer.Id}:{allPlayer.Name} : {allPlayer.Score}");
                }
                Console.ReadLine();
                }
            catch (NotImplementedException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
