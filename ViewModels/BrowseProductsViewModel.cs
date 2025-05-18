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
        public IEnumerable<ProductViewModel> Products => _products;
        public bool AllProductsRadioChecked { get; set; }
        public bool ElectronicsRadioChecked { get; set; }
        public bool PerishableGoodsRadioChecked { get; set; }
        public bool ClothingProductRadioChecked { get; set; }
        public ICommand ReturnCommand { get; set; }
        public BrowseProductsViewModel()
        {
            _inventory = new Inventory();
            _products = new ObservableCollection<ProductViewModel>();
        }
        public void UpdateProducts()
        {
            _products.Clear();
            foreach(Product product in _inventory.GetProducts())
            {
                _products.Add(new ProductViewModel(product));
            }
        }
    }
}
