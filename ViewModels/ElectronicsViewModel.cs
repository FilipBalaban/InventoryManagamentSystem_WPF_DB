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
    public class ElectronicsViewModel : ProductViewModel
    {
        public string Voltage => ((ElectronicsProduct)_product).Voltage.ToString();
        public string BatteryCapacity => ((ElectronicsProduct)_product).BatteryCapacity.ToString();

        public ElectronicsViewModel(ElectronicsProduct product): base(product)
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
