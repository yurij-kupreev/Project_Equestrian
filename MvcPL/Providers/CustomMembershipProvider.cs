using BLL.Interface.Entities;
using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace MvcPL.Providers
{
    //провайдер членства помогает системе идентифицировать пользователя
    public class CustomMembershipProvider : MembershipProvider
    {
        private IAccountService accountService;

        public MembershipUser CreateUser(string email, string password)
        {
            accountService = (IAccountService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAccountService));

            MembershipUser membershipUser = GetUser(email, false);

            if (membershipUser != null)
            {
                return null;
            }
            string UserRoleName = ConfigurationManager.AppSettings["UserRoleName"];
            accountService.CreateUser(new UserEntity()
            {
                UserEmail = email,
                UserPassword = Crypto.HashPassword(password),
                AddedDate = DateTime.Now,
                RoleId = accountService.GetRoleIdByName(UserRoleName)
            });

            membershipUser = GetUser(email, false);
            return membershipUser;
        }

        public override bool ValidateUser(string email, string password)
        {
            accountService = (IAccountService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAccountService));
            UserEntity user = accountService.GetByEmail(email);
            if (user != null && Crypto.VerifyHashedPassword(user.UserPassword, password))
            {
                return true;
            }
            return false;
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            accountService = (IAccountService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAccountService));
            var user = accountService.GetByEmail(email);

            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider", user.UserEmail,
                    null, null, null, null,
                    false, false, user.AddedDate, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        #region NI
        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}