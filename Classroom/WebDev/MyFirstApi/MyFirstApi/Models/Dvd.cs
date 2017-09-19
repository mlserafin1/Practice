using System;
using System.Linq;
using System.Web;

namespace MyFirstApi.Models
{
    public class Dvd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RealeseYear { get; set; }
        public string Director { get; set; }
        public string Notes { get; set; }
        public string Rating { get; set; }
    }
}