using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddModelViewModel
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<ModelViewModel> MakesAndModels { get; set; }
        public Model Model { get; set; }
    }
}