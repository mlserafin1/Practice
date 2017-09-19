using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.BLL
{
    public class DvdManager
    {
        private IDvdRepository _repo;

        public DvdManager(IDvdRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<DvdListView> GetAll()
        {
            List<DvdListView> dvds = new List<DvdListView>();
            var dvdsComplete = _repo.GetAll();
            foreach (var d in dvdsComplete)
            {
                DvdListView dvd = new DvdListView();
                dvd.Id = d.Id;
                dvd.Title = d.Title;
                dvd.ReleaseYear = d.ReleaseYear;
                dvd.DirectorName = d.DirectorName;
                dvd.RatingType = d.RatingType;
                dvd.Notes = d.Notes;
                dvds.Add(dvd);
            }
            return dvds;
        }

        public DvdListView GetById(int id)
        {
            var dvdRaw = _repo.GetById(id);
            DvdListView dvd = new DvdListView();
            dvd.Id = dvdRaw.Id;
            dvd.Title = dvdRaw.Title;
            dvd.ReleaseYear = dvdRaw.ReleaseYear;
            dvd.DirectorName = dvdRaw.DirectorName;
            dvd.RatingType = dvdRaw.RatingType;
            dvd.Notes = dvdRaw.Notes;

            return dvd;
        }

        public void Create(Dvd dvd)
        {
            _repo.Create(dvd);
        }

        public void Update(Dvd dvd)
        {
            _repo.Update(dvd);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<DvdListView> SearchForTitle(string title)
        {
            return _repo.SearchForTitle(title);
        }

        public IEnumerable<DvdListView> SearchForYear(string releaseYear)
        {
            return _repo.SearchForYear(releaseYear);
        }

        public IEnumerable<DvdListView> SearchForDirector(string directorName)
        {
            return _repo.SearchForDirector(directorName);
        }

        public IEnumerable<DvdListView> SearchForRating(string rating)
        {
            return _repo.SearchForRating(rating);
        }
    }
}