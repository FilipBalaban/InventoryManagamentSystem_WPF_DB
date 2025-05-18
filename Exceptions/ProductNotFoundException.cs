using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public Product Product { get; }

        public ProductNotFoundException(Product product)
        {
            this.Product = product;
        }

        public ProductNotFoundException(string? message, Product product) : base(message)
        {
            this.Product = product;
        }

        public ProductNotFoundException(string? message, Exception? innerException, Product product) : base(message, innerException)
        {
            this.Product = product;
        }

        protected ProductNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Product name: {Product.Name}, ID: {Product.ProductID} does not exist in the inventory!";
    }
}
