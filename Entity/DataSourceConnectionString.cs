using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Web;

namespace alsideeq_bookstore_api.Entity
{

    public class DataSourceConnectionString
    {
        internal static readonly ILogger<DataSourceConnectionString> _logger = new Logger<DataSourceConnectionString>(new LoggerFactory());

        // public DataSourceConnectionString(ILogger<DataSourceConnectionString> logger)
        // {
        //     _logger = logger;
        // }
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;
            string dbname = appConfig["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["RDS_USERNAME"];
            string password = appConfig["RDS_PASSWORD"];
            string hostname = appConfig["RDS_HOSTNAME"];
            string port = appConfig["RDS_PORT"];

            DataSourceConnectionString._logger.LogInformation("Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";");

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";

        }

        public static string GetMySqlConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;
            string dbname = appConfig["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["RDS_USERNAME"];
            string password = appConfig["RDS_PASSWORD"];
            string hostname = appConfig["RDS_HOSTNAME"];
            string port = appConfig["RDS_PORT"];

            DataSourceConnectionString._logger.LogInformation("Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";");

            return "server=" + hostname + ";database=" + dbname + ";user=" + username + ";password=" + password;

        }
    }
}