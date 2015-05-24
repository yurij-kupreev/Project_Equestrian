using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class ResultViewModel
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public double Points { get; set; }
        [Display(Name = "Name of the athlete")]
        public string AthleteName { get; set; }
        public string CompetitionTitle { get; set; }
        public string CompetitionProgram { get; set; }
    }
}