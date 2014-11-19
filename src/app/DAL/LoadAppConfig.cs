using System.Configuration;

namespace DAL
{
    public static class LoadAppConfig
    {
        private static string _connectionString;
        private static int _connectionTimeout;
        private static int _commandTimeout;

        public static string ConnectionString
        {
            get
            {
                _connectionString = ConfigurationManager.ConnectionStrings["PortalDb"].ConnectionString;

                return _connectionString;
            }
        }

        public static int ConnectionTimeout
        {
            get
            {
                if (_connectionTimeout == 0)
                {
                    int ct;
                    int.TryParse(ConfigurationManager.AppSettings["ConnectionTimeout"], out ct);
                    if (ct > 0)
                    {
                        _connectionTimeout = ct;
                    }
                    else
                    {
                        _connectionTimeout = 60;
                    }
                }

                return _connectionTimeout;
            }
        }

        public static int CommandTimeout
        {
            get
            {
                if (_commandTimeout == 0)
                {
                    int ct;
                    int.TryParse(ConfigurationManager.AppSettings["CommandTimeout"], out ct);
                    if (ct > 0)
                    {
                        _commandTimeout = ct;
                    }
                    else
                    {
                        _commandTimeout = 180;
                    }
                }

                return _commandTimeout;
            }
        }
    }
}
