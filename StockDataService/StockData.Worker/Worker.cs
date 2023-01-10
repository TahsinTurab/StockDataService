using Autofac;
using StockData.Infrastructure.BusinessObjects;
using StockData.Infrastructure.DbContexts;
using StockData.Worker.htmlagilitypack;
using StockData.Worker.Models;

namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ILifetimeScope _scope;
        private readonly ApplicationDbContext _applicationDbContext;
        public Worker(ILogger<Worker> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while ((!stoppingToken.IsCancellationRequested) && (HtmlExtractor.IsOpen()==true))
            {

                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
               
                var CompanyDetails = HtmlExtractor.CompanyDetails();
                foreach (var c in CompanyDetails)
                {
                    try
                    {
                        CompanyCreateModel model = _scope.Resolve<CompanyCreateModel>();
                        model.CompanyId = int.Parse(c[0]);
                        model.Title = c[1].ToString();

                        var companyStockPrice = new StockPrice();
                        companyStockPrice.Id = Guid.NewGuid();
                        companyStockPrice.CompanyId = int.Parse(c[0]);
                        companyStockPrice.LastTradingPrice = double.Parse(c[2].ToString());
                        companyStockPrice.High = double.Parse(c[3].ToString());
                        companyStockPrice.Low = double.Parse(c[4].ToString());
                        companyStockPrice.ClosePrice = double.Parse(c[5].ToString());
                        companyStockPrice.YesterdayClosePrice = double.Parse(c[6].ToString());

                        if (c[7] != "--")
                        {
                            companyStockPrice.Change = double.Parse(c[7].ToString());
                        }

                        companyStockPrice.Trade = double.Parse(c[8].ToString());
                        companyStockPrice.Value = double.Parse(c[9].ToString());
                        companyStockPrice.Volume = double.Parse(c[10].ToString());
                        companyStockPrice.DateTime = DateTime.Now;

                        model.stockPrice = companyStockPrice;

                        model.ResolveDependency(_scope);

                        await model.CreateCompany();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                Console.WriteLine("done");
                await Task.Delay(60000, stoppingToken);  
                
            }
        }
    }
}