using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManningsGames.Models
{
    public interface IVideoGameRepository
    {
        void Create(VideoGame model);
        void Update(VideoGame model);
        void Delete(int id);

        IEnumerable<VideoGame> GetAll();
        VideoGame GetById(int id);
    }
}
