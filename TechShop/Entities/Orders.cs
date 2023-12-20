using System;
using System.Collections.Generic;

namespace TechShop.Entities
{
    public class Orders
    {
        private int orderId;
        private Customers customer;
        private DateTime orderDate;
        private decimal totalAmount;

        public Orders(int orderId, Customers customer, DateTime orderDate)
        {
            this.orderId = orderId;
            this.customer = customer;
            this.orderDate = orderDate;
            this.totalAmount = 0;
        }

        #region ---> Properties

        public int OrderId
        {
            get { return orderId; }
        }

        public Customers Customer
        {
            get { return customer; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public decimal TotalAmount
        {
            get { return totalAmount; }
            private set { totalAmount = value; }
        }
#endregion

        public override string ToString()
        {
            return $"Order ID: {OrderId}, Customer: {Customer.FirstName}, Order Date: {OrderDate}, Total Amount: {TotalAmount:C}";
        }
    }
}
