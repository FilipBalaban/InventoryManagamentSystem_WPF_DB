using InventoryManagamentSystem_WPF_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Exceptions
{
    public class DuplicateProductException : Exception
    {
        public Product DuplicateProduct { get; }
        public DuplicateProductException(Product duplicateProduct)
        {
            DuplicateProduct = duplicateProduct;
        }

        public DuplicateProductException(string? message, Product duplicateProduct) : base(message)
        {
            DuplicateProduct = duplicateProduct;
        }

        public DuplicateProductException(string? message, Exception? innerException, Product duplicateProduct) : base(message, innerException)
        {
            DuplicateProduct = duplicateProduct;
        }

        protected DuplicateProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Product name: {DuplicateProduct.Name}, ID: {DuplicateProduct.ProductID} already exists in the inventory!";
    }
}
