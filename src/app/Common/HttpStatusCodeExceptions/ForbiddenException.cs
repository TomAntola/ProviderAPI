using System;

namespace Common.HttpStatusCodeExceptions
{
    // Use this exception when you want the response to contain a 403 Forbidden HTTP status code.
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
            : base() { }

        public ForbiddenException(string message)
            : base(message) { }

        public ForbiddenException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ForbiddenException(string message, Exception innerException)
            : base(message, innerException) { }

        public ForbiddenException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
