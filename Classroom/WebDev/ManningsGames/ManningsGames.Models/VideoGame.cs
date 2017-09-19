using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManningsGames.Models
{
    public class VideoGame : IValidatableObject
    {
        public int Id { get; set; }
        public string CoverUrl { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ESRB { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "You must have a cost value above 0.")]
        public decimal Cost { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(0,int.MaxValue,ErrorMessage ="You must have a qty above 0.")]
        public int Qty { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if(ReleaseDate.Date > DateTime.Now)
            {
                results.Add(new ValidationResult("The game has not been released.", new[] { "ReleaseDate" }));
            }
            if (Name.Contains("Madden"))
            {
                results.Add(new ValidationResult("The game is not allowed.", new[] { "Name" }));
            }

            return results;
        }
    }
}
