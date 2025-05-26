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
    public class PerishableGoodsViewModel : ProductViewModel
    {
        private decimal _calories;
        private decimal _weight;
        private DateTime _expirationDate = DateTime.Now;

        public decimal Calories
        {
            get => _calories;
            set
            {
                _calories = value;
                OnPropertyChanged(nameof(Calories));
            }
        }
        public decimal Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set
            {
                _expirationDate = value;
                OnPropertyChanged(nameof(ExpirationDate));
            }
        }

        public PerishableGoodsViewModel()
        {
            ProductCategory = ProductCategoryEnum.PerishableGoods;

        }
        public PerishableGoodsViewModel(PerishableGoodsProduct product): base(product)
        {
            ProductCategory = ProductCategoryEnum.PerishableGoods;
            Calories = product.Calories;
            Weight = product.Weight;
            ExpirationDate = product.ExpirationDate;
        }
        public override ListView GetContentListView()
        {
            ListView listView = new ListView();
            GridView gridView = GetBaseGridView();

            // Calories
            GridViewColumn caloriesColumn = new GridViewColumn()
            {
                Header = "Calories",
                DisplayMemberBinding = new Binding("Calories"),
                Width = 100,
            };
            gridView.Columns.Add(caloriesColumn);

            // Weight
            GridViewColumn weightColumn = new GridViewColumn()
            {
                Header = "Weight",
                DisplayMemberBinding = new Binding("Weight"),
                Width = 100,
            };
            gridView.Columns.Add(weightColumn);

            // Expiration Date
            GridViewColumn expirationDateColumn = new GridViewColumn()
            {
                Header = "Expiration Date",
                DisplayMemberBinding = new Binding("ExpirationDate"),
                Width = 180,
            };
            gridView.Columns.Add(expirationDateColumn);

            listView.View = gridView;
            return listView;
        }
        public override UIElement GetDynamicDataGrid()
        {
            Grid grid = GetBasePropertiesGrid();

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) }); // 3
            grid.RowDefinitions.Add(new RowDefinition()); // 4
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) }); // 5
            grid.RowDefinitions.Add(new RowDefinition()); // 6

            // Calories
            StackPanel caloriesTackPanel = GetTextBlockStackPanel("Calories");
            Grid.SetRow(caloriesTackPanel, 4);
            Grid.SetColumn(caloriesTackPanel, 0);
            grid.Children.Add(caloriesTackPanel);

            // Weight
            StackPanel weightStackPanel = GetTextBlockStackPanel("Weight");
            Grid.SetRow(weightStackPanel, 4);
            Grid.SetColumn(weightStackPanel, 2);
            grid.Children.Add(weightStackPanel);

            // ExpirationDate
            StackPanel expirationDateStackPanel = GetTextBlockStackPanel("ExpirationDate");
            Grid.SetRow(expirationDateStackPanel, 6);
            Grid.SetColumn(expirationDateStackPanel, 0);
            grid.Children.Add(expirationDateStackPanel);

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

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) });
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) });
            grid.RowDefinitions.Add(new RowDefinition());

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(8) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Calories
            TextBlock caloriesBlock = new TextBlock()
            {
                Text = "Calories:"
            };
            TextBox caloriesBox = new TextBox();
            Binding caloriesBinding = new Binding("Product.Calories");
            caloriesBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            caloriesBox.SetBinding(TextBox.TextProperty, caloriesBinding);

            Grid.SetRow(caloriesBlock, 0);
            Grid.SetRow(caloriesBox, 2);
            grid.Children.Add(caloriesBlock);
            grid.Children.Add(caloriesBox);

            // Weight
            TextBlock weightBlock = new TextBlock()
            {
                Text = "Weight:"
            };
            TextBox weightBox = new TextBox();
            Binding weightBinding = new Binding("Product.Weight");
            weightBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            weightBox.SetBinding(TextBox.TextProperty, weightBinding);

            Grid.SetRow(weightBlock, 0);
            Grid.SetColumn(weightBlock, 2);
            Grid.SetRow(weightBox, 2);
            Grid.SetColumn(weightBox, 2);
            grid.Children.Add(weightBlock);
            grid.Children.Add(weightBox);

            // Expiration date
            TextBlock expirationDateBlock = new TextBlock()
            {
                Text = "Expiration date:"
            };
            DatePicker expirationDateBox = new DatePicker();
            Binding expirationDateBinding = new Binding("Product.ExpirationDate");
            expirationDateBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            expirationDateBox.SetBinding(DatePicker.SelectedDateProperty, expirationDateBinding);

            Grid.SetRow(expirationDateBlock, 4);
            Grid.SetRow(expirationDateBox, 6);
            grid.Children.Add(expirationDateBlock);
            grid.Children.Add(expirationDateBox);

            return grid;
        }
        public override bool ArePropertiesFilled()
        {
            return base.ArePropertiesFilled() && _calories > 0 && _weight > 0;
        }
    }
}
