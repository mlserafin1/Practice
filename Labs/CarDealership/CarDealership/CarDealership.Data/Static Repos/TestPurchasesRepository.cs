using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.Static_Repos
{
    public class TestPurchasesRepository : IPurchasesRepository
    {
        public void AddPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
