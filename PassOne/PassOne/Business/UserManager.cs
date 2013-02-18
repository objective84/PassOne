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
        /// <summary>
        /// Method to create a new user in the user.bin file, takes the individual strings instead of a User object.
        /// </summary>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <param name="fn">The user's first name</param>
        /// <param name="ln">The user's last name</param>
        /// <param name="un">The user's chosen username</param>
        /// <param name="pass">The user's chosen password</param>
        public void CreateUser(string path, string fn, string ln, string un, string pass)
        {
            GetService(path).UpdateTable(new User(GetService(path).GetNextIdValue(), fn, ln, un, pass));
        }

        /// <summary>
        /// Method to create a new user in the user.bin file, takes a preconstructed User object
        /// </summary>
        /// <param name="user">The user to be created</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void CreateUser(User user, string path )
        {
            GetService(path).UpdateTable(user);
        }

        /// <summary>
        /// Method to update user information contained in the user.bin file
        /// </summary>
        /// <param name="user">The new user data</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void UpdateUser(User user, string path)
        {
            GetService(path).UpdateTable(user);
        }

        /// <summary>
        /// Method to authenticate a user's login information
        /// </summary>
        /// <param name="username">The username the user typed into the login form</param>
        /// <param name="password">The password the user typed into the login form</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <returns>If the authentication was successful, returns the User object associated with the provided username, otherwise throws an InvalidLoginException</returns>
        public User Authenticate(string username, string password, string path)
        {
            var authenticator = GetService(Services.UserAuthenticator, path) as IAuthenticatorSvc;
            return authenticator.Authenticate(username, password);
        }

        /// <summary>
        /// Method to create an IDictionary representation of the user's credentials list. Keys are the credentials title, values are the credentials Ids
        /// </summary>
        /// <param name="user">The user whose credentials list is being retrieved</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <returns>An IDictionary object with the user's credentials</returns>
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
