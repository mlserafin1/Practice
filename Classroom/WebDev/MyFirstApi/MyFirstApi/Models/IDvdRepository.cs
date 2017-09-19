using System;
using System.Collections.Generic;
using System.Linq;

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