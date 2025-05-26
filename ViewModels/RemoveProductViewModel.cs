using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Services;
using InventoryManagamentSystem_WPF_DB.Stores;
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
        private readonly InventoryStore _inventoryStore;
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
        /// <summary>
        /// Property that will be used to display product data on the UI
        /// </summary>
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
        public RemoveProductViewModel(InventoryStore inventoryStore, NavigationService navigationService)
        {
            _inventoryStore = inventoryStore;
            RemoveProductCommand = new RemoveProductCommand(inventoryStore, _productID, this);
            SearchCommand = new SearchCommand(_inventoryStore, _productID, this);
            CancelCommand = new NavigateCommand(navigationService);
        }
    }
}
