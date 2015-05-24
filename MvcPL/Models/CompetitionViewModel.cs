using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class CompetitionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Program { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "The beginning of the competition")]
        public DateTime DateBegin { get; set; }
        [Display(Name = "The end of the competition")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
    }
}