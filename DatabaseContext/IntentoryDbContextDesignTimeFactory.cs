using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.DatabaseContext
{
    public class IntentoryDbContextDesignTimeFactory : IDesignTimeDbContextFactory<InventoryDbContext>
    {
        public InventoryDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(@"Data Source=DESKTOP-R16IC6C;Initial Catalog=InventoryManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True").Options;
            return new InventoryDbContext(options);
        }
    }
}
