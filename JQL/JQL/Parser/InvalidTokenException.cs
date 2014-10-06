using System;

namespace JQL
{
    internal class InvalidTokenException : ApplicationException
    {
        internal InvalidTokenException(string message) : base(message)
        {
           
        }
    }
}
