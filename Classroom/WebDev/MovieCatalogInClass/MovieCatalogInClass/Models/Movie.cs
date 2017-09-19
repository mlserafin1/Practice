using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogInClass
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Title { get; set; }

        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<Genre> Genre { get; set; }
    }
}
