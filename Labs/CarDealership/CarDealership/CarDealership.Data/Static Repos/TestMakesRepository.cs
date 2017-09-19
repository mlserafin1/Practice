using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.Static_Repos
{
    public class TestMakesRepository : IMakesRepository
    {
        public void CreateMake(Make make)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
