using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogInClass
{
    public class Rating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        [Required]
        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        public string RatingName { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
