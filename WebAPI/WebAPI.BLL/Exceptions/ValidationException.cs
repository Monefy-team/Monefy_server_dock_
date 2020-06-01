using System;

namespace WebAPI.BLL.Exceptions
{
    public class ValidationException : Exception
    {
        public string Message { get;  }

        public ValidationException(string message) : base(message)
        {
            Message = message;
        }
    }
}