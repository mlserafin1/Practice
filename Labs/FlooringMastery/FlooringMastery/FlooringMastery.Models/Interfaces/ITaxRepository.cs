using System.Collections.Generic;

namespace FlooringMastery.Models
{
    public interface ITaxRepository
    {
        List<StateTax> GetAll();
        StateTax GetByName(string state);
    }
}