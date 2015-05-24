using BLL.Interface.Services;
using System;
using System.Linq;
using System.Web.Security;

namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IAccountService accountService;
        public override bool IsUserInRole(string email, string roleName)
        {
            accountService = (IAccountService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAccountService));

            var user = accountService.GetByEmail(email);

            if (user == null) return false;

            var role = accountService.GetRoleById(user.RoleId);

            if (role != null && role.Name == roleName)
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string email)
        {
            accountService = (IAccountService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAccountService));
            var roles = new string[] { };
            var user = accountService.GetByEmail(email);

            if (user == null) return roles;

            var userRole = accountService.GetRoleById(user.RoleId);

            if (userRole != null)
            {
                roles = new string[] { userRole.Name };
            }
            return roles;
        }

        #region NI
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
        #endregion
}