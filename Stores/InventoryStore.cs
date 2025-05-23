using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Services.InventoryManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Stores
{
    public class InventoryStore
    {
        private List<Product> _products;
        public IEnumerable<Product> Products => _products;
        private readonly Inventory _inventory;

        public InventoryStore(Inventory inventory)
        {
            _inventory = inventory;
            _products = new List<Product>();
        }
        public async Task LoadProducts()
        {
            IEnumerable<Product> products = await _inventory.GetProducts();
            _products.Clear();
            _products.AddRange(products);
        }
        public async Task AddProduct(Product product)
        {
            await _inventory.AddProduct(product);
            _products.Add(product);
        }
        public async Task RemoveProduct(Product product)
        {
            await _inventory.RemoveProduct(product);
            _products.Remove(product);
        }
        public async Task<Product> GetProductByID(int id)
        {
            return await _inventory.GetProductByID(id);
        }
    }
}
