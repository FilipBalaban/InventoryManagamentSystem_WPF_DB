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
    public class PerishableGoodsViewModel : ProductViewModel
    {
        public string Calories => ((PerishableGoodsProduct)_product).Calories.ToString();
        public string Weight => ((PerishableGoodsProduct)_product).Weight.ToString();
        public string ExpirationDate => ((PerishableGoodsProduct)_product).ExpirationDate.ToString();


        public PerishableGoodsViewModel(PerishableGoodsProduct product): base(product)
        {
            
        }

        public override GridView GetContentGridView()
        {
            throw new NotImplementedException();
        }

        public override StackPanel GetDynamicDataStackPanel()
        {
            throw new NotImplementedException();
        }

        public override StackPanel GetDynamicInputStackPanel()
        {
            throw new NotImplementedException();
        }
    }
}
