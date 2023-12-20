using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Entities
{
    public class Products
    {
        private int productID;
        private string productName;
        private string description;
        private decimal price;

        #region ---> Properties
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
            }
        }
        #endregion

        public Products(int productId, string productName, string description, decimal price)
        {
            this.productID = productId;
            this.productName = productName;
            this.description = description;
            this.price = price;
        }

        public override string ToString()
        {
            return $"Product ID: {ProductID}, Name: {ProductName}, Description: {Description}, Price: {Price:C}";
        }
    }
}
