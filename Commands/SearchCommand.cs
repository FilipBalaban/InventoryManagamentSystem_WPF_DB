using InventoryManagamentSystem_WPF_DB.Models;
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
    public class SearchCommand : BaseCommand
    {
        private readonly Inventory _inventory;
        private readonly RemoveProductViewModel _removeProductViewModel;
        private ProductViewModel _productViewModel;
        public string ProductID { get; set; }

        public SearchCommand(Inventory inventory, string productID, RemoveProductViewModel removeProductViewModel)
        {
            _inventory = inventory;
            ProductID = productID;
            _removeProductViewModel = removeProductViewModel;
        }

        public override void Execute(object? parameter)
        {
            Product product = _inventory.GetProducts().FirstOrDefault(p => p.ProductID.ID == ProductID);
            if (_inventory.GetProducts().Contains(product))
            {
                GetProductViewModel(product);
                _removeProductViewModel.DynamicContentElement = _productViewModel.GetDynamicDataGrid();
                return;
            }
            
            _removeProductViewModel.DynamicContentElement = new TextBlock { Text = "Product not found" }; 
            
        }
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
