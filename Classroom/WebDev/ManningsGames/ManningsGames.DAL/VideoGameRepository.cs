using ManningsGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManningsGames.DAL
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private static List<VideoGame> _videoGames;

        public VideoGameRepository()
        {
            if (_videoGames != null)
            {
                return;
            }
            _videoGames = new List<VideoGame>();
            for (int i = 0; i < 10; i++)
            {
                VideoGame game = new VideoGame();
                game.CoverUrl = "https://tinyurl.com/y89py695";
                game.Name = "Software Awesome Game Series " + (i + 1);
                game.Qty = 10;
                game.ReleaseDate = new DateTime(2017, 5, 18).AddDays(i * 7);
                game.ESRB = (i + 1) % 5;
                game.Id = i + 1;
                game.Cost = i + 10;
                _videoGames.Add(game);
            }
        }

        public void Create(VideoGame model)
        {
            int nextId = 1;
            if (_videoGames.Any())
            {
                nextId += _videoGames.Max(s => s.Id);
            }
            model.Id = nextId;
            _videoGames.Add(model);
        }

        public void Delete(int id)
        {
            _videoGames.RemoveAll(s => s.Id == id);
        }

        public IEnumerable<VideoGame> GetAll()
        {
            return _videoGames;
        }

        public VideoGame GetById(int id)
        {
            return GetAll().FirstOrDefault(s => s.Id == id);
        }

        public void Update(VideoGame model)
        {
            Delete(model.Id);
            _videoGames.Add(model);
        }
    }
}
