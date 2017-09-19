using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IModelsRepository
    {
        IEnumerable<Model> GetAll();
        void CreateModel(Model model);
        IEnumerable<Model> GetModelByMakeId(int id);
        IEnumerable<ModelViewModel> GetModelsAndMakes();
        Make GetMakeIdByModelId(int id);
    }
}
