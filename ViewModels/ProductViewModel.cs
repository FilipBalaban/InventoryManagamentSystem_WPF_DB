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
    public class ProductViewModel : BaseViewModel
    {
        private int? _id;
        private string? _name = string.Empty;
        private ProductCategoryEnum _productCategory;
        private decimal _price = 0;
        private int _quantity = 0;
        protected readonly Product _product;

        public int? ID
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
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
                //OnPropertyChanged(nameof(Name));
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
        /// <summary>
        /// Constructor for filling in data from the inventory to the productViewModel so that we can display it
        /// </summary>
        /// <param name="product">Any type of product model</param>
        public ProductViewModel(Product product)
        {
            _product = product;
            ID = product.ID;
            Name = product.Name;
            ProductCategory = product.ProductCategory;
            Price = product.Price;
            Quantity = product.Quantity;
        }
        /// <summary>
        /// Used for displaying a gridView with textBoxes and textBlocks on AddProductViewModel, that represent the properties that need to be filled in trough the textBoxes, that are specific to each product category 
        /// </summary>
        /// <returns>Grid with textBlocks and textBoxes for specific product properties</returns>
        public virtual Grid GetDynamicInputGrid()
        {
            return new Grid();
        }
        /// <summary>
        /// Used for displaying product info on the RemoveProductViewModel
        /// </summary>
        /// <returns>A grid or sometimes a grid inside of a border that contains product data</returns>
        public virtual UIElement GetDynamicDataGrid()
        {
            Grid grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition()); // Row 0
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) }); // 1
            grid.RowDefinitions.Add(new RowDefinition()); // 2
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) }); // 3
            grid.RowDefinitions.Add(new RowDefinition()); // 4

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(8) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.DataContext = this;

            // Name
            StackPanel nameStackPanel = GetTextBlockStackPanel("Name");
            Grid.SetRow(nameStackPanel, 0);
            grid.Children.Add(nameStackPanel);

            // Price
            StackPanel priceStackPanel = GetTextBlockStackPanel("Price", "$");
            Grid.SetRow(priceStackPanel, 2);
            grid.Children.Add(priceStackPanel);

            // ProductCategory
            StackPanel category = GetTextBlockStackPanel("ProductCategory");
            Grid.SetRow(category, 0);
            Grid.SetColumn(category, 2);
            grid.Children.Add(category);

            // Quantity
            StackPanel quantity = GetTextBlockStackPanel("Quantity");
            Grid.SetRow(quantity, 2);
            Grid.SetColumn(quantity, 2);
            grid.Children.Add(quantity);

            return grid;
        }
        /// <summary>
        /// Used for displaying product data on BrowseProductViewModel - displaying a list view
        /// </summary>
        /// <returns>List view with product information</returns>
        public virtual ListView GetContentListView()
        {
            ListView listView = new ListView();
            GridView gridView = GetBaseGridView();
            listView.View = gridView;

            return listView;
        }
        /// <summary>
        /// Returns if all product properties are filled - if true we can add the product in the AddProductViewModel
        /// </summary>
        /// <returns>Bool value that is true if all properties of a product are filled</returns>
        public virtual bool ArePropertiesFilled()
        {
            return !string.IsNullOrEmpty(_name) && _price > 0 && _quantity > 0;
        }
        // Clears all the properties when we switch product category on the addProductViewModel for example, we do this because some properties appear like they are cleared ant that txtBox is empty but it still holds data
        public virtual void ClearProperties()
        {
            Name = string.Empty;
            Price = 0;
            Quantity = 0;
        }
        /// <summary>
        /// Helper method to get the the basePropertiesGrid for GetDynamicDataGrid (it lets all inherited classes get the data grid with base class properties, but this returns a grid as opposed to the GetDynamicDataGrid which is not private and which returns a listview)
        /// </summary>
        /// <returns>Grid with base properties</returns>
        protected Grid GetBasePropertiesGrid()
        {
            Grid grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition()); // 0
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) }); // 1
            grid.RowDefinitions.Add(new RowDefinition()); // 2

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(8) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.DataContext = this;

            // Name
            StackPanel nameStackPanel = GetTextBlockStackPanel("Name");
            Grid.SetRow(nameStackPanel, 0);
            grid.Children.Add(nameStackPanel);

            // Price
            StackPanel priceStackPanel = GetTextBlockStackPanel("Price", "$");
            Grid.SetRow(priceStackPanel, 2);
            grid.Children.Add(priceStackPanel);

            // ProductCategory
            StackPanel category = GetTextBlockStackPanel("ProductCategory");
            Grid.SetRow(category, 0);
            Grid.SetColumn(category, 2);
            grid.Children.Add(category);

            // Quantity
            StackPanel quantity = GetTextBlockStackPanel("Quantity");
            Grid.SetRow(quantity, 2);
            Grid.SetColumn(quantity, 2);
            grid.Children.Add(quantity);

            return grid;
        }
        /// <summary>
        /// Helper method that creates a stackpanel with two stack blocks - one that acts as a label for the property and one that holds the value
        /// </summary>
        /// <param name="property">Name of the property of a product</param>
        /// <param name="suffix">If we need to add a suffix at the end of product data</param>
        /// <returns>Stackpanel with two stack blocks</returns>
        protected StackPanel GetTextBlockStackPanel(string property, string? suffix = null)
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = FromPascalCase(property) + ":",
                Margin = new Thickness(0, 0, 8, 0)
            };
            TextBlock textBlockValue = new TextBlock();
            Binding textBinding = new Binding(property);

            string[] basePropertyNames = { "Name", "ProductCategory", "Price", "Quantity" };
            bool isBaseProperty = false;
            foreach(string p in basePropertyNames)
            {
                if(property == p)
                {
                    isBaseProperty = true;
                }
            }
            // Is a property is not a base class proeprty - adds a "Product." so that it can nest and access an inheritad class proepty
            if (!isBaseProperty)
            {
                property = $"Product.{property}";
            }

            textBlockValue.SetBinding(TextBlock.TextProperty, textBinding);

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(textBlockValue);
            if(suffix != null)
            {
                stackPanel.Children.Add(new TextBlock { Text = suffix });
            }
            return stackPanel;
        }
        /// <summary>
        /// Helper method for getting the base grid for the grid view
        /// </summary>
        /// <returns>Grid with base properties</returns>
        protected GridView GetBaseGridView()
        {
            GridView gridView = new GridView();

            // ID
            Binding idBinding = new Binding("ID");
            GridViewColumn idColumn = new GridViewColumn()
            {
                Header = "ID:",
                DisplayMemberBinding = idBinding,
                Width = 100
            };
            gridView.Columns.Add(idColumn);

            // Name
            GridViewColumn nameColumn = new GridViewColumn()
            {
                Header = "Name:",
                DisplayMemberBinding = new Binding("Name"),
                Width = 100

            };
            gridView.Columns.Add(nameColumn);

            // Category
            GridViewColumn categoryColumn = new GridViewColumn()
            {
                Header = "Category:",
                DisplayMemberBinding = new Binding("ProductCategory"),
                Width = 140
            };
            gridView.Columns.Add(categoryColumn);

            // Price
            GridViewColumn priceColumn = new GridViewColumn()
            {
                Header = "Price:",
                DisplayMemberBinding = new Binding("Price"),
                Width = 100
            };
            gridView.Columns.Add(priceColumn);

            // Quantity
            GridViewColumn quantityColumn = new GridViewColumn()
            {
                Header = "Quantity:",
                DisplayMemberBinding = new Binding("Quantity"),
                Width = 100
            };
            gridView.Columns.Add(quantityColumn);

            return gridView;
        }
        /// <summary>
        /// Helper method that converts from pascal case which is used for property names to normal case that can be displayed on the UI
        /// </summary>
        /// <param name="str">PascalCase string</param>
        /// <returns>Returns a string converted from pascal case to normal case</returns>
        private string FromPascalCase(string str)
        {
            int upperCount = str.Where(c => char.IsUpper(c)).Count();
            char[] arr = new char[str.Length + upperCount];
            for (int i = 0, j = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]) && i > 0)
                {
                    arr[j] = ' ';
                    arr[j + 1] = char.ToLower(str[i]);
                    j++;
                }
                else
                {
                    arr[j] = str[i];
                }
                j++;
            }
            return new String(arr);
        }
    }
}
