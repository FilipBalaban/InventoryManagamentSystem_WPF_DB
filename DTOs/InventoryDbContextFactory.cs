using InventoryManagamentSystem_WPF_DB.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.DTOs
{
    public class InventoryDbContextFactory
    {
        private readonly string _connectionString;

        public InventoryDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public InventoryDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;
            return new InventoryDbContext(options);
        }

    }
}
