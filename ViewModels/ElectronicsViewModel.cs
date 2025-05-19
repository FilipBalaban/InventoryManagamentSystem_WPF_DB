using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class ElectronicsViewModel : ProductViewModel
    {
        private decimal _voltage;
        private int _batteryCapacity;
        public decimal Voltage
        {
            get => _voltage;
            set
            {
                _voltage = value;
                OnPropertyChanged(nameof(Voltage));
            }
        }
        public int BatteryCapacity
        {
            get => _batteryCapacity;
            set
            {
                _batteryCapacity = value;
                OnPropertyChanged(nameof(BatteryCapacity));
            }
        }

        public ElectronicsViewModel()
        {
            ProductCategory = ProductCategoryEnum.Electronics;
        }

        public ElectronicsViewModel(ElectronicsProduct product): base(product)
        {
            ProductCategory = ProductCategoryEnum.Electronics;
        }

        public override GridView GetContentGridView()
        {
            throw new NotImplementedException();
        }

        public override StackPanel GetDynamicDataStackPanel()
        {
            throw new NotImplementedException();
        }

        public override Grid GetDynamicInputGrid()
        {
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8)});
            grid.RowDefinitions.Add(new RowDefinition());

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(8)});
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Voltage
            TextBlock voltageBlock = new TextBlock()
            {
                Text = "Voltage:"
            };
            TextBox voltageBox = new TextBox();
            Binding voltageBinding = new Binding("Product.Voltage");
            voltageBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            voltageBox.SetBinding(TextBox.TextProperty, voltageBinding);

            Grid.SetRow(voltageBlock, 0);
            Grid.SetRow(voltageBox, 2);
            grid.Children.Add(voltageBlock);
            grid.Children.Add(voltageBox);

            // Battery capacity
            TextBlock batteryBlock = new TextBlock()
            {
                Text = "Battery capacity:"
            };
            Grid.SetColumn(batteryBlock, 2);
            TextBox batteryBox = new TextBox();
            Binding batteryBinding = new Binding("Product.BatteryCapacity");
            batteryBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            batteryBox.SetBinding(TextBox.TextProperty, batteryBinding);
            Grid.SetColumn(batteryBox, 2);
            Grid.SetRow(batteryBox, 2);
            grid.Children.Add(batteryBlock);
            grid.Children.Add(batteryBox);

            return grid;
        }
    }
}
