using InventoryManagamentSystem_WPF_DB.Services.InventoryManagers;
using InventoryManagamentSystem_WPF_DB.Stores;
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

        public Inventory(InventoryBook inventoryBook)
        {
            _inventoryBook = inventoryBook;
        }
        public async Task AddProduct(Product product)
        {
            await _inventoryBook.AddProduct(product);
        }
        public async Task RemoveProduct(Product product)
        {
            await _inventoryBook.RemoveProduct(product);
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _inventoryBook.GetProducts();
        }
        public Task<Product> GetProductByID(int id)
        {
            return _inventoryBook.GetProductByID(id);
        }
    }
}
