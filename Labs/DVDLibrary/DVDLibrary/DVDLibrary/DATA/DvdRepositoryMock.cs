using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.DATA
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>();

        public DvdRepositoryMock()
        {
            if (!_dvds.Any())
            {
                _dvds.AddRange(new List<Dvd>()
                {
                    new Dvd
                    {
                        Id = 1,
                        Title = "Movie 1",
                        ReleaseYear = "2017",
                        DirectorName = "Mel Brooks",
                        RatingType = "PG-13",
                        Notes = "Something"
                    },
                    new Dvd
                    {
                        Id = 2,
                        Title = "Movie 2",
                        ReleaseYear = "2017",
                        DirectorName = "Wes Anderson",
                        RatingType = "R",
                        Notes = "Something else."
                    },
                    new Dvd
                    {
                        Id = 3,
                        Title = "Movie 3",
                        ReleaseYear = "2017",
                        DirectorName = "Another Person",
                        RatingType = "PG",
                        Notes = "Something else again."
                    },
                    new Dvd
                    {
                        Id = 4,
                        Title = "Movie 4",
                        ReleaseYear = "2015",
                        DirectorName = "Yet Another Person",
                        RatingType = "PG",
                        Notes = "Something else, yet again."
                    }
                });
            }
        }

        public void Create(Dvd dvd)
        {
            var nextId = 1;
            if (_dvds.Any())
            {
                nextId += _dvds.Max(r => r.Id);
            }
            dvd.Id = nextId;
            _dvds.Add(dvd);
        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(r => r.Id == id);
        }

        public IEnumerable<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd GetById(int id)
        {
            return _dvds.FirstOrDefault(r => r.Id == id);
        }

        public void Update(Dvd dvd)
        {
            Delete(dvd.Id);
            _dvds.Add(dvd);
        }

        public IEnumerable<DvdListView> SearchForTitle(string title)
        {
            var list = _dvds.Where(d => d.Title.ToUpper().Contains(title.ToUpper()));
            var newList = new List<DvdListView>();
            foreach (var d in list)
            {
                DvdListView temp = new DvdListView();
                temp.Id = d.Id;
                temp.Title = d.Title;
                temp.ReleaseYear = d.ReleaseYear;
                temp.DirectorName = d.DirectorName;
                temp.RatingType = d.RatingType;
                temp.Notes = d.Notes;
                newList.Add(temp);
            }
            return newList;
        }

        public IEnumerable<DvdListView> SearchForYear(string releaseYear)
        {
            var list = _dvds.Where(d => d.ReleaseYear.Contains(releaseYear));
            var newList = new List<DvdListView>();
            foreach (var d in list)
            {
                DvdListView temp = new DvdListView();
                temp.Id = d.Id;
                temp.Title = d.Title;
                temp.ReleaseYear = d.ReleaseYear;
                temp.DirectorName = d.DirectorName;
                temp.RatingType = d.RatingType;
                temp.Notes = d.Notes;
                newList.Add(temp);
            }
            return newList;
        }

        public IEnumerable<DvdListView> SearchForDirector(string directorName)
        {
            var list = _dvds.Where(d => d.DirectorName.ToUpper().Contains(directorName.ToUpper()));
            var newList = new List<DvdListView>();
            foreach (var d in list)
            {
                DvdListView temp = new DvdListView();
                temp.Id = d.Id;
                temp.Title = d.Title;
                temp.ReleaseYear = d.ReleaseYear;
                temp.DirectorName = d.DirectorName;
                temp.RatingType = d.RatingType;
                temp.Notes = d.Notes;
                newList.Add(temp);
            }
            return newList;
        }

        public IEnumerable<DvdListView> SearchForRating(string rating)
        {
            var list = _dvds.Where(d => d.RatingType == rating.ToUpper());
            var newList = new List<DvdListView>();
            foreach (var d in list)
            {
                DvdListView temp = new DvdListView();
                temp.Id = d.Id;
                temp.Title = d.Title;
                temp.ReleaseYear = d.ReleaseYear;
                temp.DirectorName = d.DirectorName;
                temp.RatingType = d.RatingType;
                temp.Notes = d.Notes;
                newList.Add(temp);
            }
            return newList;
        }
    }
}