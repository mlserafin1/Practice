using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class AddRules : IRules
    {
        public OrderResponse ValidateInput(string date, string name, StateTax state, Product product, decimal area)
        {
            OrderResponse response = new OrderResponse();
            string m = date.Substring(0, 2);
            string d = date.Substring(2, 2);
            string y = date.Substring(4);
            string newDate = m + "/" + d + "/" + y;
            DateTime compareDate = DateTime.Parse(newDate);

            if (compareDate < DateTime.Now)
            {
                response.Success = false;
                response.Message = "The entered date must be later than today.";
                return response;
            }
            if (string.IsNullOrEmpty(name))
            {
                response.Success = false;
                response.Message = "You must enter a valid name.";
                return response;
            }
            if (name.Contains("|"))
            {
                response.Success = false;
                response.Message = "Invalid character. Name cannot contain '|'.";
                return response;
            }
            if (state == null)
            {
                response.Success = false;
                response.Message = "We are not authorized to sell in the state you entered.";
                return response;
            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "The product you entered is invalid.";
                return response;
            }
            if (area < 100)
            {
                response.Success = false;
                response.Message = "The minimum order size is 100 ft^2.";
                return response;
            }

            response.Success = true;

            response.Order.CustomerName = name;
            response.Order.State = state.StateAbbreviation;
            response.Order.TaxRate = state.TaxRate;
            response.Order.ProductType = product.productType;
            response.Order.Area = area;
            response.Order.CostPerSquareFoot = product.costPerSquareFoot;
            response.Order.LaborCostPerSquareFoot = product.laborCostPerSquareFoot;
            response.Order.MaterialCost = area * product.costPerSquareFoot;
            response.Order.LaborCost = area * product.laborCostPerSquareFoot;
            response.Order.Tax = (response.Order.MaterialCost + response.Order.LaborCost) *
                                 (response.Order.TaxRate / 100);
            response.Order.Total = response.Order.MaterialCost + response.Order.LaborCost + response.Order.Tax;

            return response;
        }
    }
}
