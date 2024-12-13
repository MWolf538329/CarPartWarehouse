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

        private const string connection = $"data source=MSI;initial catalog=CarPartWarehouse;trusted_connection=true;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conn = Environment.GetEnvironmentVariable("ConnectionString");
            
            if (conn == null)
            {
                conn = connection;
            }
            
            options.UseSqlServer(conn).UseLazyLoadingProxies();
        }
    }
}
