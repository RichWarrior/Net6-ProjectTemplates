﻿using Microsoft.Extensions.Configuration;

namespace $safeprojectname$
{
    public class $safeprojectname$
    {
        /// <summary>
        /// 
        /// </summary>
        private static $safeprojectname$ _environmentManager;

        /// <summary>
        /// 
        /// </summary>
        private $safeprojectname$()
        {
            GetEnvironment();
        }

        /// <summary>
        /// 
        /// </summary>
        private static object _lock = new();

        /// <summary>
        /// 
        /// </summary>
        public static $safeprojectname$ Instance
        {
            get
            {
                lock (_lock)
                {
                    return _environmentManager ?? (_environmentManager = new $safeprojectname$());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string environment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration configuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IConfiguration GetConfiguration()
        {
            if (configuration == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json", true, true);
                configuration = builder.Build();
            }
            return configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetEnvironment()
        {
            if (string.IsNullOrEmpty(environment))
            {
                try
                {
                    environment = System.$safeprojectname$.GetEnvironmentVariable("MODE").ToLower();
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }
            }
            return environment;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDevelopment => environment == "development";

        /// <summary>
        /// 
        /// </summary>
        public bool IsProduction => environment == "production";

        /// <summary>
        /// 
        /// </summary>
        public bool IsStaging => environment == "staging";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool Is(string mode) => environment == mode;
    }
}
