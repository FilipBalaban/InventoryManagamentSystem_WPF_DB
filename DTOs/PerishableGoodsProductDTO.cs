using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.DTOs
{
    public class PerishableGoodsProductDTO: ProductDTO
    {
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Calories { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Weight { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
