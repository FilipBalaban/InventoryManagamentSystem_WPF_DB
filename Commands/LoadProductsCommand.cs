using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Stores;
using InventoryManagamentSystem_WPF_DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public class LoadProductsCommand : AsyncBaseCommand
    {
        private readonly InventoryStore _inventoryStore;
        private readonly BrowseProductsViewModel _browseProductsViewModel;

        public LoadProductsCommand(InventoryStore inventoryStore, BrowseProductsViewModel browseProductsViewModel)
        {
            _inventoryStore = inventoryStore;
            _browseProductsViewModel = browseProductsViewModel;
        }
        /// <summary>
        /// Uses inventory store to fetch products from DB and calls UpdateProducts() from BrowseProductViewModel 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object? parameter)
        {
            await _inventoryStore.LoadProducts();
            IEnumerable<Product> products = _inventoryStore.Products;
            _browseProductsViewModel.UpdateProducts(products);
        }
    }
}
