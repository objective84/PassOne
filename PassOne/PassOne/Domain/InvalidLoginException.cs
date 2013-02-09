using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassOne.Domain
{
   public class InvalidLoginException : Exception
    {
       public InvalidLoginException()
           : base("Invalid username or password.")
       {

       }
    }
}
