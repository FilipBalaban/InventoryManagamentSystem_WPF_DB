using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Stores;
using InventoryManagamentSystem_WPF_DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public class SearchCommand : AsyncBaseCommand
    {
        private readonly InventoryStore _inventoryStore;
        private readonly RemoveProductViewModel _removeProductViewModel;
        private ProductViewModel _productViewModel;
        public int? ProductID { get; set; }

        public SearchCommand(InventoryStore inventoryStore, int? productID, RemoveProductViewModel removeProductViewModel)
        {
            _inventoryStore = inventoryStore;
            ProductID = productID;
            _removeProductViewModel = removeProductViewModel;
        }

        /// <summary>
        /// If product exists - command updates the DynamicContentElement of removeProductViewModel and displays product info
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object? parameter)
        {
            if(ProductID != null)
            {
                Product product = await _inventoryStore.GetProductByID((int)ProductID);
                if (product != null)
                {
                    GetProductViewModel(product);
                    _removeProductViewModel.DynamicContentElement = _productViewModel.GetDynamicDataGrid();
                    return;
                }
            }
            
            _removeProductViewModel.DynamicContentElement = new TextBlock { Text = "Product not found" }; 
            
        }
        /// <summary>
        /// sets _productViewModel to be an appropriate viewModel type based on its category
        /// </summary>
        /// <param name="product"></param>
        private void GetProductViewModel(Product product)
        {
            switch (product.ProductCategory)
            {
                case ProductCategoryEnum.Electronics:
                    ElectronicsViewModel electronicsViewModel= new ElectronicsViewModel((ElectronicsProduct)product);
                    _productViewModel = electronicsViewModel;
                    break;
                case ProductCategoryEnum.PerishableGoods:
                    PerishableGoodsViewModel perishableGoods = new PerishableGoodsViewModel((PerishableGoodsProduct)product);
                    _productViewModel = perishableGoods;
                    break;
                case ProductCategoryEnum.Clothing:
                    ClothingProductViewModel clothingViewModel = new ClothingProductViewModel((ClothingProduct)product);
                    _productViewModel = clothingViewModel;
                    break;
            }
        }
    }
}
