using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public class ElectronicsProduct: Product
    {
        public decimal Voltage { get; }
        public int BatteryCapacity { get; }
        public ElectronicsProduct(string name, ProductCategoryEnum productCategory, decimal price, int quantity, decimal voltage, int batteryCapacity): base(name, productCategory, price, quantity)
        {
            Voltage = voltage;
            BatteryCapacity = batteryCapacity;
        }

    }
}
