using InventoryManagamentSystem_WPF_DB.Exceptions;
using InventoryManagamentSystem_WPF_DB.Services.InventoryManagers;
using InventoryManagamentSystem_WPF_DB.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public class InventoryBook
    {
        private readonly List<Product> _products;
        private readonly DatabaseInventoryManager _databaseInventoryManager;
        public InventoryBook(DatabaseInventoryManager databaseInventoryManager)
        {
            _products = new List<Product>();
            _databaseInventoryManager = databaseInventoryManager;
        }
        public async Task AddProduct(Product product)
        {
            await _databaseInventoryManager.AddProduct(product);
        }
        public async Task RemoveProduct(Product product)
        {
            await _databaseInventoryManager.RemoveProduct(product);
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _databaseInventoryManager.GetAllProducts();
        }
        public async Task<Product> GetProductByID(int id)
        {
            return await _databaseInventoryManager.GetProductByID(id);
        }
    }
}
