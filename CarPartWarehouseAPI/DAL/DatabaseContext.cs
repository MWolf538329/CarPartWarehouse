using Microsoft.EntityFrameworkCore;
using DAL.DataModels;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<ProductLinkDTO> ProductLinks { get; set; }
        public DbSet<StockHistoryDTO> StockHistories { get; set; }
        public DbSet<SubcategoryDTO> Subcategories { get; set; }
        public DbSet<CategoryDTO> Categories { get; set; }
        public DbSet<CredentialDTO> Credentials { get; set; }

        private const string connection = 
            $"data source=MSI;initial catalog=CarPartWarehouse;trusted_connection=true;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conn = Environment.GetEnvironmentVariable("ConnectionString");
            
            if (conn == null)
            {
                conn = connection;
            }
            
            options.UseSqlServer(conn).UseLazyLoadingProxies();
            options.EnableSensitiveDataLogging();
        }
    }
}
