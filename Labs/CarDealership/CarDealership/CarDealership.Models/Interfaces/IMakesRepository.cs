using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IMakesRepository
    {
        IEnumerable<Make> GetAll();
        void CreateMake(Make make);
    }
}
