using MvcPL.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class RegistrationViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Enter your email")]
        [Required(ErrorMessage = "Required field")]
        //[ValidEmailAttribute(ErrorMessage = "Некорректный email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
        public string Email { get; set; }
        [Display(Name = "Enter your password")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Enter the numbers from the picture")]
        [Required(ErrorMessage = "Required field")]
        public string Captcha { get; set; }
        public DateTime AddedDate { get; set; }
    }
}