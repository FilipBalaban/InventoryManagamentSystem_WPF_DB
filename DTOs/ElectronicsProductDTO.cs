using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.DTOs
{
    public class ElectronicsProductDTO: ProductDTO
    {
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Voltage { get; set; }
        public int BatteryCapacity { get; set; }
    }
}
