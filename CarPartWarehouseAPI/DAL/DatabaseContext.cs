using Microsoft.EntityFrameworkCore;
using Logic.Models;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLink> ProductLinks { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        private const string con = $"data source=MSI;initial catalog=CarPartWarehouse;trusted_connection=true;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(con)
            .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Item>().HasMany(i => i.OrderLines).WithOne(l => l.Item)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
