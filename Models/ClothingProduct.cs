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
