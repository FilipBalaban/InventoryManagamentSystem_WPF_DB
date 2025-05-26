using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public class ClothingProduct : Product
    {
        public ClothingFabricEnum Fabric { get; }
        public ClothingSizeEnum Size { get; }
        // Used for filling in data into it from viewModel (ID is not needed as later it will be filled in from db)
        public ClothingProduct(string name, ProductCategoryEnum productCategory, decimal price, int quantity, ClothingFabricEnum fabric, ClothingSizeEnum size) : base(name, productCategory, price, quantity)
        {
            Fabric = fabric;
            Size = size;
        }
        // Used for filling in data into it from db
        public ClothingProduct(int id, string name, ProductCategoryEnum productCategory, decimal price, int quantity, ClothingFabricEnum fabric, ClothingSizeEnum size) : base(id, name, productCategory, price, quantity)
        {
            Fabric = fabric;
            Size = size;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nFabric: {Fabric}\nSize: {Size}";
        }
    }
}
