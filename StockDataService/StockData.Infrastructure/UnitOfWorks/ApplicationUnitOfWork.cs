using StockData.Infrastructure.Repositories;
using StockData.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace StockData.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ICompanyRepository Companies { get; private set; }
        public IStockPriceRepository StockPrices { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            ICompanyRepository companyRepository,
            IStockPriceRepository stockPrices) : base((DbContext)dbContext)
        {
            Companies = companyRepository;
            StockPrices = stockPrices;
        }
    }
}
