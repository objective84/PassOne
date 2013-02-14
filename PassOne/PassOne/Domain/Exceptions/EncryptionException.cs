using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassOne.Domain
{
    public class EncryptionException : Exception
    {
        public EncryptionException()
            : base("Invalid encryption key")
        {

        }
    }
}
