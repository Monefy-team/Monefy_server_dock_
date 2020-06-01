using System;

namespace WebAPI.BLL.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Message { get;}

        public NotFoundException(string message) : base(message)
        {
            Message = message;
        }
    }
}