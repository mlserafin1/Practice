using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models
{
    public class DvdListView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string DirectorName { get; set; }
        public string RatingType { get; set; }
        public string Notes { get; set; }
    }
}