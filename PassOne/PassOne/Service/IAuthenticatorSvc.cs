using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;

namespace PassOne.Service
{
   public interface IAuthenticatorSvc
   {
       User Authenticate(string username, string password);
   }
}
