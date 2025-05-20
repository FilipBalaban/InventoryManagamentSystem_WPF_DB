using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class RemoveProductViewModel: BaseViewModel
    {
        private string? _productID;
        private readonly Inventory _inventory;
        private UIElement _dynamicContentGrid;

        public string? ProductID
        {
            get => _productID;
            set
            {
                _productID = value;
                OnPropertyChanged(nameof(ProductID));
                ((RemoveProductCommand)RemoveProductCommand).ProductID = _productID;
                ((SearchCommand)SearchCommand).ProductID = _productID;
            }
        }
        public UIElement DynamicContentElement
        {
            get => _dynamicContentGrid;
            set
            {
                _dynamicContentGrid = value;
                OnPropertyChanged(nameof(DynamicContentElement));
            }
        }

        public ICommand SearchCommand { get; }
        public ICommand RemoveProductCommand { get; }
        public ICommand CancelCommand { get; }
        public RemoveProductViewModel(Inventory inventory)
        {
            _inventory = inventory;
            Product product = new ElectronicsProduct("Phone", ProductCategoryEnum.Electronics, 253, 5, 235, 5);
            _inventory.AddProduct(product);
            product = new ClothingProduct("Hoodie", ProductCategoryEnum.Clothing, 89.99m, 1, ClothingFabricEnum.Silk, ClothingSizeEnum.M);
            _inventory.AddProduct(product);
            product = new PerishableGoodsProduct("Apple", ProductCategoryEnum.PerishableGoods, 1.99m, 1, 50, 75, new DateTime(2025, 7, 1));
            _inventory.AddProduct(product);
            RemoveProductCommand = new RemoveProductCommand(inventory, _productID, this);
            SearchCommand = new SearchCommand(_inventory, _productID, this);
        }
    }
}
