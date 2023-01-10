using StockData.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IStockPriceRepository StockPrices { get; }
    }
}
