using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;

namespace CarDealership.Data.Static_Repos
{
    public class TestModelsRepository : IModelsRepository
    {
        public void CreateModel(Model model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public Make GetMakeIdByModelId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model> GetModelByMakeId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ModelViewModel> GetModelsAndMakes()
        {
            throw new NotImplementedException();
        }
    }
}
