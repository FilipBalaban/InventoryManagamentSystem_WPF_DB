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
        public ProductID? ProductID { get; }
        public string? Name { get; }
        public ProductCategoryEnum ProductCategory { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        protected Product(string name, ProductCategoryEnum productCategory, decimal price, int quantity)
        {
            Name = name;
            ProductCategory = productCategory;
            Price = price;
            Quantity = quantity;
            switch (productCategory)
            {
                case ProductCategoryEnum.Electronics:
                    _electronicsProductCounter++;
                    ProductID = new ProductID(productCategory, _electronicsProductCounter);
                    break;
                case ProductCategoryEnum.PerishableGoods:
                    _perishableGoodsProductCounter++;
                    ProductID = new ProductID(productCategory, _perishableGoodsProductCounter);
                    break;
                case ProductCategoryEnum.Clothing:
                    _clothingProductCounter++;
                    ProductID = new ProductID(productCategory, _clothingProductCounter);
                    break;
            }
        }
        public override string ToString()
        {
            return $"ID: {ProductID.ID}\nName: {Name}\nCategory: {ProductCategory}\nPrice: {Price}\nQuantity: {Quantity}";
        }
    }
}
