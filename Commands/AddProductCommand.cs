using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Stores;
using InventoryManagamentSystem_WPF_DB.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public class AddProductCommand : AsyncBaseCommand
    {
        private readonly InventoryStore _inventoryStore;
        private ProductViewModel _productViewModel;
        public ProductViewModel ProductViewModel
        {
            get => _productViewModel;
            set
            {
                if(_productViewModel != null)
                {
                    _productViewModel.PropertyChanged -= OnProductViewModelPropertyChanged;
                }
                _productViewModel = value;
                OnCanExecuteChanged(this, new EventArgs());
                if(_productViewModel != null)
                {
                    _productViewModel.PropertyChanged += OnProductViewModelPropertyChanged;
                }
            }
        }
        public override bool CanExecute(object? parameter)
        {
            return _productViewModel != null && _productViewModel.ArePropertiesFilled();
        }
        public AddProductCommand(InventoryStore inventoryStore, ProductViewModel productViewModel)
        {
            _inventoryStore = inventoryStore;
            ProductViewModel = productViewModel;
            if(_productViewModel != null)
            {
                ProductViewModel.PropertyChanged += OnProductViewModelPropertyChanged;
            }
        }
        private void OnProductViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged(this, new EventArgs());
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await AddProduct();
                string message = $"Product {_productViewModel.Name} Category: {_productViewModel.ProductCategory} has been successfully added to the inventory.";
                MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            } catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async Task AddProduct()
        {
            switch (_productViewModel.ProductCategory)
            {
                case ProductCategoryEnum.Electronics:
                    ElectronicsProduct electronics = new ElectronicsProduct(_productViewModel.Name, _productViewModel.ProductCategory, _productViewModel.Price, _productViewModel.Quantity, ((ElectronicsViewModel)_productViewModel).Voltage, ((ElectronicsViewModel)_productViewModel).BatteryCapacity);
                    await _inventoryStore.AddProduct(electronics);
                    break;

                case ProductCategoryEnum.PerishableGoods:
                    PerishableGoodsProduct perishableGoods = new PerishableGoodsProduct(_productViewModel.Name, _productViewModel.ProductCategory, _productViewModel.Price, _productViewModel.Quantity, ((PerishableGoodsViewModel)_productViewModel).Calories, ((PerishableGoodsViewModel)_productViewModel).Weight, ((PerishableGoodsViewModel)_productViewModel).ExpirationDate);
                    await _inventoryStore.AddProduct(perishableGoods);
                    break;

                case ProductCategoryEnum.Clothing:
                    ClothingProduct clothing = new ClothingProduct(_productViewModel.Name, _productViewModel.ProductCategory, _productViewModel.Price, _productViewModel.Quantity, ((ClothingProductViewModel)_productViewModel).Fabric, ((ClothingProductViewModel)_productViewModel).Size);
                    await _inventoryStore.AddProduct(clothing);
                    break;
            }
        }
    }
}
