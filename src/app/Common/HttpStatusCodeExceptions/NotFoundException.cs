using System;

namespace Common.HttpStatusCodeExceptions
{
    // Use this exception when you want the response to contain a 404 Not Found HTTP status code.
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base() { }

        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        public NotFoundException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
