using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManagamentSystem_WPF_DB.ViewModels
{
    public class RemoveProductViewModel: BaseViewModel
    {
        private string? _productID;
        public string? ProductID
        {
            get => _productID;
            set
            {
                _productID = value;
                OnPropertyChanged(nameof(ProductID));
            }
        }
        public ICommand SearchCommand { get; }
        public ICommand RemoveProductCommand { get; }
        public ICommand CancelCommand { get; }

    }
}
