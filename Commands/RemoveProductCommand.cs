using InventoryManagamentSystem_WPF_DB.Models;
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
    public class RemoveProductCommand : BaseCommand
    {
        private readonly Inventory _inventory;
        private readonly RemoveProductViewModel _removeProductViewModel;
        private string _productID;

        public string ProductID
        {
            get => _productID;
            set
            {
                _productID = value;
            }
        }
        
        public RemoveProductCommand(Inventory inventory, string productID, RemoveProductViewModel removeProductViewModel)
        {
            ProductID = productID;
            _inventory = inventory;
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

        public override void Execute(object? parameter)
        {
            Product product = _inventory.GetProducts().FirstOrDefault(p => p.ProductID.ID.ToLower() == ProductID.ToLower());
            TextBlock messageBlock = new TextBlock();
            if (_inventory.GetProducts().Contains(product))
            {
                var result = MessageBox.Show($"Are you sure that you want to remove this product?\nProduct Info:\n{product.ToString()}", "Remove product?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    messageBlock.Text = $"Product: {product.Name} with an ID: {product.ProductID.ID} has successfully been removed.";
                    messageBlock.Foreground = Brushes.Green;
                    _inventory.RemoveProduct(product);
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
