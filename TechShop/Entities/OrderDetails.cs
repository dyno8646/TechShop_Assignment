using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Entities
{
    public class OrderDetails
    {
        private int orderDetailId;
        private Orders order;
        private Products product;
        private int quantity;

        #region ---> Properties
        public int OrderDetailId
        {
            get { return orderDetailId; }
        }

        public Orders Order
        {
            get { return order; }
            set { order = value; }
        }

        public Products Product
        {
            get { return product; }
            set { product = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value > 0)
                {
                    quantity = value;
                }
                else
                {
                    throw new ArgumentException("Quantity must be a positive integer.");
                }
            }
        }
        #endregion

        public OrderDetails(int orderDetailId, Orders order, Products product, int quantity)
        {
            this.orderDetailId = orderDetailId;
            this.order = order;
            this.product = product;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return $"OrderDetail ID: {OrderDetailId}, Order ID: {Order.OrderId}, Product: {Product.ProductName}, Quantity: {Quantity}";
        }
    }
}
