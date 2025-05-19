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
    }
}
