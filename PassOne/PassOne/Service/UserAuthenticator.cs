using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;

namespace PassOne.Service
{
   internal class UserAuthenticator : UserSoapSerializer, IAuthenticatorSvc
    {
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
