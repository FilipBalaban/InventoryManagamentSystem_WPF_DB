using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public abstract class Product
    {
        private static int _objectCounter;
        public ProductID ProductID { get; }
        public string? Name { get; }
        public ProductCategoryEnum ProductCategory { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        protected Product(string name, ProductCategoryEnum productCategory, decimal price, int quantity)
        {
            _objectCounter++;
            ProductID = new ProductID(productCategory, _objectCounter);
            Name = name;
            ProductCategory = productCategory;
            Price = price;
            Quantity = quantity;
        }
    }
}
