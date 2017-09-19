using LeaderBoard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.Data
{
    public class PlayersRepository
    {
        private List<Player> _players;    //sets _players to a type of list of type Player
        private string _fileName;


        public PlayersRepository(string fileName)     //constructor has the name of the class, no return type.  Gets run when 'new' keyword is used.
        {
            if (File.Exists(fileName) == false)
            {
                File.Create(fileName);   //or can do throw new NotImplementedException();
            }
            _fileName = fileName;
            _players = LoadPlayers();
            // _players = new List<Player>();  now that LoadPLayers is created, can put it in constructor. So don't need the code to the left anymore.  //constructs a new empty list when you instantiate a new object of type PlayersRepository.
            SavePlayers(_players);
        }

        //Create a player
        public void CreatePlayer(Player player)
        {
            int maxId = 1;
            if (_players.Any())
            {
                maxId += _players.Max(p => p.Id);
            }
            
            player.Id = maxId;
            _players.Add(player);
            SavePlayers(_players);
        }
        //Read a player
        public List<Player> GetAllPlayers()
        {
            return _players;
        }
        //update a player
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <exception cref="Exception">If Player ID is not found, throws Exception.</exception>
        public void UpdatePlayer(Player player)
        {
            Player foundPlayer = _players.FirstOrDefault(p=>p.Id == player.Id); //these next three lines can be replaced with DeletePlayer(player.Id);
            if (foundPlayer == null)
            {
                throw new Exception("Player not found.");
            }

            _players.Remove(foundPlayer);
            _players.Add(player);
            SavePlayers(_players);
        }
        //Delete a player
        public void DeletePlayer(int id)
        {
            Player foundPlayer = _players.FirstOrDefault(p => p.Id == id);
            if (foundPlayer == null) return;

            _players.Remove(foundPlayer);
            SavePlayers(_players);
        }

        private List<Player> LoadPlayers()
        {
            List<Player> result = new List<Player>();
            using (StreamReader sr = new StreamReader(_fileName))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        Player player = new Player();
                        string[] fields = line.Split(',');
                        player.Id = int.Parse(fields[0]);
                        player.Name = fields[1];
                        player.Score = int.Parse(fields[2]);
                        result.Add(player);
                    }
                    catch (IndexOutOfRangeException e) //called swallowing the error...if exception is thrown, do nothing.
                    {

                    }
                    finally   //executes when you are done with the try/catch. Its like the default in a switch. Will always run after your try/catch is done.
                    {
                        
                    }
                }
            }
            return result;
        }

        public void SavePlayers(List<Player> players)
        {
            using (StreamWriter sw = new StreamWriter(_fileName,false))
            {
                sw.WriteLine("Id,Name,Score");
                foreach (var player in players)
                {
                    sw.WriteLine($"{player.Id},{player.Name},{player.Score}");
                }
            }
        }
    }
}
