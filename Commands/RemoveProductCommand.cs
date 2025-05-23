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
using System.Windows.Controls;
using System.Windows.Media;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public class RemoveProductCommand : AsyncBaseCommand
    {
        private readonly InventoryStore _inventoryStore;
        private readonly RemoveProductViewModel _removeProductViewModel;
        private int? _productID;

        public int? ProductID
        {
            get => _productID;
            set
            {
                _productID = value;
            }
        }
        
        public RemoveProductCommand(InventoryStore inventoryStore, int? productID, RemoveProductViewModel removeProductViewModel)
        {
            ProductID = productID;
            _inventoryStore = inventoryStore;
            _removeProductViewModel = removeProductViewModel;
            _removeProductViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_removeProductViewModel.DynamicContentElement))
            {
                OnCanExecuteChanged(this, new EventArgs());
            }
        }
        public override async Task ExecuteAsync(object? parameter)
        {

            Product product = await _inventoryStore.GetProductByID((int)ProductID);
            TextBlock messageBlock = new TextBlock();
            if (product != null)
            {
                var result = MessageBox.Show($"Are you sure that you want to remove this product?\nProduct Info:\n{product.ToString()}", "Remove product?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    await _inventoryStore.RemoveProduct(product);
                    messageBlock.Text = $"Product: {product.Name} with an ID: {product.ID} has successfully been removed.";
                    messageBlock.Foreground = Brushes.Green;
                    _removeProductViewModel.DynamicContentElement = messageBlock;
                }
            }
            else
            {
                messageBlock.Text = $"Product with an ID: {ProductID} does not exist in your Inventory!";
                messageBlock.Foreground = Brushes.Red;
                _removeProductViewModel.DynamicContentElement = messageBlock;
            }
        }
        public override bool CanExecute(object? parameter)
        {
            return _removeProductViewModel.DynamicContentElement is Border;
        }
    }
}
