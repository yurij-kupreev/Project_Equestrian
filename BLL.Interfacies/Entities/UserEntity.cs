using System;
namespace BLL.Interface.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public DateTime AddedDate { get; set; }
        public int RoleId { get; set; }
    }
}
