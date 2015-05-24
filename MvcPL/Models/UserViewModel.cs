using MvcPL.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public DateTime AddedDate { get; set; }
        public string Role { get; set; }
    }
}