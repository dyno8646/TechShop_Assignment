//using System;
//using System.Data;
//using System.Data.SqlClient;
//using TechShop.Utils;

//namespace TechShop.DataAccess
//{
//    public class DBAccess
//    {
//        private readonly string connectionString;

//        public DBAccess()
//        {
//            connectionString = PropertyUtil.GetConnectionString();

//            if (string.IsNullOrWhiteSpace(connectionString))
//            {
//                throw new InvalidOperationException("Database connection string is missing or invalid.");
//            }
//        }

//        public bool ExecuteNonQuery(string query, SqlParameter[] parameters)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            using (SqlCommand command = new SqlCommand(query, connection))
//            {
//                try
//                {
//                    connection.Open();
//                    command.Parameters.AddRange(parameters);
//                    int rowsAffected = command.ExecuteNonQuery();
//                    return rowsAffected > 0;
//                }
//                catch (SqlException ex)
//                {
//                    Console.WriteLine($"Database error: {ex.Message}");
//                    return false;
//                }
//            }
//        }
//        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            using (SqlCommand command = new SqlCommand(query, connection))
//            {
//                if (parameters != null)
//                {
//                    command.Parameters.AddRange(parameters);
//                }

//                try
//                {
//                    connection.Open();
//                    return command.ExecuteScalar();
//                }
//                catch (SqlException ex)
//                {
//                    Console.WriteLine($"Database error: {ex.Message}");
//                    return null;
//                }
//            }
//        }


//        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            using (SqlCommand command = new SqlCommand(query, connection))
//            {
//                try
//                {
//                    connection.Open();
//                    command.Parameters.AddRange(parameters);
//                    DataTable dataTable = new DataTable();
//                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
//                    {
//                        adapter.Fill(dataTable);
//                    }
//                    return dataTable;
//                }
//                catch (SqlException ex)
//                {
//                    Console.WriteLine($"Database error: {ex.Message}");
//                    return null;
//                }
//            }
//        }
//    }
//}
