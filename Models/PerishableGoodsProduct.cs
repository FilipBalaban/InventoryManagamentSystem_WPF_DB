using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public class PerishableGoodsProduct : Product
    {
        public decimal Calories { get; }
        public decimal Weight { get; }
        public DateTime ExpirationDate { get; }
        public PerishableGoodsProduct(string name, ProductCategoryEnum productCategory, decimal price, int quantity, decimal calories, decimal weight, DateTime expirationDate) : base(name, productCategory, price, quantity)
        {
            Calories = calories;
            Weight = weight;
            ExpirationDate = expirationDate;
        }
        public PerishableGoodsProduct(int id, string name, ProductCategoryEnum productCategory, decimal price, int quantity, decimal calories, decimal weight, DateTime expirationDate) : base(id, name, productCategory, price, quantity)
        {
            Calories = calories;
            Weight = weight;
            ExpirationDate = expirationDate;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nWeight: {Weight}\nCalories: {Calories}\nExpiration Date: {ExpirationDate}";
        }
    }
}
