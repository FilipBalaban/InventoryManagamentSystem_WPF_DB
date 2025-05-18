using InventoryManagamentSystem_WPF_DB.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Models
{
    public class InventoryBook
    {
        private readonly List<Product> _products;

        public InventoryBook()
        {
            _products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            if(!_products.Contains(_products.FirstOrDefault(p => p.ProductID.Equals(product.ProductID)))) 
            {
                _products.Add(product);
            }
            else
            {
                throw new DuplicateProductException(product);
            }
        }
        public void RemoveProduct(Product product)
        {
            if (_products.Contains(_products.FirstOrDefault(p => p.ProductID.Equals(product.ProductID)))) 
            {
                _products.Remove(product);
            }
            else
            {
                throw new ProductNotFoundException(product);
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
        public IEnumerable<Product> GetProductByCategory(ProductCategoryEnum category)
        {
            return _products.Where(p => p.ProductCategory == category);
        }
    }
}
