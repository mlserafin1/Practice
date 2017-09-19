using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebAPI.Models
{
    public class DVDRepository : IDVDRepository
    {
        private static List<DVD> _dvds;

        public DVDRepository()
        {
            if (_dvds != null)
            {
                return;
            }

            _dvds = new List<DVD>();
           _dvds.Add(new DVD()
                {
                    Id = 1,
                    Title = "The Hunt for Red October",
                    ReleaseYear = 1990,
                    Director = "John McTiernan",
                    Rating = "PG",
                    Notes = "Great movie. Connery is the only actor that can realistically portray a Russian submarine captain with a Scottish accent."
                });
                _dvds.Add(new DVD()
                {
                    Id = 2,
                    Title = "RED",
                    ReleaseYear = 2010,
                    Director = "Robert Schwentke",
                    Rating = "PG-13",
                    Notes = "Good movie."
                });
            
        }

        public IEnumerable<DVD> GetAll()
        {
            return _dvds;
        }

        public DVD Get(int id)
        {
            return _dvds.FirstOrDefault(d => d.Id == id);
        }

        public void Create(DVD dvd)
        {
            var nextId = 1;
            if(_dvds.Any())
            {
                nextId = nextId + _dvds.Max(s => s.Id);
            }
            dvd.Id = nextId;
            _dvds.Add(dvd);
        }

        public void Edit(DVD dvd)
        {
            Delete(dvd.Id);
            _dvds.Add(dvd);

        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(d => d.Id == id);
        }
    }
}