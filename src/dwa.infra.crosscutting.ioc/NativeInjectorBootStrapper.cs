using dwa.domain.AggregatesModel.CatalogoAggregate;
using dwa.domain.SeedWork;
using dwa.infra.data;
using dwa.infra.data.Repositories;
using dwa.infra.data.RepositoriesEfc;
using Microsoft.Extensions.DependencyInjection;

namespace dwa.infra.crosscutting.ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<DwaContext>();
            services.AddScoped(typeof(IEfcRepository<>), typeof(EfcRepository<>));


            services.AddScoped<ICatalagoRepository, CatalagoRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();

        }
    }
}
