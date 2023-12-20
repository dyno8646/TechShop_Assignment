using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechShop.DataAccess;
using TechShop.Utils;
using TechShop.Entities;

namespace TechShop.UI
{
    public class CustomerManagement
    {
        private readonly IGadgetsShop gadgetsShop;
        public CustomerManagement(IGadgetsShop gadgetsShop)
        {
            this.gadgetsShop = gadgetsShop;
        }
        #region ---> RunCustomerManagement
        public void RunCustomerManagement()
        {
            Customers newCustomer=null;
            int customerId = 0;
            while (true)
            {
                Console.WriteLine("Customer Management Menu");
                Console.WriteLine("1. Add New Customer");
                Console.WriteLine("2. Update Customer Information");
                Console.WriteLine("3. View Customer Details");
                Console.WriteLine("4. Calculate Total Orders for Customer");
                Console.WriteLine("5. Return to Main Menu");

                int choice = GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        UpdateCustomerInformation(newCustomer);
                        break;
                    case 3:
                        ViewCustomerDetails();
                        break;
                    case 4:
                        CalculateTotalOrders(customerId);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        #endregion

        #region GetMenuChoice
        private int GetMenuChoice()
        {
            Console.Write("Enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.Write("Invalid input. Enter a valid choice: ");
            }
            return choice;
        }

        #endregion

        public void AddCustomer()
        {
            Console.WriteLine("Adding a new customer:");

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            try
            {
                Customers newCustomer = new Customers(0, firstName, lastName, email, phone, address);

                int customerId = customerManagement.AddNewCustomer(newCustomer);

                Console.WriteLine($"Customer added successfully. Customer ID: {customerId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding customer: {ex.Message}");
            }
        }


        #region ---> Update Customer Information
        public void UpdateCustomer(Customers customer)
        {
            Console.WriteLine("Enter Customer ID to update:");
            if (int.TryParse(Console.ReadLine(), out int customerIdToUpdate))
            {
                Customers existingCustomer = customerManagement.RetrieveCustomerById(customerIdToUpdate);

                if (existingCustomer != null)
                {
                    Console.WriteLine("Enter updated customer details:");

                    Console.Write("First Name: ");
                    string updatedFirstName = Console.ReadLine();

                    Console.Write("Last Name: ");
                    string updatedLastName = Console.ReadLine();

                    Console.Write("Email: ");
                    string updatedEmail = Console.ReadLine();

                    Console.Write("Phone: ");
                    string updatedPhone = Console.ReadLine();

                    Console.Write("Address: ");
                    string updatedAddress = Console.ReadLine();

                    existingCustomer.FirstName = updatedFirstName;
                    existingCustomer.LastName = updatedLastName;
                    existingCustomer.Email = updatedEmail;
                    existingCustomer.Phone = updatedPhone;
                    existingCustomer.Address = updatedAddress;

                    try
                    {
                        bool success = customerManagement.UpdateCustomerInformation(existingCustomer);

                        if (success)
                        {
                            Console.WriteLine("Customer information updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to update customer information.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
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

        #region ---> Calculate Total Orders for Customer
        public void CalculateTotalOrders(int customerId)
        {
            int totalOrders = customerManagement.CalculateTotalOrders(customerId);

            if (totalOrders >= 0)
            {
                Console.WriteLine($"Total orders for Customer ID {customerId}: {totalOrders}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
        #endregion

    }
}
