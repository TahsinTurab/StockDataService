using StockData.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockData.Infrastructure.Entities;

namespace StockData.Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Company>()
                .HasMany(n => n.StockPrices)
                .WithOne(a => a.Company)
                .HasForeignKey(x => x.CompanyId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
        
    }
}
