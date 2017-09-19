using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebAPI.Models
{
    public interface IDVDRepository
    {
        IEnumerable<DVD> GetAll();
        DVD Get(int id);
        void Create(DVD dvd);
        void Edit(DVD dvd);
        void Delete(int id);
    }
}
