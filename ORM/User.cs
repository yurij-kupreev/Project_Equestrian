//using DAL.Interface.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    //[Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public DateTime AddedDate { get; set; }

        //public static implicit operator User(DalUser d)
        //{
        //    return new User()
        //    {
        //        Email = d.Email
        //    };
        //}

        //public static explicit operator User(DalUser d)
        //{
        //    return new User()
        //    {
        //        Email = d.Email
        //    };
        //}

        public virtual Role Role { get; set; }
    }
}
