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
    public class ProductViewModel: BaseViewModel
    {
        protected readonly Product _product;
        public string? Name => _product.Name;
        public string ProductCategory => _product.ProductCategory.ToString();
        public string Price => _product.Price.ToString();
        public string Quantity => _product.Quantity.ToString();

        public ProductViewModel(Product product)
        {
            _product = product;
        }
        public virtual StackPanel GetDynamicInputStackPanel()
        {
            return new StackPanel();
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
