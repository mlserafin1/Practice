using System.Collections.Generic;

namespace MyFirstApi.Models
{
    public interface IDvdRepository
    {
        IEnumerable<Dvd> GetAll();
        Dvd GetById(int id);
        void Create(Dvd model);
        void Update(Dvd model);
        void Delete(int id);
    }
}