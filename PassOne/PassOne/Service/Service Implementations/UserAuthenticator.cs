using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;

namespace PassOne.Service
{
   internal class UserAuthenticator : UserSoapSerializer, IAuthenticatorSvc
    {
       public UserAuthenticator()
       {
       }

       /// <summary>
       /// Method to authenticate a user's login information
       /// </summary>
       /// <param name="username">The username the user typed into the login form</param>
       /// <param name="password">The password the user typed into the login form</param>
       /// <returns>If the authentication was successful, the user retrieved using the username; else returns throws an InvalidLoginException</returns>
       public User Authenticate(string username, string password)
       {
           var user = RetrieveByUsername(username);
           if (user == null || user.Password != password)
           {
               throw new InvalidLoginException();
           }
           else
           {
               return user;
           }
       }
    }
}
