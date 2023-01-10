using StockData.Infrastructure.UnitOfWorks;
using CompanyEO = StockData.Infrastructure.Entities.Company;
using CompanyBO = StockData.Infrastructure.BusinessObjects.Company;
using StockPriceBO = StockData.Infrastructure.BusinessObjects.StockPrice;
using StockPriceEO = StockData.Infrastructure.Entities.StockPrice;

namespace StockData.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public CompanyService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public void CreateCompany(CompanyBO company, StockPriceBO stockPrice)
        {
            CompanyEO companyEntity = new CompanyEO();
            companyEntity.Id = company.Id;
            companyEntity.TradeCode=company.TradeCode;
            
            StockPriceEO stockPriceEntity = new StockPriceEO();
            stockPriceEntity.Id = stockPrice.Id;
            stockPriceEntity.CompanyId= stockPrice.CompanyId;
            stockPriceEntity.Trade = stockPrice.Trade;
            stockPriceEntity.LastTradingPrice = stockPrice.LastTradingPrice;
            stockPriceEntity.High = stockPrice.High;
            stockPriceEntity.Low = stockPrice.Low;
            stockPriceEntity.ClosePrice = stockPrice.ClosePrice;
            stockPriceEntity.YesterdayClosePrice = stockPrice.YesterdayClosePrice;
            stockPriceEntity.Change = stockPrice.Change;
            stockPriceEntity.Value = stockPrice.Value;
            stockPriceEntity.Volume = stockPrice.Volume;
            stockPriceEntity.DateTime = stockPrice.DateTime;
            stockPriceEntity.Company = companyEntity;

            

            var Exist = _applicationUnitOfWork.Companies.GetById(companyEntity.Id);
            
            if(Exist == null)
            {
                List<StockPriceEO> stockPrices = new List<StockPriceEO>();
                stockPrices.Add(stockPriceEntity);
                companyEntity.StockPrices = stockPrices;
                _applicationUnitOfWork.Companies.Add(companyEntity);
                _applicationUnitOfWork.Save();
            }

            else
            {
                List<StockPriceEO> newStockPrices = new List<StockPriceEO>();
                newStockPrices.Add(stockPriceEntity);
                
                List<StockPriceEO> addedStock = _applicationUnitOfWork.StockPrices.GetAll().ToList();

                _applicationUnitOfWork.Companies.Remove(Exist.Id);
                _applicationUnitOfWork.Save();

                foreach (var item in addedStock)
                {
                    if(item.CompanyId == Exist.Id)
                    {
                        newStockPrices.Add(item);
                        Console.WriteLine(newStockPrices.Count);
                    }
                }
               
                companyEntity.StockPrices = newStockPrices;
                
                _applicationUnitOfWork.Companies.Add(companyEntity);
                _applicationUnitOfWork.Save();
            }
                
        }
    }
}
