using InventoryManagamentSystem_WPF_DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Exceptions
{
    public class InvalidDbProductCategoryException : Exception
    {
        ProductDTO ProductDTO { get; }

        public InvalidDbProductCategoryException(ProductDTO productDTO)
        {
            ProductDTO = productDTO;
        }

        public InvalidDbProductCategoryException(string? message, ProductDTO productDTO) : base(message)
        {
            ProductDTO = productDTO;
        }

        public InvalidDbProductCategoryException(string? message, Exception? innerException, ProductDTO productDTO) : base(message, innerException)
        {
            ProductDTO = productDTO;
        }

        protected InvalidDbProductCategoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Product: {ProductDTO.Name} with an ID: {ProductDTO.ID} has an invalid category and was most likely modified!";
    }
}
