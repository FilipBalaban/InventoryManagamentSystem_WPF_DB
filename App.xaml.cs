using InventoryManagamentSystem_WPF_DB.DatabaseContext;
using InventoryManagamentSystem_WPF_DB.DTOs;
using InventoryManagamentSystem_WPF_DB.Models;
using InventoryManagamentSystem_WPF_DB.Services;
using InventoryManagamentSystem_WPF_DB.Services.InventoryManagers;
using InventoryManagamentSystem_WPF_DB.Stores;
using InventoryManagamentSystem_WPF_DB.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private const string CONNECTION_STRING = "Data Source=InventoryManagement.db";
        private InventoryDbContextFactory _inventoryDbContextFactory;
        private readonly InventoryStore _inventoryStore;
        public App()
        {
            _inventoryDbContextFactory = new InventoryDbContextFactory(CONNECTION_STRING);
            DatabaseInventoryManager databaseInventoryManager = new DatabaseInventoryManager(_inventoryDbContextFactory);

            _inventory = new Inventory(new InventoryBook(databaseInventoryManager));
            _navigationStore = new NavigationStore();
            _inventoryStore = new InventoryStore(_inventory);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (InventoryDbContext dbContext = _inventoryDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

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
            return new AddProductViewModel(_inventoryStore, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
        private RemoveProductViewModel CreateRemoveProductViewModel()
        {
            return new RemoveProductViewModel(_inventoryStore, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
        private BrowseProductsViewModel CreateBrowseProductsViewModel()
        {
            return BrowseProductsViewModel.LoadViewModel(_inventoryStore, new NavigationService(_navigationStore, CreateMainMenuViewModel));
        }
    }

}
