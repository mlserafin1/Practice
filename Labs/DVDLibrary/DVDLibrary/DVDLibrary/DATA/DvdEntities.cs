using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDLibrary.DATA
{
    public class DvdEntities : DbContext
    {
        public DvdEntities():base("dvdLibrary")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Dvd> Dvds { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}