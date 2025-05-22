using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Services;
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
        private int? _productID;
        private readonly Inventory _inventory;
        private UIElement _dynamicContentGrid;

        public int? ProductID
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
        public RemoveProductViewModel(Inventory inventory, NavigationService navigationService)
        {
            _inventory = inventory;
            RemoveProductCommand = new RemoveProductCommand(inventory, _productID, this);
            SearchCommand = new SearchCommand(_inventory, _productID, this);
            CancelCommand = new NavigateCommand(navigationService);
        }
    }
}
