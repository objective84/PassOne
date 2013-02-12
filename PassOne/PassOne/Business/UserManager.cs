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

        public static void CreateUser(string path, string fn, string ln, string un, string pass)
        {
            GetUserService(path).UpdateTable(new User(GetUserService(path).GetNextIdValue(), fn, ln, un, pass));
        }

        public static void CreateUser(User user, string path )
        {
            GetUserService(path).UpdateTable(user);
        }

        public static void UpdateUser(this User user, string path)
        {
            GetUserService(path).UpdateTable(user);
        }

        public static User Authenticate(string username, string password, string path)
        {
            var factory = new SoapFactory();
            var authenticator = factory.GetService(Services.UserAuthenticator, path) as IAuthenticatorSvc;
            return authenticator.Authenticate(username, password);
        }

        public static IList<string> GetCredentialsList(this User user, string path)
        {
            return (from string id in user.CredentialsList.Keys select user.FindCredentials((int) user.CredentialsList[id], path).Website).ToList();
        }

        private static ISerializeSvc GetUserService(string path)
        {
            var factory = new SoapFactory();
            return factory.GetService(Services.UserSoapSerializer, path) as ISerializeSvc;
        }
    }
}
