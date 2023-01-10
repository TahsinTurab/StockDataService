using Microsoft.EntityFrameworkCore;
using StockData.Infrastructure.DbContexts;
using StockData.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.Repositories
{
    public class StockPriceRepository : Repository<StockPrice, Guid>, IStockPriceRepository
    {
        public StockPriceRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}
