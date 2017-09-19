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
    public static class MakesRepositoryFactory
    {
        public static IMakesRepository GetMakesRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new MakesRepositoryADO();
                case "QA":
                    return new TestMakesRepository();
                default:
                    throw new Exception("Could not find valid repository type configuration value.");
            }
        }
    }
}
