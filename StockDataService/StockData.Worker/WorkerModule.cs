using Autofac;
using StockData.Worker.Models;

namespace StockData.Worker
{
    public class WorkerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyCreateModel>().AsSelf();
            base.Load(builder);
        }
    }
}
