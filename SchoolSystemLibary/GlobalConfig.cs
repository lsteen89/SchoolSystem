using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace SchoolSystemLibary
{
    public class GlobalConfig
    {
        private static readonly string connectionString;

        static GlobalConfig()
        {
            // Retrieve the connection string from App.config using its name
            connectionString = ConfigurationManager.ConnectionStrings["SchoolSystemConnection"].ConnectionString;
        }

        public static IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(connectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
