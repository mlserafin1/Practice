using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TipCalculator.Web.Models
{
    public class Tip
    {
        [Display(Name = "Total of Bill")]
        [Required(ErrorMessage = "The Bill Total field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "You must have a bill total above 0.")]
        public decimal BillTotal { get; set; }

        [Display(Name = "Tip Percentage")]
        [Required(ErrorMessage = "Tip Percentage is required")]
        public decimal TipPercent { get; set; }

        [Display(Name = "Total (With calculated tip included)")]
        public decimal TotalWithCalculatedTip { get; set; }
    }
}
