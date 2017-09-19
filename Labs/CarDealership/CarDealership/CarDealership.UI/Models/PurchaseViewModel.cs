using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class PurchaseViewModel : IValidatableObject
    {
        public VehicleViewModel Vehicle { get; set; }
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public CustomerInfo Customer { get; set; }
        public IEnumerable<SelectListItem> PurchasesTypes { get; set; }
        public Purchase Purchase { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Customer.Name))
            {
                errors.Add(new ValidationResult("Name is required!"));
            }

            if (string.IsNullOrEmpty(Customer.Address1))
            {
                errors.Add(new ValidationResult("Street 1 is required!"));
            }

            if (string.IsNullOrEmpty(Customer.Phone))
            {
                errors.Add(new ValidationResult("Phone number is required!"));
            }

            if (string.IsNullOrEmpty(Customer.City))
            {
                errors.Add(new ValidationResult("City is required!"));
            }

            if (string.IsNullOrEmpty(Customer.Zip))
            {
                errors.Add(new ValidationResult("Zip code is required!"));
            }

            if (!string.IsNullOrEmpty(Customer.Zip))
            {
                if((Customer.Zip).Length < 5 || (Customer.Zip).Length > 5)
                {
                    errors.Add(new ValidationResult("Zip code must be five digits!"));
                }
            }
            
            if(Purchase.Price == 0)
            {
                errors.Add(new ValidationResult("Purchase price is required!"));
            }

            if (Purchase.Price <  (Vehicle.Price * 0.95M))
            {
                errors.Add(new ValidationResult("Purchase price cannot be less than 95% of sale price!"));
            }

            if (Purchase.Price > Vehicle.Msrp)
            {
                errors.Add(new ValidationResult("Purchase price cannot exceed MSRP!"));
            }

            return errors;
        }
    }
}