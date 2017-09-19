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
    public static class VehiclesRepositoryFactory
    {
        public static IVehiclesRepository GetVehiclesRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new VehiclesRepositoryADO();
                case "QA":
                    return new TestVehiclesRepository();
                default:
                    throw new Exception("Could not find valid repository type configuration value.");
            }
        }
    }
}
