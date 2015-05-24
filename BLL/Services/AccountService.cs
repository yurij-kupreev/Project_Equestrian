using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public AccountService(IUnitOfWork uow, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.uow = uow;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
                return userRepository.GetAll().Select(user => user.ToBllUser()); 
        }
        public bool Any(string email)
        {
            //var daluser = userRepository.GetByPredicate(p => p.Email == email);
            //if (daluser == null) return false;
            //else return true;
            return userRepository.Any(email);
        }

        public UserEntity GetByEmail(string email)
        {
            return userRepository.GetByPredicate(p => p.Email == email).ToBllUser();
        }

        public RoleEntity GetRoleById(int roleKey)
        {
            return roleRepository.GetByPredicate(p => p.Id == roleKey).ToBllRole();
        }

        public int GetRoleIdByName(string roleName)
        {
            return roleRepository.GetByPredicate(p => p.Name == roleName).ToBllRole().Id;
        }

        public void CreateUser(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            uow.Commit();
        }
    }
}
