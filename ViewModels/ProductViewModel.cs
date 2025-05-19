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
        private string? _name = string.Empty;
        private ProductCategoryEnum _productCategory;
        private decimal _price = 0;
        private int _quantity = 0;
        protected readonly Product _product;
        private Grid _dynamicGrid;

        public string? Name
        {
            get => _name;
            set
            {
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public ProductCategoryEnum ProductCategory
        {
            get => _productCategory;
            set
            {
                _productCategory = value;
                OnPropertyChanged(nameof(ProductCategory));
                OnPropertyChanged(nameof(Name));
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
        public virtual Grid GetDynamicDataGrid()
        {
            return new Grid();
        }
        public virtual GridView GetContentGridView()
        {
            return new GridView();
        }
        public virtual bool ArePropertiesFilled()
        {
            return !string.IsNullOrEmpty(_name) && _price > 0 && _quantity > 0;
        }
        public virtual void ClearProperties()
        {
            Name = string.Empty;
            Price = 0;
            Quantity = 0;
        }
    }
}
