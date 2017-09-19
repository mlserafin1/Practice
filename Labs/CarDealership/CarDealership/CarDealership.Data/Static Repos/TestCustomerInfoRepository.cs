using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.Static_Repos
{
    public class TestCustomerInfoRepository : ICustomerInfoRepository
    {
        public void AddCustomer(CustomerInfo customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerInfo> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
