using Autofac;
using StockData.Infrastructure.BusinessObjects;
using StockData.Infrastructure.Services;

namespace StockData.Worker.Models
{
    public class CompanyCreateModel
    {
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public StockPrice stockPrice { get; set; }

        private ICompanyService _companyService;
        private ILifetimeScope _scope;
        public CompanyCreateModel()
        {

        }

        public CompanyCreateModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _companyService=_scope.Resolve<ICompanyService>();
        }

        internal async Task CreateCompany()
        {
            Company company = new Company();
            company.Id = CompanyId;
            company.TradeCode = Title;
            company.StockPrice = stockPrice;
            _companyService.CreateCompany(company,stockPrice);

        }
    }
}
