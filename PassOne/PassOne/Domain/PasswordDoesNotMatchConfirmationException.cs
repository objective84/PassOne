using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassOne.Domain
{
    public class PasswordDoesNotMatchConfirmationException : Exception
    {
        public PasswordDoesNotMatchConfirmationException()
            : base("Passwords do not match. Please try again.")
        {

        }
    }
}
