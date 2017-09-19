using System.Collections.Generic;

namespace FlooringMastery.Models
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetByName(string product);
    }
}