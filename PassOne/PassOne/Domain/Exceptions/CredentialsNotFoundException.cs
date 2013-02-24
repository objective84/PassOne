using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassOne.Domain.Exceptions
{
    public class CredentialsNotFoundException : Exception
    {
        public int IdNotFound;
        public CredentialsNotFoundException(int id)
        {
            IdNotFound = id;
        }
    }
}
