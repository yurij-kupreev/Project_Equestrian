using System;

namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime AddedDate { get; set; }
        public int RoleId { get; set; }

        //public static implicit operator User(DalUser d)
        //{
        //    return new User()
        //    {
        //        Email = d.Email
        //    };
        //}

    }
}