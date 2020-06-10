using System;

namespace Tateti.Domain
{
    public class InvalidMarkPositionException : Exception
    {
        public InvalidMarkPositionException(string message) : base(message)
        {

        }
    }
}