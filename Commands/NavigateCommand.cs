using InventoryManagamentSystem_WPF_DB.Services;
using InventoryManagamentSystem_WPF_DB.Stores;
using InventoryManagamentSystem_WPF_DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public class NavigateCommand : BaseCommand
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        /// <summary>
        /// Executes Navigate() in navigation service that changed the current view model
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
