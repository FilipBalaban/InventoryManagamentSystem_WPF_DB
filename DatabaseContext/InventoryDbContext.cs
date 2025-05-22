using InventoryManagamentSystem_WPF_DB.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.DatabaseContext
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<ElectronicsProductDTO> ElectronicProducts {get; set;}
        public DbSet<PerishableGoodsProductDTO> PerishableGoodsProducts {get; set;}
        public DbSet<ClothingProductDTO> ClothingProducts {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductDTO>().ToTable("Products");
            modelBuilder.Entity<ElectronicsProductDTO>().ToTable("ElectronicProducts");
            modelBuilder.Entity<PerishableGoodsProductDTO>().ToTable("PerishableGoodsProducts");
            modelBuilder.Entity<ClothingProductDTO>().ToTable("ClothingProducts");
        }
    }
}
