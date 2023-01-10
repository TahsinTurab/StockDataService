using Autofac;
using Microsoft.AspNetCore.Cors.Infrastructure;
using StockData.Infrastructure.DbContexts;
using StockData.Infrastructure.Repositories;
using StockData.Infrastructure.Services;
using StockData.Infrastructure.UnitOfWorks;

namespace StockData.Infrastructure
{
    public class InfrastructureModule: Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();

            builder.RegisterType<CompanyService>().As<ICompanyService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StockPriceRepository>().As<IStockPriceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
