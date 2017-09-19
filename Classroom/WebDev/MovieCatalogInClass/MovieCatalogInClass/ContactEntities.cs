using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogInClass
{
    public class ContactEntities : DbContext
    {
        public ContactEntities() : base("movieCatalogInClass")
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
