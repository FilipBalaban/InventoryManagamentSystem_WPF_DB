using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class BrowseProductsViewModel: BaseViewModel
    {
        private readonly Inventory _inventory;
        private readonly ObservableCollection<ProductViewModel> _products;
        private ListView _dynamicListView;
        private bool _allProductsRadioChecked;
        private bool _electronicsRadioChecked;
        private bool _perishableGoodsRadioChecked;
        private bool _clothingProductsRadioChecked;


        public IEnumerable<ProductViewModel> Products => _products;

        public ListView DynamicListView
        {
            get => _dynamicListView;
            set
            {
                _dynamicListView = value;
                OnPropertyChanged(nameof(DynamicListView));
            }
        }
        public bool AllProductsRadioChecked
        {
            get => _allProductsRadioChecked;
            set
            {
                _allProductsRadioChecked = value;
                OnPropertyChanged(nameof(AllProductsRadioChecked));
                UpdateProducts();
            }
        }
        public bool ElectronicsRadioChecked
        {
            get => _electronicsRadioChecked;
            set
            {
                _electronicsRadioChecked = value;
                OnPropertyChanged(nameof(ElectronicsRadioChecked));
                UpdateProducts();
            }
        }
        public bool PerishableGoodsRadioChecked
        {
            get => _perishableGoodsRadioChecked;
            set
            {
                _perishableGoodsRadioChecked = value;
                OnPropertyChanged(nameof(PerishableGoodsRadioChecked));
                UpdateProducts();
            }
        }
        public bool ClothingProductsRadioChecked
        {
            get => _clothingProductsRadioChecked;
            set
            {
                _clothingProductsRadioChecked = value;
                OnPropertyChanged(nameof(ClothingProductsRadioChecked));
                UpdateProducts();
            }
        }
        public ICommand ReturnCommand { get; set; }
        public BrowseProductsViewModel(Inventory inventory, NavigationService navigationService)
        {
            _inventory = inventory;
            _products = new ObservableCollection<ProductViewModel>();
            AllProductsRadioChecked = true;
            ReturnCommand = new NavigateCommand(navigationService);
        }
        public void UpdateProducts()
        {
            _products.Clear();
            if (_clothingProductsRadioChecked)
            {
                foreach (Product product in _inventory.GetProductsByCategory(ProductCategoryEnum.Clothing))
                {
                    _products.Add(new ClothingProductViewModel((ClothingProduct)product));
                }
                DynamicListView = new ClothingProductViewModel().GetContentListView();
            }
            else if (_electronicsRadioChecked)
            {
                foreach (Product product in _inventory.GetProductsByCategory(ProductCategoryEnum.Electronics))
                {
                    _products.Add(new ElectronicsViewModel((ElectronicsProduct)product));
                }
                DynamicListView = new ElectronicsViewModel().GetContentListView();
            }
            else if (_perishableGoodsRadioChecked)
            {
                foreach (Product product in _inventory.GetProductsByCategory(ProductCategoryEnum.PerishableGoods))
                {
                    _products.Add(new PerishableGoodsViewModel((PerishableGoodsProduct)product));
                }
                DynamicListView = new PerishableGoodsViewModel().GetContentListView();
            }
            else
            {
                foreach(Product product in _inventory.GetProducts())
                {
                    _products.Add(new ProductViewModel(product));
                }
                DynamicListView = new ProductViewModel().GetContentListView();
            }
            DynamicListView.ItemsSource = _products;
        }
    }
}
