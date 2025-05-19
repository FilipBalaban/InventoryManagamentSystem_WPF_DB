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
    public class AddProductViewModel: BaseViewModel
    {
        private readonly Inventory _inventory;
        private ProductViewModel _productViewModel;
        private ProductCategoryEnum _selectedCategory;
        private Grid _dynamicContentGrid;

        public ProductViewModel Product => _productViewModel;
   
        public Array ProductCategories => Enum.GetValues(typeof(ProductCategoryEnum));

        public ICommand? AddProductCommand { get; set; }
        public ICommand? CancelComamnd { get; }

        public ProductCategoryEnum SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                GetProductData();
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
            _productViewModel = new ProductViewModel();
            AddProductCommand = new AddProductCommand(_inventory, _productViewModel);
        }

        private void GetProductData()
        {
            _productViewModel = new ProductViewModel();
            switch (_selectedCategory)
            {
                case ProductCategoryEnum.Electronics:
                    _productViewModel = new ElectronicsViewModel();
                    break;
                case ProductCategoryEnum.PerishableGoods:
                    _productViewModel = new PerishableGoodsViewModel();
                    break;
                case ProductCategoryEnum.Clothing:
                    _productViewModel = new ClothingProductViewModel();
                    break;
            }
            ((AddProductCommand)AddProductCommand).ProductViewModel = _productViewModel;
            DynamicContentGrid = _productViewModel.GetDynamicInputGrid();
        }
    }
}
