using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Entities;

namespace TechShop.DataAccess
{
    public interface IGadgetsShop
    {
        void AddCustomer(Customers newCustomer);
        bool AddProduct(Products newProduct);
        void UpdateCustomer(Customers customer);
        void CalculateTotalOrders(int customerId);
    }
}
