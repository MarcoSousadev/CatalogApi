using catalogAPI.Application.Interfaces.Repositories;
using catalogAPI.Application.Interfaces.Repository;
using catalogAPI.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace catalogAPI.Infrastructure
{
    
        public static class ServiceRegister
        {
            public static void AddInfraestructure(this IServiceCollection services)
            {
                AddRepositories(services);
            }

            public static void AddRepositories (IServiceCollection services)
            {
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<IProductRepository, ProductRepository>();
            }
        }
 }

