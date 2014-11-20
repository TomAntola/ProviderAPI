using System;

namespace Common.HttpStatusCodeExceptions
{
    // Use this exception when you want the response to contain a 400 Bad Request HTTP status code.
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base() { }

        public BadRequestException(string message)
            : base(message) { }

        public BadRequestException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException) { }

        public BadRequestException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
