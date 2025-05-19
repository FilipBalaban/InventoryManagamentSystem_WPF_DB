using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class RemoveProductViewModel: BaseViewModel
    {
        private string? _productID;
        private readonly Inventory _inventory;
        private Grid _dynamicContentGrid;

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
        public Grid DynamicContentGrid
        {
            get => _dynamicContentGrid;
            set
            {
                _dynamicContentGrid = value;
                OnPropertyChanged(nameof(DynamicContentGrid));
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
            RemoveProductCommand = new RemoveProductCommand(inventory, _productID);
            SearchCommand = new SearchCommand(_inventory, _productID, this);
        }
    }
}
