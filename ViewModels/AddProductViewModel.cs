﻿using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Services;
using InventoryManagamentSystem_WPF_DB.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class AddProductViewModel: BaseViewModel
    {
        private readonly InventoryStore _inventoryStore;
        private ProductViewModel _productViewModel;
        private ProductCategoryEnum _selectedCategory;
        private Grid _dynamicContentGrid;

        public ProductViewModel Product
        {
            get => _productViewModel;
            set
            {
                _productViewModel = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public Array ProductCategories => Enum.GetValues(typeof(ProductCategoryEnum));
        public AddProductCommand? AddProductCommand { get; set; }
        public ICommand? CancelCommand { get; }

        public ProductCategoryEnum SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                UpdateProductViewModel();
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
        public AddProductViewModel(InventoryStore inventoryStore, NavigationService navigationService)
        {
            _inventoryStore = inventoryStore;
            AddProductCommand = new AddProductCommand(_inventoryStore, null);
            CancelCommand = new NavigateCommand(navigationService);
        }
        /// <summary>
        /// Updates the DynamicContentGrid with fitting properties textBoxes for each product type
        /// </summary>
        private void UpdateProductViewModel()
        {
            switch (_selectedCategory)
            {
                case ProductCategoryEnum.Electronics:
                    Product = new ElectronicsViewModel();
                    break;
                case ProductCategoryEnum.PerishableGoods:
                    Product = new PerishableGoodsViewModel();
                    break;
                case ProductCategoryEnum.Clothing:
                    Product = new ClothingProductViewModel();
                    break;
            }
            AddProductCommand.ProductViewModel = Product;
            DynamicContentGrid = Product.GetDynamicInputGrid();
        }
    }
}
