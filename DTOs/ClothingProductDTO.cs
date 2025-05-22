using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.DTOs
{
    public class ClothingProductDTO: ProductDTO
    {
        [Column(TypeName = "varchar(5)")]
        public string? Size { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string? Fabric { get; set; }
    }
}
