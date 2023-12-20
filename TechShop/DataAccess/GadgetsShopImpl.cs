using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Entities;
using TechShop.Exceptions;
using TechShop.UI;
using TechShop.Utils;

namespace TechShop.DataAccess
{
    public class GadgetsShopImpl : IGadgetsShop
    {
        private readonly ProductManagement productManagement;
        private readonly CustomerManagement customerManagement;

        public GadgetsShopImpl(ProductManagement productManagement = null, CustomerManagement customerManagement = null)
        {
            this.productManagement = productManagement;
            this.customerManagement = customerManagement;
        }


        #region ---> Add Product
        public bool AddProduct(Products newProduct)
        {
            Console.WriteLine("Enter Product Details:");
            Console.Write("Product ID: ");
            int productId = int.Parse(Console.ReadLine());

            Console.Write("Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            newProduct = new Products(productId, productName, description, price);

            try
            {
                bool success = productManagement.AddProduct(newProduct);

                if (success)
                {
                    Console.WriteLine("Product added successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to add the product.");
                }
                return success;
            }
            catch (DatabaseConnectionException ex)
            {
                Console.WriteLine($"Database Connection Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        #endregion




        #region ---> Add New Customer
        public int AddNewCustomer(Customers newCustomer)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Database connection is null.");
                    return 0;
                }

                if (connection.State != ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is not open.");
                    return 0;
                }

                int lastCustomerId = GetLastCustomerID(connection);
                newCustomer.CustomerID = lastCustomerId + 1;

                string insertQuery = "INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Address) " +
                                     "VALUES (@CustomerID, @FirstName, @LastName, @Email, @Phone, @Address)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", newCustomer.CustomerID);
                    command.Parameters.AddWithValue("@FirstName", newCustomer.FirstName);
                    command.Parameters.AddWithValue("@LastName", newCustomer.LastName);
                    command.Parameters.AddWithValue("@Email", newCustomer.Email);
                    command.Parameters.AddWithValue("@Phone", newCustomer.Phone);
                    command.Parameters.AddWithValue("@Address", newCustomer.Address);

                    try
                    {
                        command.ExecuteNonQuery();
                        return newCustomer.CustomerID;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2601 || ex.Number == 2627)
                        {
                            throw new Exception("Customer with the same email or phone already exists.", ex);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
        }



        #endregion
        #region ---> Get Last Customer ID
        private int GetLastCustomerID(SqlConnection connection)
        {
            string query = "SELECT TOP 1 CustomerID FROM Customers ORDER BY CustomerID DESC";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            return 0;
        }
        #endregion

        #region ---> View Customer Details
        private void ViewCustomerDetails()
        {
            Console.Write("Enter Customer ID: ");
            if (int.TryParse(Console.ReadLine(), out int customerId))
            {
                Customers customer = RetrieveCustomerById(customerId);

                if (customer != null)
                {
                    Console.WriteLine("\nCustomer Details:");
                    Console.WriteLine($"Customer ID: {customer.CustomerID}");
                    Console.WriteLine($"First Name: {customer.FirstName}");
                    Console.WriteLine($"Last Name: {customer.LastName}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"Phone: {customer.Phone}");
                    Console.WriteLine($"Address: {customer.Address}");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid customer ID.");
            }
        }
        #endregion
        #region Retrieve Customer By Id
        public Customers RetrieveCustomerById(int customerId)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT CustomerID, FirstName, LastName, Email, Phone, Address FROM Customers WHERE CustomerID = @CustomerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customers(
                                customerId: reader.GetInt32(0),
                                firstName: reader.GetString(1),
                                lastName: reader.GetString(2),
                                email: reader.GetString(3),
                                phone: reader.GetString(4),
                                address: reader.GetString(5)
                            );
                        }
                    }
                }
            }
            throw new Exception($"Customer with ID {customerId} not found.");
        }


        #endregion

        #region ---> Update Customer Information
        public bool UpdateCustomerInformation(Customers customer)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string updateQuery = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, " +
                                     "Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerID = @CustomerId";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerID);

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        #endregion

        #region ---> CalculateTotalOrders
        public int CalculateTotalOrders(int customerId)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT COUNT(OrderID) FROM Orders WHERE CustomerID = @CustomerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            return -1;
        }
        #endregion
    }
}
