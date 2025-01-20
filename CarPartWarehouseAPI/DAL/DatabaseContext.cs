using Microsoft.EntityFrameworkCore;
using DAL.DataModels;

namespace DAL;

public class DatabaseContext : DbContext
{
    public DbSet<ProductDTO> Products { get; init; }
    public DbSet<ProductLinkDTO> ProductLinks { get; init; }
    public DbSet<StockHistoryDTO> StockHistories { get; init; }
    public DbSet<SubcategoryDTO> Subcategories { get; init; }
    public DbSet<CategoryDTO> Categories { get; init; }
    public DbSet<CredentialDTO> Credentials { get; init; }
    public DbSet<SessionDTO> Sessions { get; init; }

    private const string connection = "data source=MSI;initial catalog=CarPartWarehouse;trusted_connection=true;TrustServerCertificate=True;";

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var conn = Environment.GetEnvironmentVariable("ConnectionString") ?? connection;

        options.UseSqlServer(conn).UseLazyLoadingProxies();
        options.EnableSensitiveDataLogging();
    }
}