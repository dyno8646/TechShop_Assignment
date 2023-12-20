using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechShop.UI;

namespace TechShop.Entities
{
    public class Customers
    {
        private int customerID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;

        #region ---> Properties
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value;}
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        #endregion

        public Customers() { }
        public Customers(int customerId, string firstName, string lastName, string email, string phone, string address)
        {
            this.customerID = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.address = address;
        }

        public override string ToString()
        {
            return $"Customer ID: {CustomerID}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {Phone}, Address: {Address}";
        }
    }
}
