using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

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
            Fabric = product.Fabric;
            Size = product.Size;
        }
        public override ListView GetContentListView()
        {
            ListView listView = new ListView();
            GridView gridView = GetBaseGridView();

            // Fabric
            GridViewColumn fabricColumn = new GridViewColumn()
            {
                Header = "Fabric",
                DisplayMemberBinding = new Binding("Fabric"),
                Width = 100,
            };
            gridView.Columns.Add(fabricColumn);

            // Size
            GridViewColumn sizeCapacityColumn = new GridViewColumn()
            {
                Header = "Size",
                DisplayMemberBinding = new Binding("Size"),
                Width = 100,
            };
            gridView.Columns.Add(sizeCapacityColumn);
            listView.View = gridView;
            return listView;
        }
        public override UIElement GetDynamicDataGrid()
        {
            Grid grid = GetBasePropertiesGrid();

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) }); // 3
            grid.RowDefinitions.Add(new RowDefinition()); // 4

            // Fabric
            StackPanel fabricStackPanel = GetTextBlockStackPanel("Fabric");
            Grid.SetRow(fabricStackPanel, 4);
            Grid.SetColumn(fabricStackPanel, 0);
            grid.Children.Add(fabricStackPanel);

            // Size
            StackPanel sizeStackPanel = GetTextBlockStackPanel("Size");
            Grid.SetRow(sizeStackPanel, 4);
            Grid.SetColumn(sizeStackPanel, 2);
            grid.Children.Add(sizeStackPanel);

            Border border = new Border
            {
                Background = new SolidColorBrush(Colors.LightGray),
                Padding = new Thickness(10),
            };

            border.Child = grid;
            return border;
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
