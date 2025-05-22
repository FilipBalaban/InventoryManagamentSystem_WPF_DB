using InventoryManagamentSystem_WPF_DB.Commands;
using InventoryManagamentSystem_WPF_DB.Services;
using InventoryManagamentSystem_WPF_DB.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class MainMenuViewModel: BaseViewModel
    {
        public ICommand AddProductCommand { get; }
        public ICommand RemoveProductCommand { get; }
        public ICommand BrowseProductsCommand { get; }
        public ICommand QuitCommand { get; }
        public MainMenuViewModel(NavigationService addProductNavigationService, NavigationService removeProductNavigationService, NavigationService browseProductsNavigationService)
        {
            AddProductCommand = new NavigateCommand(addProductNavigationService);
            RemoveProductCommand = new NavigateCommand(removeProductNavigationService);
            BrowseProductsCommand = new NavigateCommand(browseProductsNavigationService);
            QuitCommand = new QuitCommand();
        }
    }
}
