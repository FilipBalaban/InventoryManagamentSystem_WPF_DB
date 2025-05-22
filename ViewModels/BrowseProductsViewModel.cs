using InventoryManagamentSystem_WPF_DB.Models;
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
        public BrowseProductsViewModel(Inventory inventory)
        {
            _inventory = inventory;
            Product product = new ElectronicsProduct("Phone", ProductCategoryEnum.Electronics, 253, 5, 235, 5);
            _inventory.AddProduct(product);
            product = new ClothingProduct("Hoodie", ProductCategoryEnum.Clothing, 89.99m, 1, ClothingFabricEnum.Silk, ClothingSizeEnum.M);
            _inventory.AddProduct(product);
            product = new PerishableGoodsProduct("Apple", ProductCategoryEnum.PerishableGoods, 1.99m, 1, 50, 75, new DateTime(2025, 7, 1));
            _inventory.AddProduct(product);

            _products = new ObservableCollection<ProductViewModel>();
            AllProductsRadioChecked = true;
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
