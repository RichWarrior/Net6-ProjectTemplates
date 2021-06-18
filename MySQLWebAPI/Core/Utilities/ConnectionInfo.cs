﻿using Environment;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class ConnectionInfo
    {
        /// <summary>
        /// 
        /// </summary>
        static volatile ConnectionInfo _instance;

        /// <summary>
        /// 
        /// </summary>
        public static ConnectionInfo Instance
        {
            get
            {
                return _instance ?? (_instance = new ConnectionInfo());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        readonly IConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        private ConnectionInfo()
        {
            configuration = Environment.Environment.Instance.GetConfiguration();
        }

        /// <summary>
        /// 
        /// </summary>
        public string MySQLConnectionString => (string)configuration.GetValue(typeof(string), "sql_server_connection_string");
    }
}
