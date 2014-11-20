using System;

namespace Common.HttpStatusCodeExceptions
{
    // Use this exception when you want the response to contain a 500 Internal Server Error HTTP status code.
    [Serializable]
    public class ConfigurationException : Exception
    {
        public ConfigurationException()
            : base() { }

        public ConfigurationException(string message)
            : base(message) { }

        public ConfigurationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ConfigurationException(string message, Exception innerException)
            : base(message, innerException) { }

        public ConfigurationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
