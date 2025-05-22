using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.DTOs
{
    public class ProductDTO
    {
        [Key]
        public Guid ID { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Category { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
