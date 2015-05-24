﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class ResultsAddModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int Place { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public double Points { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Name of the athlete")]
        public string AthleteName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Name of the horse")]
        public string HorseName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string CompetitionTitle { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string CompetitionProgram { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DataType(DataType.Date)]
        [Display(Name = "The beginning of the competition")]
        public DateTime DateBegin { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "The end of the competition")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
    }
}