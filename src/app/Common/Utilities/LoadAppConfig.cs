using System.Configuration;
using StatusCode = Common.HttpStatusCodeExceptions;

namespace Common.Utilites
{
    public static class LoadAppConfig
    {
        private static string _connectionString;
        private static int? _connectionTimeout;
        private static int? _commandTimeout;

        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public static int ConnectionTimeout
        {
            get
            {
                return _connectionTimeout.Value;
            }
        }

        public static int CommandTimeout
        {
            get
            {
                return _commandTimeout.Value;
            }
        }

        public static void LoadConfigurationValues()
        {
            #region Connection String
            var connString = ConfigurationManager.ConnectionStrings["ProviderDatabase"];

            if (connString == null)
            {
                throw new StatusCode.ConfigurationException(string.Format("Connection string was not found.  Name = '{0}'", "ProviderDatabase"));
            }

            _connectionString = connString.ConnectionString;
            #endregion Connection String

            #region Connection Timeout
            var connTimeout = ConfigurationManager.AppSettings["ConnectionTimeout"];

            if (connTimeout == null)
            {
                throw new StatusCode.ConfigurationException(string.Format("App setting was not found.  Key = '{0}'", "ConnectionTimeout"));
            }

            int ct;
            
            if (!int.TryParse(ConfigurationManager.AppSettings["ConnectionTimeout"], out ct))
            {
                throw new StatusCode.ConfigurationException(string.Format("App setting was not numeric.  Key = '{0}'", "ConnectionTimeout"));
            }

            _connectionTimeout = ct;
            #endregion Connection Timeout

            #region Command Timeout
            var cmdTimeout = ConfigurationManager.AppSettings["CommandTimeout"];

            if (cmdTimeout == null)
            {
                throw new StatusCode.ConfigurationException(string.Format("App setting was not found.  Key = '{0}'", "CommandTimeout"));
            }

            int cmdTout;

            if (!int.TryParse(ConfigurationManager.AppSettings["CommandTimeout"], out cmdTout))
            {
                throw new StatusCode.ConfigurationException(string.Format("App setting was not numeric.  Key = '{0}'", "ConnectionTimeout"));
            }

            _commandTimeout = cmdTout;
            #endregion Command Timeout
        }
    }
}
