using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public abstract class Product
    {
        private static int _electronicsProductCounter;
        private static int _perishableGoodsProductCounter;
        private static int _clothingProductCounter;
        public int ID { get; }
        public string? Name { get; }
        public ProductCategoryEnum ProductCategory { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        protected Product(int id, string name, ProductCategoryEnum productCategory, decimal price, int quantity)
        {
            ID = id;
            Name = name;
            ProductCategory = productCategory;
            Price = price;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"ID: {ID}\nName: {Name}\nCategory: {ProductCategory}\nPrice: {Price}\nQuantity: {Quantity}";
        }
    }
}
