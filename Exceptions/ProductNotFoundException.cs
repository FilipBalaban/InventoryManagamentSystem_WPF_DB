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
        public Product product { get; }

        public ProductNotFoundException(Product product)
        {
            this.product = product;
        }

        public ProductNotFoundException(string? message, Product product) : base(message)
        {
            this.product = product;
        }

        public ProductNotFoundException(string? message, Exception? innerException, Product product) : base(message, innerException)
        {
            this.product = product;
        }

        protected ProductNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
