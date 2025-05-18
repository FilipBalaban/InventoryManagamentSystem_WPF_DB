using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public class ProductID
    {
        public int ObjectCounter { get; }
        public string ID { get; }
        public ProductCategoryEnum ProductCategory { get; }

        public ProductID(ProductCategoryEnum productCategory, int objectCounter)
        {
            ProductCategory = productCategory;
            ObjectCounter = objectCounter;
            ID = GenerateID();
        }

        public string GenerateID()
        {
            switch (ProductCategory)
            {
                case ProductCategoryEnum.Electronics:
                    return $"El.{ObjectCounter}";
                case ProductCategoryEnum.PerishableGoods:
                    return $"Pg.{ObjectCounter}";
                case ProductCategoryEnum.Clothing:
                    return $"Cl.{ObjectCounter}";
                default:
                    return string.Empty;
            }
        }
    }
}
