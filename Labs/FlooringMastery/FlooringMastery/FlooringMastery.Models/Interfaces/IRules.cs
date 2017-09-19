using FlooringMastery.Models.Responses;

namespace FlooringMastery.Models
{
    public interface IRules
    {
        OrderResponse ValidateInput(string date, string name, StateTax state, Product product, decimal area);
    }
}