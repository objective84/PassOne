using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassOne.Domain
{
    class MissingInformationException : Exception
    {
        public MissingInformationException(string info)
            : base("Please enter " + info + " to continue.")
        {

        }
    }
}
