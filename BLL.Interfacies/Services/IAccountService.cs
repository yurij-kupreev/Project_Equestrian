using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAccountService
    {
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        bool Any(string email);
        UserEntity GetByEmail(string email);
        RoleEntity GetRoleById(int roleKey);
        int GetRoleIdByName(string roleName);
    }
}