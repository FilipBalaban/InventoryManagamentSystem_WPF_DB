using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace InventoryManagamentSystem_WPF_DB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Inventory _inventory;
        public App()
        {
            _inventory = new Inventory();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_inventory)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
