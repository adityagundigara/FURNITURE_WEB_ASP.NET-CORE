using FURNITURE_WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace FURNITURE_WEB.Data
{
    public class FurnitureDbContext : DbContext
    {
        public FurnitureDbContext(DbContextOptions<FurnitureDbContext> options) : base(options)
        {
        }

        public DbSet<FurnitureDataModel> FurnitureData { get; set; }
        public DbSet<ProductsDataModel> ProductsData { get; set; }
        public DbSet<SofaDataModel>SofaData { get; set; }
        public DbSet<ChairDataModel>Chairtbl { get; set; }
        public DbSet<AddCart>CartData { get; set; }
    }

}
