using StockData.Infrastructure.BusinessObjects;

namespace StockData.Infrastructure.Services
{
    public interface ICompanyService
    {
        void CreateCompany(Company company, StockPrice stockPrice);
    }
}
