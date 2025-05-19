using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public class AddProductCommand : BaseCommand
    {
        private readonly Inventory _inventory;
        private ProductViewModel _productViewModel;
        public ProductViewModel ProductViewModel
        {
            get => _productViewModel;
            set
            {
                _productViewModel = value;
            }
        }

        public AddProductCommand(Inventory inventory, ProductViewModel productViewModel)
        {
            _inventory = inventory;
            _productViewModel = productViewModel;
        }

        public override void Execute(object? parameter)
        {
            switch (_productViewModel.ProductCategory)
            {
                case ProductCategoryEnum.Electronics:
                    ElectronicsProduct electronicsProduct = new ElectronicsProduct(_productViewModel.Name, _productViewModel.ProductCategory, _productViewModel.Price, _productViewModel.Quantity, ((ElectronicsViewModel)(_productViewModel)).Voltage, ((ElectronicsViewModel)(_productViewModel)).BatteryCapacity);
                    _inventory.AddProduct(electronicsProduct);
                    break;
                case ProductCategoryEnum.PerishableGoods:
                    PerishableGoodsProduct perishableGoods = new PerishableGoodsProduct(_productViewModel.Name, _productViewModel.ProductCategory, _productViewModel.Price, _productViewModel.Quantity, ((PerishableGoodsViewModel)(_productViewModel)).Calories, ((PerishableGoodsViewModel)(_productViewModel)).Weight, ((PerishableGoodsViewModel)(_productViewModel)).ExpirationDate);
                    _inventory.AddProduct(perishableGoods);
                    break;
                case ProductCategoryEnum.Clothing:
                    ClothingProduct clothingProduct = new ClothingProduct(_productViewModel.Name, _productViewModel.ProductCategory, _productViewModel.Price, _productViewModel.Quantity, ((ClothingProductViewModel)(_productViewModel)).Fabric, ((ClothingProductViewModel)(_productViewModel)).Size);
                    _inventory.AddProduct(clothingProduct);
                    break;
            }
        }
    }
}
