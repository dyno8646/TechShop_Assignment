using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Entities
{
    public class Inventory
    {
        private int inventoryId;
        private Products product;
        private int quantityInStock;
        private DateTime lastStockUpdate;

        public Inventory(int inventoryId, Products product, int quantityInStock)
        {
            this.inventoryId = inventoryId;
            this.product = product;
            this.quantityInStock = quantityInStock;
            this.lastStockUpdate = DateTime.Now;
        }

        #region ---> Properties
        public int InventoryId
        {
            get { return inventoryId; }
        }

        public Products Product
        {
            get { return product; }
        }

        public int QuantityInStock
        {
            get { return quantityInStock; }
            set
            {
                if (value >= 0)
                    quantityInStock = value;
                else
                    throw new ArgumentException("Quantity in stock cannot be negative.");
            }
        }

        public DateTime LastStockUpdate
        {
            get { return lastStockUpdate; }
            private set { lastStockUpdate = value; }
        }
#endregion

        public override string ToString()
        {
            return $"Inventory ID: {InventoryId}, Product: {Product.ProductName}, Quantity in Stock: {QuantityInStock}, Last Stock Update: {LastStockUpdate}";
        }

    }
}
