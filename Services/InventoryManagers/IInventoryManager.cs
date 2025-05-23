using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Services.InventoryManagers
{
    public interface IInventoryManager
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task AddProduct(Product product);
        Task RemoveProduct(Product product);
    }
}
