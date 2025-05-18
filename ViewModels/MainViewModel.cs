using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class MainViewModel
    {
        public BaseViewModel CurrentViewModel { get; set; }
        public MainViewModel()
        {
            CurrentViewModel = new MainMenuViewModel();
        }

    }
}
