using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDLibrary.DATA
{
    public class DvdRepositoryEF : IDvdRepository
    {
        private DvdEntities _ctx;

        public DvdRepositoryEF()
        {
            this._ctx = new DvdEntities();
        }

        public void Create(Dvd dvd)
        {
            _ctx.Dvds.Add(dvd);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            //var dvd = _ctx.Dvds.FirstOrDefault(m => m.Id == id);
            _ctx.Dvds.Remove(GetById(id));
            _ctx.SaveChanges();
        }

        public IEnumerable<Dvd> GetAll()
        {
            var dvds = _ctx.Dvds.SqlQuery("SELECT d.Id, d.Title, d.ReleaseYear, d.DirectorName,r. RatingId, r.RatingType, d.Notes FROM Dvds d LEFT JOIN Ratings r ON d.RatingID = r.RatingID ORDER BY d.Id").ToList();
            return dvds;
            //return _ctx.Dvds;
        }

        public Dvd GetById(int id)
        {
            var dvd = _ctx.Dvds.Include("Rating").FirstOrDefault(d => d.Id == id);  //use anonymous object
            dvd.RatingType = dvd.Rating.RatingType;
            return dvd;
            //return _ctx.Dvds.Find(id);
        }

        public void Update(Dvd dvd)
        {
            _ctx.Entry(dvd).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public IEnumerable<DvdListView> SearchForTitle(string title)
        {
            var dvds = GetAll();
            List<DvdListView> list = new List<DvdListView>();
            foreach (var d in dvds)
            {
                if (d.Title.Contains(title))
                {
                    DvdListView temp = new DvdListView();
                    temp.Id = d.Id;
                    temp.Title = d.Title;
                    temp.ReleaseYear = d.ReleaseYear;
                    temp.DirectorName = d.DirectorName;
                    temp.RatingType = d.RatingType;
                    temp.Notes = d.Notes;
                    list.Add(temp);
                }
            }
            return list;
        }

        public IEnumerable<DvdListView> SearchForYear(string releaseYear)
        {
            var dvds = GetAll();
            List<DvdListView> list = new List<DvdListView>();
            foreach (var d in dvds)
            {
                if (d.ReleaseYear.Contains(releaseYear))
                {
                    DvdListView temp = new DvdListView();
                    temp.Id = d.Id;
                    temp.Title = d.Title;
                    temp.ReleaseYear = d.ReleaseYear;
                    temp.DirectorName = d.DirectorName;
                    temp.RatingType = d.RatingType;
                    temp.Notes = d.Notes;
                    list.Add(temp);
                }
            }
            return list;
        }

        public IEnumerable<DvdListView> SearchForDirector(string directorName)
        {
            var dvds = GetAll();
            List<DvdListView> list = new List<DvdListView>();
            foreach (var d in dvds)
            {
                if (d.DirectorName.Contains(directorName))
                {
                    DvdListView temp = new DvdListView();
                    temp.Id = d.Id;
                    temp.Title = d.Title;
                    temp.ReleaseYear = d.ReleaseYear;
                    temp.DirectorName = d.DirectorName;
                    temp.RatingType = d.RatingType;
                    temp.Notes = d.Notes;
                    list.Add(temp);
                }
            }
            return list;
        }

        public IEnumerable<DvdListView> SearchForRating(string rating)
        {
            var dvds = GetAll();
            List<DvdListView> list = new List<DvdListView>();
            foreach (var d in dvds)
            {
                if (d.RatingType == rating.ToUpper())
                {
                    DvdListView temp = new DvdListView();
                    temp.Id = d.Id;
                    temp.Title = d.Title;
                    temp.ReleaseYear = d.ReleaseYear;
                    temp.DirectorName = d.DirectorName;
                    temp.RatingType = d.RatingType;
                    temp.Notes = d.Notes;
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}