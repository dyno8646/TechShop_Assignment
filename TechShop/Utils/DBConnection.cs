using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using TechShop.Exceptions;

namespace TechShop.Utils
{
    public static class DBConnection
    {
        private static IConfiguration iconfiguration;

        static DBConnection()
        {
            getAppSettingsFile();
        }

        private static void getAppSettingsFile()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            iconfiguration = builder.Build();
        }

        public static SqlConnection GetConnection()
        {
            try
            {
                string connectionString = getConnectionString();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Error while establishing a database connection.", ex);
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private static string getConnectionString()
        {
            return iconfiguration.GetConnectionString("DefaultConnection");
        }
    }
}
