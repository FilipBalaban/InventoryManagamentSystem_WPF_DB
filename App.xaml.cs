using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Services;
using InventoryManagamentSystem_WPF_DB.Stores;
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
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _inventory = new Inventory();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateMainMenuViewModel();
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
        private MainMenuViewModel CreateMainMenuViewModel()
        {
            return new MainMenuViewModel(new NavigationService(_navigationStore, CreateAddProductViewModel), new NavigationService(_navigationStore, CreateRemoveProductViewModel), new NavigationService(_navigationStore, CreateBrowseProductsViewModel));
        }
        private AddProductViewModel CreateAddProductViewModel()
        {
            return new AddProductViewModel(_inventory, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
        private RemoveProductViewModel CreateRemoveProductViewModel()
        {
            return new RemoveProductViewModel(_inventory, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
        private BrowseProductsViewModel CreateBrowseProductsViewModel()
        {
            return new BrowseProductsViewModel(_inventory, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
    }

}
