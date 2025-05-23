using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Services;
using InventoryManagamentSystem_WPF_DB.Stores;
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
        private readonly InventoryStore _inventoryStore;
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
                LoadProductsCommand.Execute(null);
            }
        }
        public bool ElectronicsRadioChecked
        {
            get => _electronicsRadioChecked;
            set
            {
                _electronicsRadioChecked = value;
                OnPropertyChanged(nameof(ElectronicsRadioChecked));
                LoadProductsCommand.Execute(null);
            }
        }
        public bool PerishableGoodsRadioChecked
        {
            get => _perishableGoodsRadioChecked;
            set
            {
                _perishableGoodsRadioChecked = value;
                OnPropertyChanged(nameof(PerishableGoodsRadioChecked));
                LoadProductsCommand.Execute(null);
            }
        }
        public bool ClothingProductsRadioChecked
        {
            get => _clothingProductsRadioChecked;
            set
            {
                _clothingProductsRadioChecked = value;
                OnPropertyChanged(nameof(ClothingProductsRadioChecked));
                LoadProductsCommand.Execute(null);
            }
        }
        public ICommand ReturnCommand { get; set; }
        public LoadProductsCommand LoadProductsCommand { get; set; }
        public BrowseProductsViewModel(InventoryStore inventoryStore, NavigationService navigationService)
        {
            _inventoryStore = inventoryStore;
            _products = new ObservableCollection<ProductViewModel>();
            ReturnCommand = new NavigateCommand(navigationService);
            LoadProductsCommand = new LoadProductsCommand(inventoryStore, this);
        }
        public static BrowseProductsViewModel LoadViewModel(InventoryStore inventoryStore, NavigationService navigationService)
        {
            BrowseProductsViewModel viewModel = new BrowseProductsViewModel(inventoryStore, navigationService);
            viewModel.LoadProductsCommand.Execute(null);
            return viewModel;
        }
        public void UpdateProducts(IEnumerable<Product> products)
        {
            _products.Clear();
            if (_clothingProductsRadioChecked)
            {
                List<ClothingProduct> clothingProducts = products.Where(p => p.ProductCategory == ProductCategoryEnum.Clothing).Select(p => (ClothingProduct)p).ToList();
                foreach (Product product in clothingProducts)
                {
                    _products.Add(new ClothingProductViewModel((ClothingProduct)product));
                }
                DynamicListView = new ClothingProductViewModel().GetContentListView();
            }
            else if (_electronicsRadioChecked)
            {
                foreach (Product product in products.Where(p => p.ProductCategory == ProductCategoryEnum.Electronics))
                {
                    _products.Add(new ElectronicsViewModel((ElectronicsProduct)product));
                }
                DynamicListView = new ElectronicsViewModel().GetContentListView();  
            }
            else if (_perishableGoodsRadioChecked)
            {
                foreach (Product product in products.Where(p => p.ProductCategory == ProductCategoryEnum.PerishableGoods))
                {
                    _products.Add(new PerishableGoodsViewModel((PerishableGoodsProduct)product));
                }
                DynamicListView = new PerishableGoodsViewModel().GetContentListView();
            }
            else
            {
                foreach (Product product in products)
                {
                    _products.Add(new ProductViewModel(product));
                }
                DynamicListView = new ProductViewModel().GetContentListView();
            }

            DynamicListView.ItemsSource = _products;
        }
    }
}
