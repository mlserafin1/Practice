using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State : IValidatableObject
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (string.IsNullOrEmpty(StateAbbreviation))
            {
                results.Add(new ValidationResult("State abbreviation is mandatory", new[] { "StateAbbreviation" }));
            }
            if (string.IsNullOrEmpty(StateName))
            {
                results.Add(new ValidationResult("State name is mandatory", new[] { "StateName" }));
            }
            return results;
        }
    }
}