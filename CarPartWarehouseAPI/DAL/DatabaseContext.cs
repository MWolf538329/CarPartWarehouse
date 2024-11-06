using Microsoft.EntityFrameworkCore;
using Logic.Models;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLink> ProductLinks { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        private const string con = $"Server=mssqlstud.fhict.local;Database=dbi514798_cobart;user id=dbi514798_cobart;password=SP#1;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(con)
            .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ItemDM>().HasMany(i => i.OrderLines).WithOne(l => l.Item)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
