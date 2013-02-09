using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Service;
using PassOne.Domain;

namespace PassOne.Business
{
    public static class UserManager
    {
        public static void CreateUser(string fn, string ln, string un, string pass)
        {
            GetUserService().UpdateTable(new User(GetUserService().GetNextIdValue(), fn, ln, un, pass));
        }

        public static void CreateUser(User user)
        {
            GetUserService().UpdateTable(user);
        }

        public static void UpdateUser(this User user)
        {
            GetUserService().UpdateTable(user);
        }

        public static User Authenticate(string username, string password)
        {
            var factory = new SoapFactory();
            var authenticator = factory.GetService(Services.UserAuthenticator) as IAuthenticatorSvc;
            return authenticator.Authenticate(username, password);
        }

        public static IList<string> GetCredentialsList(this User user)
        {
            return (from string id in user.CredentialsList.Keys select user.FindCredentials((int) user.CredentialsList[id]).Website).ToList();
        }

        private static ISerializeSvc GetUserService()
        {
            var factory = new SoapFactory();
            return factory.GetService(Services.UserSoapSerializer) as ISerializeSvc;
        }
    }
}
