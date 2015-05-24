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

        [Display(Name = "Введите email")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        //[ValidEmailAttribute(ErrorMessage = "Некорректный email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email")]
        public string Email { get; set; }
        [Display(Name = "Введите пароль")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Пароль должен содержать по крайней мере {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Введите цифры с картинки")]
        [Required(ErrorMessage = "Необходимо ввести цифры с картинки")]
        public string Captcha { get; set; }
        public DateTime AddedDate { get; set; }
    }
}