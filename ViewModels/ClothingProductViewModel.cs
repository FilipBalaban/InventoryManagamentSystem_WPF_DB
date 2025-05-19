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
    public class ClothingProductViewModel : ProductViewModel
    {
        private ClothingSizeEnum _size;
        private ClothingFabricEnum _fabric;
        public ClothingSizeEnum Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }
        public ClothingFabricEnum Fabric
        {
            get => _fabric;
            set
            {
                _fabric = value;
                OnPropertyChanged(nameof(Fabric));
            }
        }
        public ClothingProductViewModel()
        {
            ProductCategory = ProductCategoryEnum.Clothing;
        }
        public ClothingProductViewModel(ClothingProduct product) : base(product)
        {
            ProductCategory = ProductCategoryEnum.Clothing;
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
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) });
            grid.RowDefinitions.Add(new RowDefinition());

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(8) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Size
            TextBlock sizeBlock = new TextBlock()
            {
                Text = "Size:"
            };
            ComboBox sizeBox = new ComboBox();
            Binding sizeBinding = new Binding("Product.Size");
            sizeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            sizeBox.ItemsSource = Enum.GetValues(typeof(ClothingSizeEnum));
            sizeBox.SetBinding(ComboBox.SelectedItemProperty, sizeBinding);


            Grid.SetRow(sizeBlock, 0);
            Grid.SetRow(sizeBox, 2);
            grid.Children.Add(sizeBlock);
            grid.Children.Add(sizeBox);

            // Size
            TextBlock fabricBlock = new TextBlock()
            {
                Text = "Fabric:"
            };
            ComboBox fabricBox = new ComboBox();
            Binding fabricBinding = new Binding("Product.Fabric");
            fabricBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            fabricBox.ItemsSource = Enum.GetValues(typeof(ClothingFabricEnum));
            fabricBox.SetBinding(ComboBox.SelectedItemProperty, fabricBinding);

            Grid.SetColumn(fabricBlock, 2);
            Grid.SetColumn(fabricBox, 2);
            Grid.SetRow(fabricBlock, 0);
            Grid.SetRow(fabricBox, 2);
            grid.Children.Add(fabricBlock);
            grid.Children.Add(fabricBox);

            return grid;
        }
    }
}
