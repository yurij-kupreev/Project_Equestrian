using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class AthleteViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name of the athlete")]
        public string AthleteName { get; set; }
        [Display(Name = "Name of the horse")]
        public string HorseName { get; set; }
        public double Points { get; set; }
    }
}