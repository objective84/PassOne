using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Service;
using PassOne.Domain;

namespace PassOne.Business
{
    public class UserManager : ManagerBase
    {
        public UserManager()
            : base(Services.UserSoapSerializer)
        {
        }

        public void CreateUser(string path, string fn, string ln, string un, string pass)
        {
            GetService(path).UpdateTable(new User(GetService(path).GetNextIdValue(), fn, ln, un, pass));
        }

        public void CreateUser(User user, string path )
        {
            GetService(path).UpdateTable(user);
        }

        public void UpdateUser(User user, string path)
        {
            GetService(path).UpdateTable(user);
        }

        public User Authenticate(string username, string password, string path)
        {
            var authenticator = GetService(Services.UserAuthenticator, path) as IAuthenticatorSvc;
            return authenticator.Authenticate(username, password);
        }

        public Dictionary<string, int> GetCredentialsList(User user, string path)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string key in user.CredentialsList.Keys)
            {
                Credentials credentials = ((CredentialsSoapSerializer) Factory.GetService(Services.CredentialsSoapSerializer, path, user)).RetreiveById((int)user.CredentialsList[key]) as Credentials;
                dictionary.Add(credentials.Website, credentials.Id);
            }
            return dictionary;
        }
    }
}
