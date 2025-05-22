using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public class Inventory
    {
        private readonly InventoryBook _inventoryBook;

        public Inventory()
        {
            _inventoryBook = new InventoryBook();
        }
        public void AddProduct(Product product)
        {
            _inventoryBook.AddProduct(product);
        }
        public void RemoveProduct(Product product)
        {
            _inventoryBook.RemoveProduct(product);
        }
        public IEnumerable<Product> GetProducts()
        {
            return _inventoryBook.GetProducts();
        }
        public IEnumerable<Product> GetProductsByCategory(ProductCategoryEnum category)
        {
            return _inventoryBook.GetProductsByCategory(category);
        }
    }
}
