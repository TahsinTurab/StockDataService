using StockData.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockData.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<StockPrice> StockPrices { get; set; }
    }
}