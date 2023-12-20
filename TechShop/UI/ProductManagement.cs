using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Entities;
using TechShop.Exceptions;
using TechShop.DataAccess;
using TechShop.Utils;

namespace TechShop.UI
{
    public class ProductManagement
    {
        #region ---> Add Product
        public bool AddProduct(Products newProduct)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                string insertQuery = "INSERT INTO Products (ProductID, ProductName, Description, Price) " +
                                     "VALUES (@ProductID, @ProductName, @Description, @Price)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", newProduct.ProductID);
                    command.Parameters.AddWithValue("@ProductName", newProduct.ProductName);
                    command.Parameters.AddWithValue("@Description", newProduct.Description);
                    command.Parameters.AddWithValue("@Price", newProduct.Price);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2601 || ex.Number == 2627)
                        {
                            throw new Exception("Product with the same ID already exists.", ex);
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

        #region ---> Update Product
        public bool UpdateProduct(Products updatedProduct)
        {
            using (SqlConnection connection = new SqlConnection("your_connection_string_here"))
            {
                connection.Open();

                string updateQuery = "UPDATE Products " +
                                     "SET ProductName = @ProductName, Description = @Description, Price = @Price " +
                                     "WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", updatedProduct.ProductID);
                    command.Parameters.AddWithValue("@ProductName", updatedProduct.ProductName);
                    command.Parameters.AddWithValue("@Description", updatedProduct.Description);
                    command.Parameters.AddWithValue("@Price", updatedProduct.Price);

                    try
                    {
                        int n = command.ExecuteNonQuery();
                        if (n > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                        {
                            throw new ProductNotFoundException("Product not found for update.", ex);
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
    }
}
