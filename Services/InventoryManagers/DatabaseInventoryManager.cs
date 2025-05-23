using InventoryManagamentSystem_WPF_DB.DatabaseContext;
using InventoryManagamentSystem_WPF_DB.DTOs;
using InventoryManagamentSystem_WPF_DB.Exceptions;
using InventoryManagamentSystem_WPF_DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Services.InventoryManagers
{
    public class DatabaseInventoryManager : IInventoryManager
    {
        private readonly InventoryDbContextFactory _inventoryDbContextFactory;
        public DatabaseInventoryManager(InventoryDbContextFactory inventoryDbContextFactory)
        {
            _inventoryDbContextFactory = inventoryDbContextFactory;
        }
        public async Task AddProduct(Product product)
        {
            using(InventoryDbContext dbContext = _inventoryDbContextFactory.CreateDbContext())
            {
                switch (product.ProductCategory)
                {
                    case ProductCategoryEnum.Electronics:
                        dbContext.Add(ToElectronicsProductDTO((ElectronicsProduct)product));
                        break;
                    case ProductCategoryEnum.PerishableGoods:
                        dbContext.Add(ToPerishableGoodsProductDTO((PerishableGoodsProduct)product));
                        break;
                    case ProductCategoryEnum.Clothing:
                        dbContext.Add(ToClothingProductDTO((ClothingProduct)product));
                        break;
                }
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using(InventoryDbContext dbContext = _inventoryDbContextFactory.CreateDbContext())
            {
                List<ProductDTO> productDTOs = await dbContext.Products.ToListAsync();
                return productDTOs.Select(p => ToProduct(p));
            }
        }
        public async Task<IEnumerable<Product>> GetProductsByCategory(ProductCategoryEnum category)
        {
            using (InventoryDbContext dbContext = _inventoryDbContextFactory.CreateDbContext())
            {
                List<ProductDTO> productDTOs = await dbContext.Products.ToListAsync();
                List<Product> products = productDTOs.Select(p => ToProduct(p)).ToList();
                switch (category)
                {
                    case ProductCategoryEnum.Electronics:
                        return products.Where(p => p.ProductCategory == ProductCategoryEnum.Electronics);
                    case ProductCategoryEnum.PerishableGoods:
                        return products.Where(p => p.ProductCategory == ProductCategoryEnum.PerishableGoods);
                    case ProductCategoryEnum.Clothing:
                        return products.Where(p => p.ProductCategory == ProductCategoryEnum.Clothing);
                }
                return null;
            }
        }
        public async Task RemoveProduct(Product product)
        {
            using(InventoryDbContext dbContext = _inventoryDbContextFactory.CreateDbContext())
            {
                switch (product.ProductCategory)
                {
                    case ProductCategoryEnum.Electronics:
                        dbContext.ElectronicProducts.Remove(ToElectronicsProductDTO((ElectronicsProduct)product));
                        break;
                    case ProductCategoryEnum.PerishableGoods:
                        dbContext.PerishableGoodsProducts.Remove(ToPerishableGoodsProductDTO((PerishableGoodsProduct)product));
                        break;
                    case ProductCategoryEnum.Clothing:
                        dbContext.ClothingProducts.Remove(ToClothingProductDTO((ClothingProduct)product));
                        break;
                }
                ProductDTO? dto = dbContext.Products.Find(product.ID);
                if (dto != null)
                {
                    dbContext.Products.Remove(ToProductDTO(product));
                }
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<Product?> GetProductByID(int id)
        {
            using (InventoryDbContext dbContext = _inventoryDbContextFactory.CreateDbContext())
            {
                List<ProductDTO> productDTOs = await dbContext.Products.ToListAsync();
                ProductDTO productDto = productDTOs.FirstOrDefault(p => p.ID == id);
                if(productDto == null)
                {
                    return null;
                }
                return ToProduct(productDto);
            }
        }
        private ProductDTO ToProductDTO(Product product)
        {
            if(product.ID != null)
            {
                return new ProductDTO
                {
                    ID = (int)product.ID,
                    Name = product.Name,
                    Category = product.ProductCategory.ToString(),
                    Price = product.Price,
                    Quantity = product.Quantity,
                };
            }
            return new ProductDTO
            {
                Name = product.Name,
                Category = product.ProductCategory.ToString(),
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }
        private ElectronicsProductDTO ToElectronicsProductDTO(ElectronicsProduct product)
        {
            if (product.ID != null)
            {
                return new ElectronicsProductDTO
                {
                    ID = (int)product.ID,
                    Name = product.Name,
                    Category = product.ProductCategory.ToString(),
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Voltage = product.Voltage,
                    BatteryCapacity = product.BatteryCapacity
                };
            }
            return new ElectronicsProductDTO
            {
                Name = product.Name,
                Category = product.ProductCategory.ToString(),
                Price = product.Price,
                Quantity = product.Quantity,
                Voltage = product.Voltage,
                BatteryCapacity = product.BatteryCapacity
            };
        }
        private PerishableGoodsProductDTO ToPerishableGoodsProductDTO(PerishableGoodsProduct product)
        {
            if(product.ID != null)
            {
                return new PerishableGoodsProductDTO
                {
                    ID = (int)product.ID,
                    Name = product.Name,
                    Category = product.ProductCategory.ToString(),
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Calories = product.Calories,
                    Weight = product.Weight,
                    ExpirationDate = product.ExpirationDate,
                };
            }
            return new PerishableGoodsProductDTO
            {
                Name = product.Name,
                Category = product.ProductCategory.ToString(),
                Price = product.Price,
                Quantity = product.Quantity,
                Calories = product.Calories,
                Weight = product.Weight,
                ExpirationDate = product.ExpirationDate,
            };
        }
        private ClothingProductDTO ToClothingProductDTO(ClothingProduct product)
        {
            if(product.ID != null)
            {
                return new ClothingProductDTO
                {
                    ID = (int)product.ID,
                    Name = product.Name,
                    Category = product.ProductCategory.ToString(),
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Size = product.Size.ToString(),
                    Fabric = product.Fabric.ToString(),
                };
            }
            return new ClothingProductDTO
            {
                Name = product.Name,
                Category = product.ProductCategory.ToString(),
                Price = product.Price,
                Quantity = product.Quantity,
                Size = product.Size.ToString(),
                Fabric = product.Fabric.ToString(),
            };
        }
        private Product ToProduct(ProductDTO dto)
        {
            switch (dto.Category)
            {
                case "Electronics":
                    return new ElectronicsProduct(dto.ID, dto?.Name??"", Enum.Parse<ProductCategoryEnum>(dto.Category), dto.Price, dto.Quantity, ((ElectronicsProductDTO)dto).Voltage, ((ElectronicsProductDTO)dto).BatteryCapacity);
                case "PerishableGoods":
                    return new PerishableGoodsProduct(dto.ID, dto?.Name??"", Enum.Parse<ProductCategoryEnum>(dto.Category), dto.Price, dto.Quantity, ((PerishableGoodsProductDTO)dto).Calories, ((PerishableGoodsProductDTO)dto).Weight, ((PerishableGoodsProductDTO)dto).ExpirationDate);
                case "Clothing":
                    return new ClothingProduct(dto.ID, dto?.Name??"", Enum.Parse<ProductCategoryEnum>(dto.Category), dto.Price, dto.Quantity, Enum.Parse<ClothingFabricEnum>(((ClothingProductDTO)dto).Fabric), Enum.Parse<ClothingSizeEnum>(((ClothingProductDTO)dto).Size));
                default:
                    throw new InvalidDbProductCategoryException(dto);
            }            
        }
    }
}
