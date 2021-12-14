using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Exceptions
{
    public class CPException : Exception
    {
        public CPException()
        {
        }
        public CPException(string message)
            : base(message) 
        {
        }
        public CPException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
