using System;

namespace Common.HttpStatusCodeExceptions
{
    // Use this exception when you want the response to contain a 409 Conflict HTTP status code.
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException()
            : base() { }

        public ConflictException(string message)
            : base(message) { }

        public ConflictException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ConflictException(string message, Exception innerException)
            : base(message, innerException) { }

        public ConflictException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
