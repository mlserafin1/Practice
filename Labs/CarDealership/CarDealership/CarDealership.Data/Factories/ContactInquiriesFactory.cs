using CarDealership.Data.ADO;
using CarDealership.Data.Interfaces;
using CarDealership.Data.Static_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factories
{
    public static class ContactInquiriesFactory
    {
        public static IContactInquiriesRepository GetContactInquiriesRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new ContactInquiriesRepositoryADO();
                case "QA":
                    return new TestContactInquiriesRepository();
                default:
                    throw new Exception("Could not find valid repository type configuration value.");
            }
        }
    }
}
