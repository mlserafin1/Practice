using System.Collections.Generic;
using System.Linq;

namespace MyFirstApi.Models
{
    public class DvdRepository : IDvdRepository
    {
        private static List<Dvd> _dvds;
        public void Create(Dvd model)
        {
            var nextId = 1;
            if (_dvds.Any())
            {
                nextId += _dvds.Max(r => r.Id);
            }
            model.Id = nextId;
            _dvds.Add(model);
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

        public void Update(Dvd model)
        {
            Delete(model.Id);
            _dvds.Add(model);
        }
    }
}