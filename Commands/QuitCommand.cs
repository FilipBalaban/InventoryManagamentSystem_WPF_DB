using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public class QuitCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var result = MessageBox.Show("Are you sure that you want to quit the program?", "Quit?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
        }
    }
}
