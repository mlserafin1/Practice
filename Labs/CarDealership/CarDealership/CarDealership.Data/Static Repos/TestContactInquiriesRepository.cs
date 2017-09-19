using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.Static_Repos
{
    public class TestContactInquiriesRepository : IContactInquiriesRepository
    {
        public void AddInquiry(ContactInquiry contact)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactInquiry> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
