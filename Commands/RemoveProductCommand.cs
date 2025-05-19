using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public class RemoveProductCommand : BaseCommand
    {
        private readonly Inventory _inventory;
        public string ProductID { get; set; }
        public override void Execute(object? parameter)
        {
            Product product = _inventory.GetProducts().FirstOrDefault(p => p.ProductID.ID == ProductID);
            if (_inventory.GetProducts().Contains(product))
            {
                _inventory.RemoveProduct(product);
                MessageBox.Show(("Successfully removed"));
            }
            else
            {
                MessageBox.Show(("not found"));
            }
        }
        public RemoveProductCommand(Inventory inventory, string productID)
        {
            ProductID = productID;
            _inventory = inventory;
        }
    }
}
