using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public interface IDvdRepository
    {
        void Create(Dvd dvd);
        IEnumerable<Dvd> GetAll();
        Dvd GetById(int id);
        void Update(Dvd dvd);
        void Delete(int id);
        IEnumerable<DvdListView> SearchForTitle(string title);
        IEnumerable<DvdListView> SearchForYear(string releaseYear);
        IEnumerable<DvdListView> SearchForDirector(string directorName);
        IEnumerable<DvdListView> SearchForRating(string rating);
    }
}
