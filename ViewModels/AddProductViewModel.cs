using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Models;
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
        private readonly Inventory _inventory;
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
        public ICommand? CancelComamnd { get; }

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
        public AddProductViewModel(Inventory inventory)
        {
            _inventory = inventory;
            AddProductCommand = new AddProductCommand(_inventory, null);
        }
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
