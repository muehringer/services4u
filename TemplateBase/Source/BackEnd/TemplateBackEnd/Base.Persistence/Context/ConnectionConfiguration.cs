using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Persistence.Context
{
    public static class ConnectionConfiguration
    {
        private static string connectionString = String.Empty;

        public static string ConnectionString
        {
            get
            {
                if (connectionString == String.Empty)
                {
                    ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["BaseConnection"];

                    if (connectionStringSettings != null)
                        connectionString = connectionStringSettings.ConnectionString;
                }

                return connectionString;
            }
        }
    }
}
