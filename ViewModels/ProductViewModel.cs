using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private string? _name;
        private ProductCategoryEnum _productCategory;
        private decimal _price;
        private int _quantity;
        protected readonly Product _product;
        private Grid _dynamicGrid;

        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ProductCategoryEnum ProductCategory
        {
            get => _productCategory;
            set
            {
                _productCategory = value;
                OnPropertyChanged(nameof(ProductCategory));
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public Grid DynamicGrid
        {
            get => _dynamicGrid;
            set
            {
                _dynamicGrid = value;
                OnPropertyChanged(nameof(DynamicGrid));
            }
        }
        public ProductViewModel()
        {
            
        }
        public ProductViewModel(Product product)
        {
            _product = product;
        }
        public virtual Grid GetDynamicInputGrid()
        {
            return new Grid();
        }
        public virtual StackPanel GetDynamicDataStackPanel()
        {
            return new StackPanel();
        }
        public virtual GridView GetContentGridView()
        {
            return new GridView();
        }
    }
}
