using CarPartWarehouseAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CarPartWarehouseAPI
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ProductDM> Products { get; set; }
        public DbSet<ProductLinkDM> ProductLinks { get; set; }
        public DbSet<StockDM> Stocks { get; set; }
        public DbSet<StockHistoryDM> StockHistories { get; set; }
        public DbSet<SubcategoryDM> Subcategories { get; set; }
        public DbSet<CategoryDM> Categories { get; set; }

        private const string con = $"Server=mssqlstud.fhict.local;Database=dbi514798_cobart;user id=dbi514798_cobart;password=SP#1;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(con)
            .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasMany(i => i.OrderLines).WithOne(l => l.Item)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
