using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddVehicleViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
        public Vehicle Vehicle { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateTime temp;
            List<ValidationResult> errors = new List<ValidationResult>();

            if (!string.IsNullOrEmpty(Vehicle.Year))
            {
                temp = DateTime.ParseExact(Vehicle.Year, "yyyy", null);
                if (temp > (DateTime.Now.AddYears(1)) || temp < (DateTime.Now.AddYears(-17)))
                {
                    errors.Add(new ValidationResult("Year must be between today's year plus 1 or or minus 17."));
                }
            }

            if (string.IsNullOrEmpty(Vehicle.Year))
            {
                errors.Add(new ValidationResult("Year is required!"));
            }

            if(Vehicle.Mileage != null)
            {
                if (Vehicle.IsNew == true && int.Parse(Vehicle.Mileage) > 1000)
                {
                    errors.Add(new ValidationResult("New vehicles cannot have more than 1000 miles!"));
                }

                if (Vehicle.IsNew == false && int.Parse(Vehicle.Mileage) <= 1000)
                {
                    errors.Add(new ValidationResult("Used vehicles cannot have less than 1000 miles!"));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Mileage is required!"));
            }

            if (string.IsNullOrEmpty(Vehicle.Vin))
            {
                errors.Add(new ValidationResult("VIN is required!"));
            }

            if (Vehicle.Msrp < 0)
            {
                errors.Add(new ValidationResult("MSRP must be positive!"));
            }

            if (Vehicle.Price < 0)
            {
                errors.Add(new ValidationResult("Price must be positive!"));
            }

            if (Vehicle.Price > Vehicle.Msrp)
            {
                errors.Add(new ValidationResult("Price cannot be more than MSRP!"));
            }

            if (UploadedFile == null)
            {
                errors.Add(new ValidationResult("You must upload a photo!"));
            }

            if (string.IsNullOrEmpty(Vehicle.Description))
            {
                errors.Add(new ValidationResult("Description is required!"));
            }

            if (Vehicle.ModelId == 0)
            {
                errors.Add(new ValidationResult("Make and model required!"));
            }
            
            return errors;
            //throw new NotImplementedException();
        }
    }
}